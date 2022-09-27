using System;
using System.IO;

namespace MyApplication
{

    class Lab1
    {
        public static void Main()
        {

            Employee[] employees = new Employee[100];
            Console.WriteLine(String.Format("{0} {1,12} {2,12} {3,12} {4,12}", "Name".PadRight(15), "Number", "Rate", "Hours", "Gross"));
            Console.WriteLine();
            readDataFromFile(employees, "./EmployeeData.csv");
        }

        public static void readDataFromFile(Employee[] employees, String fileName)
        {
            int index = 0;
            Employee temp;
            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                string name = columns[0];
                int number = int.Parse(columns[1]);
                decimal rate = decimal.Parse(columns[2]);
                double hours = double.Parse(columns[3]);

                temp = new Employee(name, number, rate, hours);
                Console.WriteLine(temp);
                employees[index] = temp;
                index++;

            }
        }
    }
}



