using System;

namespace lr4
{
    internal class CurrentPage
    {
        public List<string> _addresses = new List<string>();
        public List<string> _phoneNumbers = new List<string>();
        public string _link;
        public int _depth;
        public string _pageTitle;

        public string Addresses
        {
            get
            {
                return string.Join(" ", _addresses);
            }
        }

        public string PhoneNumbers
        {
            get
            {
                return string.Join(" ", _phoneNumbers);
            }
        }

        public string Nesting
        {
            get
            {
                string result = "";
                for (int i = 0; i < _depth; i++)
                {
                    result += "|--";
                }

                return result;
            }
        }

        public CurrentPage(string link, int depth, string pageTitle)
        {
            _link = link;
            _depth = depth;
            _pageTitle = pageTitle;
        }
    }
}
