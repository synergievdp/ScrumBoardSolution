using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Models {
    public class File {
        public int Id { get; set; }
        public string Path { get; set; }
        public ToDo ToDo { get; set; }
    }
}
