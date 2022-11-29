using System;
using System.Text;
using System.Text.RegularExpressions;

namespace lr4
{
    internal class Scan
    {
        private int currentDepth, maxDepth;
        private int currentCount, maxCount;
        private string url;
        public HttpClient client = new HttpClient();
        public event Action<string, string, int, string> AddressFound;
        public event Action<string, string, int, string> PhoneNumberFound;

        public Scan(int depth, int count, string url)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.102 Safari/537.36 OPR/90.0.4480.84");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            client.DefaultRequestHeaders.Add("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");

            maxDepth = depth;
            maxCount = count;
            this.url = url;
        }

        private Queue<CurrentPage> pages = new Queue<CurrentPage>();
        private List<CurrentPage> lookedPages = new List<CurrentPage>();

        public async void Process(string url = null)
        {
            var page = pages.Count != 0 ? pages.Dequeue() : new CurrentPage(url, 0, "");
            string link;
            currentDepth = page._depth;

            if (url != null)
            {
                link = url;
            }
            else
            {
                link = page._link;
            }

            HttpResponseMessage message = client.Send(new HttpRequestMessage(HttpMethod.Get, link));
            string pageText = await message.Content.ReadAsStringAsync();

            var title = Regex.Matches(pageText, @"<title>(.*)</title>");
            string pageTitle = title.Count != 0 ? title[0].Groups[1].Value : "No title";
            page._pageTitle = pageTitle;

            var addresses = Regex.Matches(pageText, @"title=""Карта"">(.*)<\/a>");

            for (int i = 0; i < addresses.Count; i++)
            {
                string address = addresses[i].Groups[1].Value;

                if (!lookedPages.SelectMany(c => c._addresses).ToList().Contains(address))
                {
                    page._addresses.Add(address);
                    AddressFound?.Invoke(pageTitle, link, page._depth, address);
                }
            }

            var phoneNumbers = Regex.Matches(pageText, @"href=""tel:.*"">(.*)</a>");

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                string phoneNumber = phoneNumbers[i].Groups[1].Value;

                if (!lookedPages.SelectMany(c => c._phoneNumbers).ToList().Contains(phoneNumber))
                {
                    page._phoneNumbers.Add(phoneNumber);
                    PhoneNumberFound?.Invoke(pageTitle, link, page._depth, phoneNumber);
                }
            }

            lookedPages.Add(page);
            currentCount++;

            var locals = Regex.Matches(pageText, @"<a href=""([/\w-]+)"">(.*)</a>");

            for (int i = 0; i < locals.Count; i++)
            {
                pages.Enqueue(new CurrentPage(this.url + locals[i].Groups[1].Value, currentDepth + 1, ""));
            }

            if (pages.Count == 0 || currentDepth > maxDepth || currentCount == maxCount)
            {
                return;
            }

            Process();
        }

        private IEnumerable<CurrentPage> GetPages()
        {
            return lookedPages.OrderBy(p => p._depth);
        }

        public void CreateFile(string name = "1.csv")
        {
            using (StreamWriter sw = new StreamWriter(name, false, Encoding.UTF8))
            {
                sw.WriteLine("Ссылка;Название;Адрес;Номер телефона;Уровень");
                foreach (var p in GetPages().Where(p => p._addresses.Count >= 0).Where(p => p._phoneNumbers.Count >= 0))
                {
                    if (p._addresses.Count == 0 && p._phoneNumbers.Count > 0)
                    {
                        sw.WriteLine($"{p.Nesting}{p._link};{p._pageTitle};Нет;{p.PhoneNumbers};{p._depth}");
                    }
                    else if (p._phoneNumbers.Count == 0 && p._addresses.Count > 0)
                    {
                        sw.WriteLine($"{p.Nesting}{p._link};{p._pageTitle};{p.Addresses};Нет;{p._depth}");
                    }
                    else if (p._addresses.Count > 0 && p._phoneNumbers.Count > 0)
                    {
                        sw.WriteLine($"{p.Nesting}{p._link};{p._pageTitle};{p.Addresses};{p.PhoneNumbers};{p._depth}");
                    }
                }
            }
        }
    }
}
