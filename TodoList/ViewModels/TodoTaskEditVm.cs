using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoTaskEditVm
    {
        public TodoTask TodoTask { get; set; }
        public SelectList StaffSelectList { get; set; }
        public int[] TodoTaskPartnerIds { get; set; }
    }
}