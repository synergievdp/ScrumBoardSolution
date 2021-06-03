using Microsoft.AspNetCore.Http;
using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebAPI.Models {
    public class ToDoAdapter : IToDoAdapter {
        public void Adapt(ToDo from, ToDoModel to) {
            foreach (var toProp in to.GetType().GetProperties()) {
                var fromProp = from.GetType().GetProperty(toProp.Name);

                if (fromProp != null && fromProp.PropertyType == toProp.PropertyType)
                    toProp.SetValue(to, fromProp.GetValue(from));
                
                //if (fromProp.Name == nameof(from.Files)) {
                //    foreach (var file in from.Files) {
                //        if (!to.Files.Any(f => f.FileName == Path.GetFileName(file.Path))) {
                //            if (System.IO.File.Exists(file.Path)) {
                //                using (var fileStream = System.IO.File.OpenRead(file.Path)) {
                //                    to.Files.Add(new FormFile(fileStream, 0, fileStream.Length, nameof(to.Files), Path.GetFileName(file.Path)));
                //                }
                //            }
                //        }
                //    }
                //}
            }
        }

        public void Adapt(ToDoModel from, ToDo to) {
            foreach (var toProp in to.GetType().GetProperties()) {
                var fromProp = from.GetType().GetProperty(toProp.Name);

                if (fromProp != null && fromProp.PropertyType == toProp.PropertyType)
                    toProp.SetValue(to, fromProp.GetValue(from));

                //if (fromProp.Name == nameof(from.Files)) {
                //    foreach (var file in from.Files) {
                //        if (!to.Files.Any(f => Path.GetFileName(f.Path) == file.FileName)) {
                //            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                //            var path = Path.Combine(dir, file.FileName);
                //            if (!Directory.Exists(dir))
                //                Directory.CreateDirectory(dir);
                //            if (!System.IO.File.Exists(path)) {
                //                using (var stream = System.IO.File.Create(path)) {
                //                    file.CopyTo(stream);
                //                }
                //            }
                //            to.Files.Add(new ScrumBoard.Models.File() {
                //                Path = path,
                //                ToDo = to
                //            });
                //        }
                //    }
                //}
            }
        }
    }
}
