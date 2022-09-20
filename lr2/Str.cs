using System;

namespace lr2
{
    internal class Str
    {
        private char[] _chars;

        public Str(string chars)
        {
            _chars = chars.ToCharArray();
        }

        public static bool operator ==(Str chars1, Str chars2)
        {
            bool result = Comparison(chars1, chars2);
            return result;
        }

        public static bool operator !=(Str chars1, Str chars2)
        {
            bool result = Comparison(chars1, chars2);
            return !result;
        }

        public static string operator +(Str chars1, Str chars2)
        {
            char[] newStr = new char[chars1._chars.Length + chars2._chars.Length];

            // Запись символов из chars1
            for (int i = 0; i < chars1._chars.Length; i++)
            {
                newStr[i] = chars1._chars[i];
            }

            // Запись символов из chars2
            int temp = chars1._chars.Length;
            for (int i = 0; i < chars2._chars.Length; i++)
            {
                newStr[temp] = chars2._chars[i];
                temp++;
            }

            return new string(newStr);
        }

        public static string operator *(Str chars, int n)
        {
            char[] newStr = new char[chars._chars.Length * n];
            
            // Добавление символов массива chars._chars в массив newStr n раз
            int temp = 0;
            for (int i = 0; i < newStr.Length; i++)
            {
                if (temp == chars._chars.Length)
                {
                    temp = 0;
                }
                
                newStr[i] = chars._chars[temp];

                temp++;
            }

            return new string(newStr);
        }

        private static bool Comparison(Str chars1, Str chars2)
        {
            if (chars1._chars.Length != chars2._chars.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < chars1._chars.Length; i++)
                {
                    if (chars1._chars[i] != chars2._chars[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public override string ToString()
        {
            return new string(_chars);
        }
    }
}
