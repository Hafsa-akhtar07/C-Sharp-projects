using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DepartmentDAL
    {
        public void Create(DepartmentDTO d)
        {
            StreamWriter s = new StreamWriter("Department.txt", true);
            string data = $"{d.dName},{d.dID},{d.dDesc}";
            s.WriteLine(data);
            s.Close();
        }
        public List<DepartmentDTO> Delete()
        {
            StreamReader s = new StreamReader("Employees.txt");
            StreamReader w = new StreamReader("Department.txt");

            Console.Write("Enter Department name to delete: ");
            string dept = Console.ReadLine();

            string? empInfo = s.ReadLine();
            string? deptInfo = w.ReadLine();

            List<EmployeeDTO> list = new List<EmployeeDTO>();
            List<DepartmentDTO> lst = new List<DepartmentDTO>();

            bool isEmployeeDeleted = false;
            bool isDepartmentDeleted = false;

            while (empInfo != null)
            {
                string[] st = empInfo.Split(",");

                EmployeeDTO e = new EmployeeDTO
                {
                    eName = st[0],
                    eID = int.Parse(st[1]),
                    eDept = st[2],
                    eJoiningDate = st[3],
                    eSalary = int.Parse(st[4])
                };

                if (e.eDept != dept)
                {
                    list.Add(e);
                }
                else
                {
                    isEmployeeDeleted = true;
                }

                empInfo = s.ReadLine();
            }
            s.Close();

            while (deptInfo != null)
            {
                string[] d = deptInfo.Split(",");

                DepartmentDTO x = new DepartmentDTO
                {
                    dName = d[0],
                    dID = int.Parse(d[1]),
                    dDesc = d[2]
                };

                if (x.dName != dept)
                {
                    lst.Add(x);
                }
                else
                {
                    isDepartmentDeleted = true;
                }

                deptInfo = w.ReadLine();
            }
            w.Close();

            if (isEmployeeDeleted)
            {
                using (StreamWriter empWriter = new StreamWriter("Employees.txt"))
                {
                    foreach (var emp in list)
                    {
                        empWriter.WriteLine($"{emp.eName},{emp.eID},{emp.eDept},{emp.eJoiningDate},{emp.eSalary}");
                    }
                }
            }

            if (isDepartmentDeleted)
            {
                using (StreamWriter deptWriter = new StreamWriter("Department.txt"))
                {
                    foreach (var y in lst)
                    {
                        deptWriter.WriteLine($"{y.dName},{y.dID},{y.dDesc}");
                    }
                }
            }

            if (isEmployeeDeleted && isDepartmentDeleted)
            {
                Console.WriteLine("Deleted department and its associated employees successfully!");
            }
            else if (!isDepartmentDeleted)
            {
                Console.WriteLine("Sorry! No matching department found.");
            }
            else
            {
                Console.WriteLine("No employees found for the specified department, but the department was deleted.");
            }
            return lst;
        }

        public List<DepartmentDTO> Update(DepartmentDTO dp)
        {
            StreamReader s = new StreamReader("Department.txt");
            Console.Write("Enter Department ID to update salary: ");
            int id = int.Parse(Console.ReadLine());
            string? info = s.ReadLine();
            List<DepartmentDTO> list = new List<DepartmentDTO>();
            bool isUpdated = false;

            while (info != null)
            {
                string[] ans = info.Split(",");
                DepartmentDTO d = new DepartmentDTO
                {
                    dName = ans[0],
                    dID = int.Parse(ans[1]),
                    dDesc = ans[2]
                };

                if (d.dID == id)
                {
                    d.dDesc = dp.dDesc;
                    isUpdated = true;
                }

                list.Add(d);
                info = s.ReadLine();
            }
            s.Close();

            using (StreamWriter st = new StreamWriter("department.txt"))
            {
                foreach (var emp in list)
                {
                    st.WriteLine($"{emp.dName},{emp.dID},{emp.dDesc}");
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

        public List<DepartmentDTO> dGetAll()
        {
            StreamReader s = new StreamReader("Department.txt");
            string? info = s.ReadLine();
            List<DepartmentDTO> list = new List<DepartmentDTO>();
            while (info != null)
            {
                string[] ans = info.Split(",");
                DepartmentDTO d = new DepartmentDTO();

                d.dName = ans[0];
                d.dID = int.Parse(ans[1]);
                d.dDesc = ans[2];
                list.Add(d);
                info = s.ReadLine();

            }
            s.Close();
            return list;

        }

    }
}
