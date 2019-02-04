using System;

namespace IntegerString
{
    class Program
    {
        /// <summary>
        /// Кастомная реализация перевода целого числа в строку
        /// </summary>
        /// <param name="num">Число, которое нужно перевести в строку</param>
        /// <returns>Строковое представление числа</returns>
        public static string IntToString(int num)
        {
            if (num == 0) return "0";

            bool negative = num < 0;
            int delimiter = 10;
            int exp;
            string str = "";

            while (num != 0)
            {
                exp = num % delimiter;
                num = num / delimiter;

                if (negative) exp = -exp;
                str = exp + str;
            }

            return negative ? "-" + str : str;
        }

        static void Main(string[] args)
        {
            Test(0, "0");
            Test(1234567890, "1234567890");
            Test(int.MaxValue, "2147483647");
            Test(int.MinValue, "-2147483648");
        }

        private static void Test(int num, string expectedResult)
        {
            var result = IntToString(num);
            if (result == expectedResult)
                Console.WriteLine(string.Format("{0} - OK", num));
            else
                Console.WriteLine(string.Format("{0} - failed. Expected: {1} but was {2}", num, expectedResult, result));
        }
    }
}
