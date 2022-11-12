using System;
using System.Net;
using System.Text.RegularExpressions;

namespace lr4
{
    public class WebScan : IDisposable
    {
        private readonly HashSet<Uri> _procLinks = new HashSet<Uri>();
        private readonly WebClient _webClient = new WebClient();

        private readonly HashSet<string> _ignoreFiles = new HashSet<string>() { ".ico", ".xml", ".css" };

        private void OnAddressFound(Uri page, string[] addresses)
        {
            AddressFound?.Invoke(page, addresses);
        }

        private void OnPhoneNumberFound(Uri page, string[] numbers)
        {
            PhoneNumberFound?.Invoke(page, numbers);
        }

        private void Process(string domain, Uri page, int count)
        {
            if (count <= 0)
            {
                return;
            }

            if (_procLinks.Contains(page))
            {
                count++;
                return;
            }

            _procLinks.Add(page);

            _webClient.Headers["User-Agent"] = "Mozilla/5.0";
            string html = _webClient.DownloadString(page);
            html = html.Replace(@"href=""ar""", "");
            html = html.Replace(@"href=""zh""", "");

            var adresses = (from href in Regex.Matches(html, @"title=""map"">[\w, ]*").Cast<Match>()
                            let address = href.Value.Replace(@"title=""map"">", "")
                            select address).ToArray();

            if (adresses.Length > 0)
            {
                OnAddressFound(page, adresses);
            }

            var numbers = (from href in Regex.Matches(html, @"href=""tel:[+ \d -]*""").Cast<Match>()
                           let number = href.Value.Replace(@"href=", "").Trim('"').Replace("tel:", "")
                           select number).ToArray();

            if (numbers.Length > 0)
            {
                OnPhoneNumberFound(page, numbers);
            }

            try
            {
                var hrefs = (from href in Regex.Matches(html, @"href=""[\/\w-\.:]+""").Cast<Match>()
                             let url = href.Value.Replace("href=", "").Trim('"')
                             let loc = url.StartsWith("/")
                             select new
                             {
                                 Ref = new Uri(loc ? $"{domain}{url}" : url),
                                 IsLocal = loc || url.StartsWith(domain)
                             }
                         ).ToList();

                var locals = (from href in hrefs where href.IsLocal select href.Ref).ToList();

                foreach (var href in locals)
                {
                    string fileEx = Path.GetExtension(href.LocalPath).ToLower();
                    if (_ignoreFiles.Contains(fileEx))
                    {
                        continue;
                    }

                    Process(domain, href, --count);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exception");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public event Action<Uri, string[]> AddressFound;
        public event Action<Uri, string[]> PhoneNumberFound;

        public void Scan(Uri startPage, int pageCount)
        {
            // pageCount - количество просматриваемых страниц
            _procLinks.Clear();

            string domain = $"{startPage.Scheme}://{startPage.Host}";
            Process(domain, startPage, pageCount);
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }
    }
}
