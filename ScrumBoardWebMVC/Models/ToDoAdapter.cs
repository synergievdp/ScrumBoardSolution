using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebMVC.Models {
    public class ToDoAdapter : IToDoAdapter {
        public void Adapt(ToDo from, ToDoViewModel to) {
            foreach(var toProp in to.GetType().GetProperties()) {
                var fromProp = from.GetType().GetProperty(toProp.Name);

                if(fromProp != null)
                    toProp.SetValue(to, fromProp.GetValue(from));
            }
        }

        public void Adapt(ToDoViewModel from, ToDo to) {
            foreach (var toProp in to.GetType().GetProperties()) {
                var fromProp = from.GetType().GetProperty(toProp.Name);

                if(fromProp != null)
                    toProp.SetValue(to, fromProp.GetValue(from));
            }
        }
    }
}
