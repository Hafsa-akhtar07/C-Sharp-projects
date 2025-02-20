using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DepartmentBLL
    {
        public void Create(DepartmentDTO dp)
        {
            DepartmentDAL d = new DepartmentDAL();
            d.Create(dp);
        }
        public List<DepartmentDTO> Update(DepartmentDTO dp)
        {
            dp.dDesc = updateDesc();
            DepartmentDAL e = new DepartmentDAL();
            return e.Update(dp);
        }
        private string updateDesc()
        {
            Console.Write("Enter new Salary:");
            string s = Console.ReadLine();
            return s;
        }
        public List<DepartmentDTO> Delete()
        {
            DepartmentDAL d = new DepartmentDAL();
            return d.Delete();
        }
        public List<DepartmentDTO> dGetAll()
        {
            DepartmentDAL dp = new DepartmentDAL();
            return dp.dGetAll();
        }

    }

}
