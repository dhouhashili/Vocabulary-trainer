using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vocabulary_trainer.Model;
using Vocabulary_trainer.Presenter;
using Vocabulary_trainer.View;

namespace Vocabulary_trainer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /**model**/
            LessonModel modellesson = new LessonModel();
           

            /**view***/
            LessonView viewlesson = new LessonView();
            WordView word = new WordView();
            /**presenter**/
            LessonPresenter presenterlesson = new LessonPresenter(modellesson, viewlesson);

            Application.Run(viewlesson);
        }
    }
}
