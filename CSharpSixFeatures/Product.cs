#region

using System;
using System.Collections.Generic;

#endregion

namespace CSharpSixFeatures
{
    public class Product
    {
       
        //getter only auto-properties
        public string Name { get; }

        //auto-properties initializers
        public long Id { get; } = GenerateId();

        public string[] OtherNames { get; set; }

        //expression bodies on properties
        public string LongName => Id + " - " + Name;

        public bool IsActive { get; set; } = true;

        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddYears(1);

        public Dictionary<string, int> Stock { get; set; }

        public Product(string name)
        {
            Name = name;
        }

        //expression bodies on methods
        public void ExtendExpirationDate(int numberOfMonths)
            => ExpirationDate = ExpirationDate.AddMonths(numberOfMonths);

        public bool IsExpired() => DateTime.Now > ExpirationDate;

        public string GetFirstOtherName()
        {
            //null-conditional operators
            return OtherNames?[0];
        }

        public void WriteNames()
        {
            //using static ("using static System.Console;")
            Console.WriteLine(LongName);

            //string interpolation
            Console.WriteLine($"{Id} - {Name}");
        }

        public void WriteOtherNames()
        {
            if (OtherNames == null)
            {
                //nameof expressions
                throw new NullReferenceException(nameof(OtherNames));
            }

            foreach (var name in OtherNames)
            {
                Console.WriteLine(name);
            }
        }

        public void InitializeStock()
        {
            try
            {
                //index initializers
                Stock = new Dictionary<string, int>
                {
                    ["Store 1"] = 91,
                    ["Store 2"] = 40,
                    ["Store 3"] = 75
                };
            }
                //exception filter used for logging purposes
            catch (Exception e) when (LogExceptionMessage(e))
            {
                throw;
            }
        }

        private static long GenerateId()
        {
            var random = new Random();
            return random.Next(0, 1000000);
        }

        private static bool LogExceptionMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            return true;
        }
    }
}