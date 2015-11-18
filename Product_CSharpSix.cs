#region

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#endregion

namespace CSharp6
{
    public class Product
    {
        public long Id { get; } = GenerateId();
        public string Name { get; }

        public string[] OtherNames { get; set; }
        public string LongName => Id + " - " + Name;
        public bool IsActive { get; set; } = true;
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddYears(1);

        public Product(string name)
        {
            Name = name;
        }


        private static long GenerateId()
        {
            Random random = new Random();
            return random.Next(0, 1000000);
        }

        public void ExtendExpirationDate(int numberOfMonths)
            => ExpirationDate = ExpirationDate.AddMonths(numberOfMonths);

        public bool IsExpired() => (DateTime.Now > ExpirationDate);

        public string GetFirstOtherName()
        {
            return OtherNames?[0];
        }
    }
}