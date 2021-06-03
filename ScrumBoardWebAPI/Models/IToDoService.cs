using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebAPI.Models {
    public interface IToDoService {
        IEnumerable<ToDoModel> GetAll();
        ToDoModel GetById(int id);
        void Insert(ToDoModel toDo);
        void Update(ToDoModel toDo);
        void Delete(int id);
    }
}
