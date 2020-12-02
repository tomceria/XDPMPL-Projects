using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.IService;

namespace TodoList.Services
{
    public class CommentService : ICommentService
    {
        private readonly TodoContext _context;

        public CommentService(TodoContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Comment>> GetComments(TodoTask todoTask)
        {
            var comments =
               await (
                   from comment in _context.Comments
                   where comment.Id == todoTask.Id
                   select comment
               ).ToListAsync();

            return comments;
        }

        public Comment CreateComment(string content, TodoTask todoTask, Staff staff)
        {
            Comment comment = new Comment
            {
                Content = content,
                TodoTaskId = todoTask.Id,
                StaffId = staff.Id
            };

            return comment;
        }

        public void AddComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Added;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}