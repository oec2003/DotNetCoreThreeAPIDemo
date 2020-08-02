using ExceptionDemo.Models;

namespace ExceptionDemo.Repositories
{
    public interface IDeptRepository
    {
        Dept GetDeptById(int id);
    }
}