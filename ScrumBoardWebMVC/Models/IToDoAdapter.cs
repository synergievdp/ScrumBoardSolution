using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebMVC.Models {
    public interface IToDoAdapter {
        public void Adapt(ToDo from, ToDoViewModel to);
        public void Adapt(ToDoViewModel from, ToDo to);
    }
}
