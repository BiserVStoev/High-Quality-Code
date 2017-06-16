namespace Huy_Phuong.Models
{
    using System;
    using System.Text;

    public class Performance
    {
        private string name;
        private string theater;
        private decimal price;

        public Performance(string name, string theater, DateTime date, TimeSpan duration, decimal price)
        {
            this.Name = name;
            this.Theater = theater; 
            this.Date = date;
            this.Duration = duration;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                ValideIfNullOrEmpty(value, "Name", "name");

                this.name = value;
            }
        }

        public string Theater
        {
            get
            {
                return this.theater;
            }

            private set
            {
                ValideIfNullOrEmpty(value, "Theater", "theater");

                this.theater = value;
            }
        }

        public DateTime Date { get; }

        public TimeSpan Duration { get; }

        public decimal Price
        {
            get
            {
                return this.price; 
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price", "Price cannot be negative.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("({0}, {1})", this.Name, this.Date.ToString("dd.MM.yyyy HH:mm"));

            return result.ToString();
        }

        private static void ValideIfNullOrEmpty(string value, string type, string param)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(param, $"{type} cannot be null or empty.");
            }
        }
    }
}
