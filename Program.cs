using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeAverage
{
    //Nombre del estudiante: Francisco Cortes
    //Grupo: 
    //Número y Texto del programa
    //Código Fuente: autoría propia
    class Employee 
    {
        // variables privadas con propiedades de empleado
        private string name;
        private int age;

        // Public properties to access the name and age values
        public string Name
        {
            get 
            { 
                return name; // retorna nombre 
            } 
            set 
            { 
                name = value; // guarda nombre
            } 
        }

        public int Age
        {
            get 
            { 
                return age; // returna edad
            } 
            set 
            { 
                age = value; // guarda edad
            } 
        }
    }
    class Program
    {
        static public int getNumberOfEmployees()
        {
            int employees = 0;
            while (true)
            {
                Console.Write("Ingrese numero de empleados: ");
                string numberEmployeesStr = Console.ReadLine();

                // revise si el numero de empleados esta en blanco o nulo
                if (string.IsNullOrWhiteSpace(numberEmployeesStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: el numero de empleados no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el numero de empleados puede ser un numero entero
                bool canBeInt = int.TryParse(numberEmployeesStr, out employees);
                if (canBeInt == false)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no es valido");
                    //regrese al inicio del loop
                    continue;
                }
                //revise si el capita es negativo o cero
                if (employees <= 0)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no puede ser negativo o cero");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }

            return employees;
        }

        static public Employee [] getEmployeeInformation(int numberOfEmployees)
        {
            //define el array para guardar employees
            Employee[] employeesArray = new Employee[numberOfEmployees];
            
            //por cada empleado...
            for (int i = 0; i < employeesArray.Length; i++) 
            {
                //creamos un objeto empleado
                Employee emp = new Employee();
                string employeeNameStr = "";
                int employeeAgeInt = 0;
                
                //pidamos el nombre y validemoslo
                while (true) 
                {
                    Console.Write("Ingrese nombre del empleado numero " + (i+1) + ": ");
                    employeeNameStr = Console.ReadLine();

                    // revise si el nombre del empleado esta en blanco o nulo
                    if (string.IsNullOrWhiteSpace(employeeNameStr))
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: el del empleado no puede estar en blanco");
                        //regrese al inicio del loop
                        continue;
                    }
                    //  revise si el nombre es un numero o tiene digitos
                    if (employeeNameStr.Any(char.IsDigit))
                    {
                        //si es asi indique mensaje de error
                        Console.WriteLine("el nombre no puede contener digitos");
                        //regrese al incio del loop
                        continue;
                    }
                    // si no hay problemas con la captura salga del loop
                    break;
                }
                
                //pidamos la edad y validemosla
                while (true)
                {
                    Console.Write("Ingrese Edad del Empleado: " + (i + 1) + ": ");
                    string employeeAgeStr = Console.ReadLine();

                    // revise si la edad esta en blanco o nulo
                    if (string.IsNullOrWhiteSpace(employeeAgeStr))
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: La edad no puede estar en blanco o ser nulo");
                        //regrese al inicio del loop
                        continue;
                    }
                    // revise si la edad puede ser un numero entero
                    bool canBeInt = int.TryParse(employeeAgeStr, out employeeAgeInt);
                    if (canBeInt == false)
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("El dato ingresado no es valido");
                        //regrese al inicio del loop
                        continue;
                    }
                    //revise que si la edad es un numero negativo
                    if (employeeAgeInt <= 0) 
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: La edad no puede ser un numero negativo");
                        //regrese al inicio del loop
                        continue;
                    }
                    // si no hay problemas con la captura salga del loop
                    break;
                }
                //asigne el nombre y la edad validada al objeto empleado creado
                emp.Age = employeeAgeInt;
                emp.Name = employeeNameStr;
                //guarde el objeto empleado en el array;
                employeesArray[i] = emp;
            }
            return employeesArray;
        }

        static double getAgeAverage(Employee [] Employees) {
            int sumTotalAges = 0;
            double average = 0.0;
            for (int j = 0; j < Employees.Length; j++)
            {
                sumTotalAges += Employees[j].Age;
            }
            average = sumTotalAges / Employees.Length;
            return average;
        }
        static void Main(string[] args)
        {
            //indique que hace el programa
            Console.Write("Este programa calcula el promedio de edades de un numero de empleados\n\n");
            
            //variable para guardar el numero de empleados
            int numberOfEmployees = getNumberOfEmployees();
            Console.WriteLine("\n");

            //capture la informacion de empleados
            Employee[] Employees = getEmployeeInformation(numberOfEmployees);
            //muestre cada edad de cada empleado capturado

            //obtenga el promedio de la edades de los empleados y presente este en pantalla
            double average = getAgeAverage(Employees);
            Console.WriteLine("El promedio de edad de los empleados es: {0:N2}",average);
            Console.WriteLine("Presione enter para finalizar...");
            Console.ReadLine();
        }
    }
}
