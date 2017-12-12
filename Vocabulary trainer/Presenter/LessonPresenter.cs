using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocabulary_trainer.Model;
using Vocabulary_trainer.View;

namespace Vocabulary_trainer.Presenter
{
    public class LessonPresenter
    {
        private LessonModel lesson;
        private LessonView view;

        public LessonPresenter()
        {
           

        }
        public LessonPresenter ( LessonModel model, LessonView view)
        {
            this.lesson = model;
            this.view = view;
          
            view.presenter = this;
            

        }
      public string[] getListLesson ()
        {
            string[] files = Directory.GetFiles("../../Ressources", "*.csv");
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]).Replace(".csv","");
            return files;
        }
        public string getPath(string name)
        {
            string s="../../Ressources/"+name+".csv";
            return s;
          
        }
      public List<string>  getcolumnFromFile(string path, int index)
        {
          
          
            // Declare new List.
            List<string> lines = new List<string>();
            string firstcol = string.Empty;
            char delimiter = ';';
            string newlineSperator = Environment.NewLine;
            using (StreamReader reader = new StreamReader(path))
            {
                //StreamReader reader = new StreamReader(path, Encoding.Default);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //string header = reader.ReadLine();
                    string[] headers = line.Split(delimiter);
                    if (headers.Length > 0)
                    {

                        //read first column
                        if (!string.IsNullOrEmpty(headers[index]))
                            lines.Add(headers[index]);
                    }
                }
                reader.Close();
            }
          return lines;

        }
        public List<string> getWordFrom(string path)
        {
            List<string> from =getcolumnFromFile(path,0);
            from.RemoveAt(0);
           return from ;

                    }
         public List<int> getCounts(string path)
        {
            List<string> from =getcolumnFromFile(path,2);
            from.RemoveAt(0);
            List<int> integers = from.ConvertAll(s => Int32.Parse(s));
            
            return integers;

                    }
           public List<string> getWordTo(string path)
        {
            List<string> to =getcolumnFromFile(path,1);
            to.RemoveAt(0);
            return to;
                    }
        public string LanguageFrom(string path)
        {
//   
  

          
            // Declare new List.
            List<string> lines = new List<string>();
            string firstcol = string.Empty;
            char delimiter = ';';
            string newlineSperator = Environment.NewLine;

            StreamReader reader = new StreamReader(path, Encoding.Default);
            if (reader.BaseStream.Position == 0)
            {
                string header = reader.ReadLine();
                string[] headers = header.Split(delimiter);
                if (headers.Length > 0)
                {
                    //read first column
                    if (!string.IsNullOrEmpty(headers[0]))
                       firstcol=headers[0];
                }
            }
            return firstcol;
             

        }
         public string LanguageTo(string path)
        {
               string secondcol = string.Empty;
            char delimiter = ';';
            string newlineSperator = Environment.NewLine;
            StreamReader reader = new StreamReader(path, Encoding.Default);
            
            if (reader.BaseStream.Position == 0)
            {
            string header = reader.ReadLine();
            string[] headers = header.Split(delimiter);
            if (headers.Length > 0)
            {
          
            if (!string.IsNullOrEmpty(headers[0]))
            secondcol = headers[1];
            }
            }
            return secondcol;
        }
        public int updateCount(int number,List<int> list, int index)
         {
             int value = (list.ElementAt(index)) + number;
             return value;
         }
        public string nextWord(List<string> list,int index)
        {
            return list[index];
        }
        public void updateFile(string path, int row, int value)
        {
            //read file 
            string line = "";
            string text = "";
            string[] sFileLines;
            string[] Lines;
            using (StreamReader sr = new StreamReader(path))
            {

                string allData = sr.ReadToEnd();
                sFileLines = allData.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


                sr.Close();

            }
            //write File
            using (StreamWriter sw = new StreamWriter(path))
            {

                line = sFileLines[row];
                string[] tab = line.Split(';');
               
                tab[2] =value.ToString();
               
               
                    line = string.Join(";", tab);
                                sFileLines[row] = line;
                //if (line.Contains("0"))
                //{
                //    var split = line.Split(';');
                //    if (split[2].Contains("0"))
                //    {
                //        split[2] = "100";
                //        line = string.Join(";", split);
                //        sw.WriteLine(line);
                //    }
                //    sw.WriteLine(line);
                //}

                //     if (line.Contains("0"))
                //{
                //    string temp = l;
                //    int start = l.IndexOf(eventName);
                //    temp = temp.Remove(start, eventName.Length);
                //    temp = temp.Insert(start, "dadou");
                //    lines.Add(temp);
                //}
                //else
                //{
                //    lines.Add(l);
                //}
                foreach (string str in sFileLines)
                {
                    sw.WriteLine(str);
                }



                sw.Close();


            }
        }
        public bool IsSuccess (string path)
         {
            int result ;
            List<int> counts = getCounts(path);
              foreach ( int str in counts)
              {
                 
                  if (str<4)
                  { return false;
                }
              }
            return true;
         }

    }
}
