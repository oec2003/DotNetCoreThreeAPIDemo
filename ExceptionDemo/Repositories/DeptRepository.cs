using System.Collections.Generic;
using ExceptionDemo.Models;

namespace ExceptionDemo.Repositories
{
    public class DeptRepository:IDeptRepository
    {
        private List<Dept> _depts = new List<Dept>()
        {
            new Dept() {Id = 1, Name = "产品部"}
        };


        public Dept GetDeptById(int id)
        {
            return _depts.Find(x => x.Id == id);
        }
    }
}