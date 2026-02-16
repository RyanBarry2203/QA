using System;
using System.Diagnostics;
using System.Text;
using log4net;

namespace Week_5_Lab
{
    public class Program
    {
        //static void Main(string[] args)
        //{
        //    log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

        //    MyClass myClass = new MyClass();
        //    myClass.DoSomething();

        //    try
        //    {
        //        Console.Write("Enter num 1: ");
        //        int num1 = int.Parse(Console.ReadLine());
        //        Console.Write("Enter num 2: ");
        //        int num2 = int.Parse(Console.ReadLine());

        //        int result = num1 / num2;
        //        Console.WriteLine($"Result: {result}");
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        log4net.LogManager.GetLogger(typeof(Program)).Error("An error occurred while dividing by zero.", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        log4net.LogManager.GetLogger(typeof(Program)).Error("An unexpected error occurred.", ex);
        //    }
        //}
        public Stopwatch sw = Stopwatch.StartNew();
        public static int slowTime;

        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            int iterations = 100_000;

            Stopwatch sw = Stopwatch.StartNew();
            string slowResult = SlowConcat(iterations);
            sw.Stop();

            MyClass myClass1 = new MyClass();
            myClass1.ShowException($"SlowConcat Time: {sw.ElapsedMilliseconds} ms");

            slowTime = (int)sw.ElapsedMilliseconds;

            sw.Restart();
            string fastResult = FastConcat(iterations);
            sw.Stop();
            myClass1.ShowException($"FastConcat Time: {sw.ElapsedMilliseconds} ms");
        }

        // Inefficient method using string concatenation inside a loop
        static string SlowConcat(int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += i; // Creates a new string object each time
            }
            return result;
        }

        // Efficient method using StringBuilder
        static string FastConcat(int count)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                sb.Append(i); // Modifies the existing buffer, avoiding new allocations
            }
            return sb.ToString();
        }
    }
    }


