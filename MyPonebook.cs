using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_module3
{
    public class MyPonebook<T> : IEnumerable<IContact>
    {
        private const string EnglishAlpabet = "ABCDEFJGHKLMINOPURSQWXYZ";
        private const string UkrAlpabet = "АБВГДЕЭЖЗИіїЙКЛМНОПРСТФХЦЧШЩЬЮЯ";
        private Dictionary<string, List<IContact>> _dete;
        private Dictionary<string, string> _suportedCultures;
        public MyPonebook()
        {
            _dete = new Dictionary<string, List<IContact>>();
            _suportedCultures = new Dictionary<string, string>
            {
                { "en-US", EnglishAlpabet },
                { "uk", UkrAlpabet }
            };
        }

        public void Add(IContact contact, CultureInfo culture)
        {
            string chapter = GetChapter(contact, culture);
            if (!_dete.ContainsKey(chapter))
            {
                _dete.Add(chapter, new List<IContact>());
            }

            _dete[chapter].Add(contact);
        }

        public void Remuve(IContact contact, CultureInfo culture)
        {
            string chapter = GetChapter(contact, culture);
            if (!_dete.ContainsKey(chapter))
            {
                _dete[chapter].Remove(contact);
                if (_dete[chapter].Count == 0)
                {
                    _dete.Remove(chapter);
                }
            }
        }

        public IEnumerator<IContact> GetEnumerator()
        {
            return new PhonebookEnumerator(_dete);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string GetChapter(IContact contact, CultureInfo culture)
        {
            if (!CheckIfCultureisSuported(culture))
            {
                culture = new CultureInfo("en-US");
            }

            foreach (var item in _suportedCultures)
            {
                if (item.Key == culture.Name)
                {
                    if (char.IsDigit(contact.Neme[0]))
                    {
                        return "0-9";
                    }

                    if (item.Value.IndexOf(contact.Neme.ToUpper()[0]) == -1)
                    {
                        return "#";
                    }

                    return contact.Neme[0].ToString();
                }
            }

            return string.Empty;
        }

        private bool CheckIfCultureisSuported(CultureInfo culture)
        {
            foreach (var item in _suportedCultures)
            {
                if (item.Key == culture.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
