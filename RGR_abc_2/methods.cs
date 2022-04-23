using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR_abc_2
{
    internal class methods
    {
        /// <summary>
        /// Форматирование строки
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns></returns>
        private static bool FormattingString(string str)
        {
            string [] StrArray = str.Split('+', '-', '*', '/', '=');

            for (int i = 0; i < StrArray.Length; i++)
            {
                int count = StrArray[i].ToCharArray().Where(i => i == ',').Count();

                if (count == 2)
                {
                    return true;
                }
            }

            char[] chars = str.ToCharArray();

            if (chars[0] == '+' || chars[0] == '-' || chars[0] == '*' || chars[0] == '/')
            {
                return true;
            }

            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] == '+' || chars[i] == '-' || chars[i] == '*' || chars[i] == '/')
                {
                    if (chars[i + 1] == '+' || chars[i + 1] == '-' || chars[i + 1] == '*' || chars[i + 1] == '/')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Метод считающий количество чисел в строке
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns></returns>
        private static int ElementCount(string str)
        {
            string[] ValueArrayStr = str.Split('+', '-', '*', '/', '=');

            return ValueArrayStr.Length;
        }

        /// <summary>
        /// Все элементы строчки форматируются в массив дабл
        /// </summary>
        /// <param name="str">Строчка</param>
        /// <returns></returns>
        private static double[] formatting(string str)
        {
            string[] ValueArrayStr = str.Split('+', '-', '*', '/', '=');

            for (int i = 0; i < ValueArrayStr.Length; i++)
            {
                ValueArrayStr[i] = translation_2_10(ValueArrayStr[i]);
            }

            double[] ValueArrayDouble = new double[ValueArrayStr.Length];

            for (int i = 0; i < ValueArrayStr.Length; i++)
            {
                ValueArrayDouble[i] = Convert.ToDouble(ValueArrayStr[i]);
            }

            return ValueArrayDouble;
        }

        /// <summary>
        /// Метод переводящий из двоичной системы числения в десятичную
        /// </summary>
        /// <param name="str">строка в формате строки</param>
        /// <returns></returns>
        private static string translation_2_10(string str)
        {
            string[] ArrayString = str.Split(',');
            double[] Sum = new double[ArrayString.Length];

            for (int i = 0; i < ArrayString.Length; i++)
            {
                char[] chars = ArrayString[i].ToCharArray();
                List<int> list_1 = new List<int>();
                List<int> list_2 = new List<int>();

                if (i == 0)
                {
                    for (int j = 0; j < chars.Length; j++)
                    {
                        if (chars[j] == 49)
                        {
                            list_1.Add(chars.Length - 1 - j);
                        }
                    }

                    foreach (var item in list_1)
                    {
                        if (item == 0)
                        {
                            Sum[i] += 1;
                        }
                        else
                        {
                            Sum[i] += Math.Pow(2, item);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < chars.Length; j++)
                    {
                        if (chars[j] == 49)
                        {
                            list_2.Add(j + 1);
                        }
                    }

                    foreach (var item in list_2)
                    {
                        if (item == 0)
                        {
                            Sum[i] += 0.5;
                        }
                        else
                        {
                            Sum[i] += Math.Pow(2, -(item));
                        }
                    }
                }
            }

            double value = Sum.Sum();

            return value.ToString();
        }

        /// <summary>
        /// Метод считающий все элементы в строке
        /// </summary>
        /// <param name="list_value">Лист со значениями</param>
        /// <param name="list_signs">Лист с знаками</param>
        /// <returns></returns>
        private static double Sum(double[] ValueArrayDouble, List<char> list_signs)
        {
            double value = ValueArrayDouble[0];
            int i = 1;

            foreach (var item in list_signs)
            {
                switch (item)
                {
                    case '+':
                        value += ValueArrayDouble[i];
                        i++;
                        break;
                    case '-':
                        value -= ValueArrayDouble[i];
                        i++;
                        break;
                    case '*':
                        value *= ValueArrayDouble[i];
                        i++;
                        break;
                    case '/':
                        value /= ValueArrayDouble[i];
                        i++;
                        break;
                }
            }

            return value;
        }

        /// <summary>
        /// Метод для помещения знаков в лист
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static List<char> signs_list(string str)
        {
            List<char> signs = new List<char>();

            foreach (char c in str)
            {
                switch (c)
                {
                    case '+':
                        signs.Add('+');
                        break;
                    case '-':
                        signs.Add('-');
                        break;
                    case '*':
                        signs.Add('*');
                        break;
                    case '/':
                        signs.Add('/');
                        break;
                }
            }

            return signs;
        }

        /// <summary>
        /// Метод переводящий из десятичной системы счисления в двоичную
        /// </summary>
        /// <param name="value">Переводящиеся число</param>
        /// <returns></returns>
        private static double translation_10_2(double value)
        {
            //Воруем целую часть
            string zel;
            zel = Convert.ToString(Convert.ToInt32(Math.Truncate(value)), 2);
            int zel1 = Convert.ToInt32(Math.Truncate(value));
            Console.WriteLine("{0}", zel, zel1);
            //Воруем дробную часть
            double text2;
            text2 = value - Math.Truncate(value);
            Console.WriteLine("{0}", text2);

            double[] asd = new double[10];
            asd[0] = text2;

            string drob = null;

            for (int i = 1; i < 10; i++)
            {
                asd[i] = (2 * asd[i - 1]) - Math.Truncate(asd[i - 1] * 2);
                int bin = Convert.ToInt32(Math.Truncate(asd[i - 1] * 2));
                drob += bin;
            }

            string str = $"{zel},{drob}";

            return Convert.ToDouble(str);
        }

        /// <summary>
        /// Метод реализации всех мeтодов вместе
        /// </summary>
        /// <param name="str">Строчка</param>
        /// <returns></returns>
        public static string implementation(string str)
        {
            bool examination = FormattingString(str);

            if (examination)
            {
                return "Ошибка!";
            }

            List<char> signs = signs_list(str);

            int value_element = ElementCount(str);

            double[] ValueArrayDouble = new double[value_element];
            ValueArrayDouble = formatting(str);

            double SumValue = Sum(ValueArrayDouble, signs);

            SumValue = translation_10_2(SumValue);

            return SumValue.ToString();
        }
    }
}

