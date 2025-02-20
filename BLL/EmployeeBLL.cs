using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class EmployeeBLL
    {
        public void Create(EmployeeDTO em)
        {
            EmployeeDAL e = new EmployeeDAL();
            e.Create(em);
        }
        public List<EmployeeDTO> Update(EmployeeDTO em)
        {
            em.eSalary = updateSalary();
            EmployeeDAL e = new EmployeeDAL();
            return e.Update(em);
        }
        private float updateSalary()
        {
            Console.Write("Enter new Salary:");
            float s = int.Parse(Console.ReadLine());
            return s;
        }
        public List<EmployeeDTO> Delete()
        {
            EmployeeDAL e = new EmployeeDAL();
            return e.Delete();
        }

        public List<EmployeeDTO> eGetAll()
        {
            EmployeeDAL e = new EmployeeDAL();
            return e.eGetAll();
        }
       
        public List<EmployeeDTO?> SearchByName(string? name)
        {
            EmployeeDAL e = new EmployeeDAL();
            return e.Search(name: name);
        }
        public List<EmployeeDTO?> SearchById(int? id)
        {
            EmployeeDAL e = new EmployeeDAL();
            return e.Search(id: id);
        }
        public List<EmployeeDTO?> SearchByDept(string? deptName)
        {
            EmployeeDAL e = new EmployeeDAL();
            return e.Search(deptName: deptName);
        }
        public List<EmployeeDTO?> SearchByJoiningDate(string? joiningDate)
        {
            EmployeeDAL e = new EmployeeDAL();
            return e.Search(joiningDate: joiningDate);
        }
    }
    
}
