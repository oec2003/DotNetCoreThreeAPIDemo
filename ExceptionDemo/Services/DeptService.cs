using ExceptionDemo.Common.CustomerException;
using ExceptionDemo.Models;
using ExceptionDemo.Repositories;

namespace ExceptionDemo.Services
{
    public class DeptService:IDeptService
    { 
        private readonly IDeptRepository  _deptRepository;

        public DeptService(IDeptRepository deptRepository)
        {
            _deptRepository = deptRepository;
        }
        public string GetDeptName(int id)
        {
            Dept dept=_deptRepository.GetDeptById(id);
            if (dept == null)
            {
                throw new DeptNotFoundException($"部门 Id  为 {id} 的部门不存在");
            }

            return dept.Name;
        }
    }
}