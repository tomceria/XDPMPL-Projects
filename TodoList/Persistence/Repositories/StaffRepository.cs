using TodoList.Data;
using TodoList.Models;
using TodoList.Persistence.Interfaces;

namespace TodoList.Persistence.Repositories
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        protected TodoContext Context => DbContext as TodoContext;
        
        public StaffRepository(TodoContext context) : base(context)
        {
        }
    }
}