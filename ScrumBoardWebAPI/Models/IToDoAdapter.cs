using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebAPI.Models {
    public interface IToDoAdapter {
        public void Adapt(ToDo from, ToDoModel to);
        public void Adapt(ToDoModel from, ToDo to);
    }
}
