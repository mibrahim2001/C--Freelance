using System;

namespace MyApplication
{

    class Employee
    {

        private string name;

        private int number;
        private decimal rate;

        private double hours;

        private decimal gross;




        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
            this.gross = calculateGross(rate, hours);
        }

        private decimal calculateGross(decimal rate, double hours)
        {
            decimal gross = 0;
            decimal overtime = 0;
            if (hours > 40)
            {
                overtime = (rate / 2) * (decimal)(hours - 40);

            }
            gross = rate * (decimal)hours;
            return gross + overtime;
        }

        //getter setter methods
        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public int getNumber()
        {
            return this.number;
        }

        public void setNumber(int number)
        {
            this.number = number;
        }

        public decimal getRate()
        {
            return this.rate;
        }

        public void setRate(decimal rate)
        {
            this.rate = rate;
        }

        public double getHours()
        {
            return this.hours;
        }

        public void setHours(double hours)
        {
            this.hours = hours;
        }

        public decimal getGross()
        {
            return this.gross;
        }

        public void setGross(decimal gross)
        {
            this.gross = gross;
        }

        //tostring method
        public override string ToString()
        {
            return String.Format("{0} {1,12} {2,12} {3,12} {4,12}", name.PadRight(15), number, rate, hours, gross);
        }

    }



}

