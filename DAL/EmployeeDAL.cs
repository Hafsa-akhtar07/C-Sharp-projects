using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DTO;

namespace DAL
{
    public class EmployeeDAL
    {
        public List<EmployeeDTO> Create(EmployeeDTO em)
        {
            if (!File.Exists("Employees.txt"))
            {
                using (StreamWriter sw = new StreamWriter("Employees.txt")) { }
            }

            List<EmployeeDTO> list = new List<EmployeeDTO>();
            using (StreamReader sr = new StreamReader("Employees.txt"))
            {
                string? info = sr.ReadLine();
                while (info != null)
                {
                    string[] ans = info.Split(",");
                    EmployeeDTO e = new EmployeeDTO
                    {
                        eName = ans[0],
                        eID = int.Parse(ans[1]),
                        eDept = ans[2],
                        eJoiningDate = ans[3],
                        eSalary = int.Parse(ans[4])
                    };
                    list.Add(e);
                    info = sr.ReadLine();
                }
            }

            bool idExists = false;
            foreach (var e in list)
            {
                if (e.eID == em.eID)
                {
                    idExists = true; 
                    break;
                }
            }

            if (!idExists)
            {
                list.Add(em);

                using (StreamWriter sw = new StreamWriter("Employees.txt", true))
                {
                    sw.WriteLine($"{em.eName},{em.eID},{em.eDept},{em.eJoiningDate},{em.eSalary}");
                }
                Console.WriteLine("Employee added successfully!");
            }
            else
            {
                Console.WriteLine("Error: Employee ID already exists.");
            }

            return list;
        }


        public List<EmployeeDTO> Update(EmployeeDTO em)
        {
            StreamReader s = new StreamReader("Employees.txt");
            Console.Write("Enter Employee ID to update salary: ");
            int id = int.Parse(Console.ReadLine());
            string? info = s.ReadLine();
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            bool isUpdated = false;

            while (info != null)
            {
                string[] ans = info.Split(",");
                EmployeeDTO e = new EmployeeDTO
                {
                    eName = ans[0],
                    eID = int.Parse(ans[1]),
                    eDept = ans[2],
                    eJoiningDate = ans[3],
                    eSalary = int.Parse(ans[4])
                };

                if (e.eID == id)
                {
                    e.eSalary = em.eSalary;
                    isUpdated = true;
                }

                list.Add(e);
                info = s.ReadLine();
            }
            s.Close();

            using (StreamWriter st = new StreamWriter("Employees.txt"))
            {
                foreach (var emp in list)
                {
                    st.WriteLine($"{emp.eName},{emp.eID},{emp.eDept},{emp.eJoiningDate},{emp.eSalary}");
                }
            }

            if (isUpdated)
            {
                Console.WriteLine("Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Sorry! Invalid ID.");
            }

            return list;
        }


        public List<EmployeeDTO> Delete()
        {
            StreamReader s = new StreamReader("Employees.txt");
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            string? info = s.ReadLine();
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            bool isDeleted = false;

            while (info != null)
            {
                string[] ans = info.Split(",");
                EmployeeDTO e = new EmployeeDTO
                {
                    eName = ans[0],
                    eID = int.Parse(ans[1]),
                    eDept = ans[2],
                    eJoiningDate = ans[3],
                    eSalary = int.Parse(ans[4])
                };

                if (e.eID != id)
                {
                    list.Add(e);
                }
                else
                {
                    isDeleted = true;
                }

                info = s.ReadLine();
            }
            s.Close();
            if (isDeleted)
            {
                using (StreamWriter st = new StreamWriter("Employees.txt"))
                {
                    foreach (var emp in list)
                    {
                        st.WriteLine($"{emp.eName},{emp.eID},{emp.eDept},{emp.eJoiningDate},{emp.eSalary}");
                    }
                }
                Console.WriteLine("Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Sorry! Invalid ID.");
            }

            return list;
        }


        public List<EmployeeDTO> eGetAll()
        {
            StreamReader s = new StreamReader("Employees.txt");
            string? info = s.ReadLine();
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            while (info != null)
            {
                string[] ans = info.Split(",");
                EmployeeDTO e = new EmployeeDTO();

                e.eName = ans[0];
                e.eID = int.Parse(ans[1]);
                e.eDept = ans[2];
                e.eJoiningDate = ans[3];
                e.eSalary = int.Parse(ans[4]);
                list.Add(e);
                info = s.ReadLine();

            }
            s.Close();
            return list;

        }
        public List<EmployeeDTO> Search(string? name = null, int? id = null, string? deptName = null, string? joiningDate = null)
        {
            List<EmployeeDTO> matchingEmployees = new List<EmployeeDTO>(); 
            using StreamReader s = new StreamReader("Employees.txt");
            string? info;

            while ((info = s.ReadLine()) != null)
            {
                string[] ans = info.Split(",");
                if (ans.Length >= 5)
                {
                    EmployeeDTO e = new EmployeeDTO
                    {
                        eName = ans[0],
                        eID = int.Parse(ans[1]),
                        eDept = ans[2],
                        eJoiningDate = ans[3],
                        eSalary = int.Parse(ans[4])
                    };

                    bool matches = true;
                    if (name != null && e.eName.ToLower() != name.ToLower()) matches = false;
                    if (id != null && e.eID != id) matches = false;
                    if (deptName != null && e.eDept.ToLower() != deptName.ToLower()) matches = false;
                    if (joiningDate != null && e.eJoiningDate != joiningDate) matches = false;

                    if (matches)
                    {
                        matchingEmployees.Add(e); 
                    }
                }
            }

            return matchingEmployees; 
        }


    }

}
