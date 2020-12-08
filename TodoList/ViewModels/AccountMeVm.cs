using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoList.Common.ValidationAttributes;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class AccountMeVm
    {
        public Staff Staff { get; set; }
    }
}
