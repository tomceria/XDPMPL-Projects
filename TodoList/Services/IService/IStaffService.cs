using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllStaffs();
    }
}