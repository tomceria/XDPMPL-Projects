using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetComments(TodoTask todoTask);
        Comment CreateComment(string content, TodoTask todoTask, Staff staff);
        void AddComment(Comment comment);
    }
}