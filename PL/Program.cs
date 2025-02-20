//using BLL;
using System.Runtime.Intrinsics.Arm;
using BLL;
using DAL;
using DTO;
class Program
{

    public void input()
    {
        int i = 1;
        while (i > 0)
        {
            Console.WriteLine("Employee Management System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee info");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. See employee list");
            Console.WriteLine("5. Add Department");
            Console.WriteLine("6. Delete Department ");
            Console.WriteLine("7. Update Department info");
            Console.WriteLine("8. Total Department List");
            Console.WriteLine("9. Search Employee by entering Name:");
            Console.WriteLine("10. Search Employee by entering ID:");
            Console.WriteLine("11. Search Employee by entering Dept name:");
            Console.WriteLine("12. Search Employee by entering Joining date:");
            Console.WriteLine("13. Exit");
            Console.WriteLine("Choose what you want: ");
            int option = int.Parse(Console.ReadLine());

            EmployeeDTO eDTO = new EmployeeDTO();
            EmployeeBLL eBLL = new EmployeeBLL();

            DepartmentDTO dDTO = new DepartmentDTO();
            DepartmentBLL dBLL = new DepartmentBLL();

            if (option == 1)
            {
                Console.Write("Enter name:");
                string? name = Console.ReadLine();
                Console.Write("Enter ID:");
                int id = int.Parse(Console.ReadLine()!);
                Console.Write("Enter Department:");
                string? dept = Console.ReadLine();
                Console.Write("Enter Salary:");
                int sal = int.Parse(Console.ReadLine());
                Console.Write("Enter Joining Date:");
                string? JoiningDate = Console.ReadLine();
                eDTO.eName = name;
                eDTO.eID = id;
                eDTO.eDept = dept;
                eDTO.eSalary = sal;
                eDTO.eJoiningDate = JoiningDate;
                eBLL.Create(eDTO);
            }
            else if (option == 2)
            {
                List<EmployeeDTO> eList = eBLL.Update(eDTO);

            }
            else if (option == 3)
            {
                List<EmployeeDTO> eList = eBLL.Delete();

            }
            else if (option == 4)
            {
                List<EmployeeDTO> em = new List<EmployeeDTO>();
                em = eBLL.eGetAll();
                Console.WriteLine("All Employees: ");
                foreach (EmployeeDTO e in em)
                {
                    Console.WriteLine($"{ e.eName} {e.eID} {e.eDept} {e.eJoiningDate} {e.eSalary}");
                }

            }
            else if (option == 5)
            {
                Console.Write("Enter name:");
                string? name = Console.ReadLine();
                Console.Write("Enter ID:");
                int id = int.Parse(Console.ReadLine()!);
                Console.Write("Enter Description:");
                string? desc = Console.ReadLine();
                dDTO.dName = name;
                dDTO.dID = id;
                dDTO.dDesc = desc;
                dBLL.Create(dDTO);
            }
            else if (option == 6)
            {
                List<DepartmentDTO> dList = dBLL.Delete();
            }
            else if (option == 7)
            {
                List<DepartmentDTO> eList = dBLL.Update(dDTO);

            }
            else if (option == 8)
            {
                List<DepartmentDTO> dp = new List<DepartmentDTO>();
                dp = dBLL.dGetAll();
                Console.WriteLine("All Departments: ");
                foreach (DepartmentDTO d in dp)
                {
                    Console.WriteLine($"{d.dName} {d.dID} {d.dDesc}");
                }

            }
            else if(option == 9)
            {
                Console.Write("Enter name: ");
                string? name = Console.ReadLine();
                List<EmployeeDTO>? emDTO = eBLL.SearchByName(name);

                if (emDTO.Count > 0)
                {
                    foreach (var e in emDTO)
                    {
                        Console.WriteLine($"{e.eName}, {e.eID}, {e.eDept}, {e.eJoiningDate}, {e.eSalary}");
                    }
                }
                else
                {
                    Console.WriteLine("No employee found with the given criteria.");
                }

            }
            else if (option == 10)
            {
                Console.Write("Enter id: ");
                string? idInput = Console.ReadLine();
                int? id = string.IsNullOrEmpty(idInput) ? null : int.Parse(idInput);
                List<EmployeeDTO?> emDTO = eBLL.SearchById((int)id);

                if (emDTO.Count > 0)
                {
                    foreach (var e in emDTO)
                    {
                        Console.WriteLine($"{e.eName}, {e.eID}, {e.eDept}, {e.eJoiningDate}, {e.eSalary}");
                    }
                }
                else
                {
                    Console.WriteLine("No employee found with the given criteria.");
                }

            }
            else if (option == 11)
            {
                Console.Write("Enter dept: ");
                string? name = Console.ReadLine();
                List<EmployeeDTO>? emDTO = eBLL.SearchByDept(name);

                if (emDTO.Count > 0)
                {
                    foreach (var e in emDTO)
                    {
                        Console.WriteLine($"{e.eName}, {e.eID}, {e.eDept}, {e.eJoiningDate}, {e.eSalary}");
                    }
                }
                else
                {
                    Console.WriteLine("No employee found with the given criteria.");
                }

            }
            else if (option == 12)
            {
                Console.Write("Enter Joining date: ");
                string? name = Console.ReadLine();
                List<EmployeeDTO>? emDTO = eBLL.SearchByName(name);

                if (emDTO.Count > 0)
                {
                    foreach (var e in emDTO)
                    {
                        Console.WriteLine($"{e.eName}, {e.eID}, {e.eDept}, {e.eJoiningDate}, {e.eSalary}");
                    }
                }
                else
                {
                    Console.WriteLine("No employee found with the given criteria.");
                }

            }
            else if (option == 10)
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                break;
            }
        }

    }
    public static void Main(string[] args)
    {
        Program p = new Program();
        p.input();
        //p.display();
    }
}