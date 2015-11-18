#region

using System;

#endregion

namespace CSharp5
{
    public class Product
    {
        public long Id { get; private set; }
        public string Name { get; set; }
        public string LongName { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string[] OtherNames { get; set; }


        public Product(string name)
        {
            Id = GenerateId();
            Name = name;
            LongName = Id + " - " + Name;
            IsActive = true;
            ExpirationDate = DateTime.Now.AddYears(1);
        }

        private long GenerateId()
        {
            Random random = new Random();
            return random.Next(0, 1000000);
        }


        public void ExtendExpirationDate(int numberOfMonths)
        {
            ExpirationDate = ExpirationDate.AddMonths(numberOfMonths);
        }

        public bool IsExpired()
        {
            return (DateTime.Now > ExpirationDate);
        }


        public string GetFirstOtherName()
        {
            return OtherNames != null ? OtherNames[0] : null;
        }
    }
}