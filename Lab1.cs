using System;
using System.IO;

namespace MyApplication
{

    class Lab1
    {
        /// <summary>
        /// The main method asks the user to select a option and keeps asking until the
        /// user quits the program 
        /// This method used other methods in this class to show the desired output
        /// </summary>
        public static void Main()
        {
            int choice = 0;
            Employee[] employees = new Employee[100];
            readDataFromFile(employees, "./EmployeeData.csv");

            while (choice != 6)
            {
                Console.WriteLine();
                Console.Write("Please choose what you want to do: \n" +
                "1. Sort by  Employee Name(ascending)\n" +
                "2. Sort by Employee Number(ascending)\n" +
                "3. Sort by Employee Pay Rate(descending)\n" +
                "4. Sort by Employee Hours(descending)\n" +
                "5. Sort by Employee Gross Pay(descending)\n" +
                "6. Exit\n");

                choice = Convert.ToInt32(Console.ReadLine());


                if (choice > 0 && choice < 6)
                {
                    sort(employees, choice);

                    Console.WriteLine(String.Format("{0} {1,12} {2,12} {3,12} {4,12}", "Name".PadRight(15), "Number", "Rate", "Hours", "Gross"));
                    Console.WriteLine();
                    for (int i = 0; i < employees.Length; i++)
                    {
                        if (employees[i] != null)
                        {
                            Console.WriteLine(employees[i]);
                        }
                    }
                }
                else if (choice != 6)
                {
                    Console.WriteLine("Please choose a valid option!(1-6)");
                }
            }


        }

        /// <summary>
        /// we read data from csv file using the System.IO.File.ReadAllLines method
        /// then we iterate through the array of lines and split line into columns by a
        /// delimator which is a coma
        /// we make a new object of type Employee and then add it to the employees array
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="fileName"></param>
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
                employees[index] = temp;
                index++;

            }
        }

        /// <summary>
        /// insertion sort is used here we sort the array according to the option selected
        /// by the user by help of another method which is compareEmployee
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="option"></param>
        public static void sort(Employee[] arr, int option)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                Employee key = arr[i];
                if (key == null)
                {
                    continue;
                }
                int j = i - 1;


                while (j >= 0 && compareEmployee(arr[j], key, option))
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }


        /// <summary>
        /// we compare the attribute of employee 1 and employee 2 according to the option selected by the user
        /// returning true depends on the condition whether we want to sort ascendingly or descendingly
        /// </summary>
        /// <param name="employee1"></param>
        /// <param name="employee2"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static bool compareEmployee(Employee employee1, Employee employee2, int option)
        {

            bool compare = false;
            switch (option)
            {
                case 1:
                    if (string.Compare(employee1.getName(), employee2.getName()) > 0)
                    {
                        compare = true;
                    }
                    break;

                case 2:
                    if (employee1.getNumber() > employee2.getNumber())
                    {
                        compare = true;
                    }
                    break;

                case 3:
                    if (employee1.getRate() < employee2.getRate())
                    {
                        compare = true;
                    }
                    break;

                case 4:
                    if (employee1.getHours() < employee2.getHours())
                    {
                        compare = true;
                    }
                    break;

                case 5:
                    if (employee1.getGross() < employee2.getGross())
                    {
                        compare = true;
                    }

                    break;


            }

            return compare;
        }
    }
}



