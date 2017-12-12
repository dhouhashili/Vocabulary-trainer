using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulary_trainer.Model
{
   public class LessonModel
    {
        public string languageFrom { get; set; }
        public string languageTo { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public List<int> count { get; set; }
        public List<string> WordFrom { get; set; }
        public List<string> WordTo { get; set; }





    }
}
