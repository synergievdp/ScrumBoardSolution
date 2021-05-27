using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebMVC.Models {
    public interface IToDoService {
        IEnumerable<ToDoViewModel> GetAll();
        ToDoViewModel GetById(int id);
        void Insert(ToDoViewModel toDo);
        void Update(ToDoViewModel toDo);
        void Delete(int id);
    }
}
