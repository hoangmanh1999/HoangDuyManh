using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MicrosoftNews.Model.News;

namespace MicrosoftNews.Model
{
   public class MenuItem
    {
        public string IconFile { get; set; }
        public NewsCategory Category { get; set; }
    }
}
