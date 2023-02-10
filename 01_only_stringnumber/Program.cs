using System;

namespace string_number
{
    internal class Program
    {
        private class Exception_01 : Exception
        {
            public Exception_01(string message)
                : base(message) { }
        }

        private class Start_with_0 : Exception
        {
            public Start_with_0(string message)
                : base(message) { }
        }

        private static void enter()
        {
            int converted = 0;

        Start:

            string input = Console.ReadLine();

            string[] splited = input.Split();

            string no_space = "";

            for (int i = 0; i < splited.Length; i++)
            {
                no_space += splited[i];
            }

            for (int i = 0; i < splited.Length; i++)
            {
                try
                {
                    if (splited[i] != "0")
                    {
                        if (splited[i] != "1")
                        {
                            throw new Exception_01("число не может содержать " + splited[i] + " только 0 или 1");
                        }
                    }
                }
                catch (Exception_01 ex)
                {
                    Console.WriteLine(ex.Message);
                    goto Start;
                }
            }

            try
            {
                if (splited[0] == "0")
                {
                    throw new Start_with_0("число не может начаться с 0");
                }
            }
            catch (Start_with_0 s0)
            {
                Console.WriteLine(s0.Message);
                goto Start;
            }

            try
            {
                converted = Convert.ToInt32(no_space);
            }
            catch (OverflowException OE)
            {
                Console.WriteLine(OE.Message);
                goto Start;
            }

            Console.WriteLine("число в Int32 " + converted);
        }

        private static void Main(string[] args)
        {
            enter();

            Console.ReadLine();
        }
    }
}