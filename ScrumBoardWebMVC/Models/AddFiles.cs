using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebMVC.Models {
    public class AddFiles {
        public List<IFormFile> OldFiles { get; set; }
        public List<IFormFile> NewFiles { get; set; }
    }
}
