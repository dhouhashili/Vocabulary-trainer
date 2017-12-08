using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vocabulary_trainer.Model;
using Vocabulary_trainer.Presenter;

namespace Vocabulary_trainer.View
{
    public partial class WordView : Form
    {

        public LessonModel modellesson = new LessonModel();
        public LessonPresenter presenter = new LessonPresenter();
         public int number = 0;
         public int right = 0;
         public int error = 0;
         public int total = 0;
        public WordView()
        {
            InitializeComponent();
        }
        public WordView(string name )
        {
          
            InitializeComponent();
            modellesson.name=name;
        }


        private void WordView_Load(object sender, EventArgs e)
        {

            loadComponent();
        
        }

        public void  loadComponent()
        { modellesson.path = presenter.getPath(modellesson.name);
            groupBox1.Text = presenter.LanguageFrom(modellesson.path);
            groupBox2.Text = presenter.LanguageTo(modellesson.path);
            label4.Text = modellesson.name;
            modellesson.WordFrom = presenter.getWordFrom(modellesson.path);
            modellesson.WordTo = presenter.getWordTo(modellesson.path);
            modellesson.count = presenter.getCounts(modellesson.path);
            if(modellesson.count[number]==4)
            { number++; }
            label3.Text = modellesson.WordFrom[number];}
        

        private void verifybutton_Click(object sender, EventArgs e)
        {

            //correct answer
            if (textBox1.Text.toUpperCase().Equals(modellesson.WordTo[number].toUpperCase()))
                {
                    right++;
                    total++;
                    pictureBox1.Image = Image.FromFile("../../Ressources/yes.gif");
                    
                    //changeIcon("../../Ressources/yes.gif");
                    WaitNSeconds(2);
                    int c= presenter.updateCount(1, modellesson.count, number);
                    presenter.updateFile(presenter.getPath(modellesson.name), number+1, c);
            }
               // wrong answer
            else
            {
                error++;
                total++;
                int c = presenter.updateCount(-1, modellesson.count, number);
                presenter.updateFile(presenter.getPath(modellesson.name), number + 1, c);
                pictureBox1.Image = Image.FromFile("../../Ressources/no.gif");

                //changeIcon("../../Ressources/no.gif");
                WaitNSeconds(2);
            }
            nextword();
            pictureBox1.Image = Image.FromFile("../../Ressources/thinking.gif");
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LessonView lessonview = new LessonView();
            LessonPresenter lesson = new LessonPresenter(modellesson, lessonview);



            lessonview.ShowDialog();
            this.Close();
        }


        private void WaitNSeconds(int segundos)
        {
            if (segundos < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(segundos);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        private void nextword()
        {
            
            if (modellesson.WordFrom.Count() != number+1)
            {
               
                number++;
                if (modellesson.count[number] == 4)
                { number++; }
                if (modellesson.WordFrom.Count() >= number + 1)
                {
                    label3.Text = modellesson.WordFrom[number];
                    textBox1.Text = "";
                }
                else
                {
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    label4.Visible = false;
                    label5.Visible = true;
                    button2.Visible = true;
                    label5.Text = "Total:" + total + ",correct:" + right + ",wrong:" + error;

                }

            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                label4.Visible = false;
                label5.Visible=true;
                button2.Visible = true;
                label5.Text = "Total:"+total+",correct:"+right+",wrong:"+error;
               
            }
        }

    }
}
