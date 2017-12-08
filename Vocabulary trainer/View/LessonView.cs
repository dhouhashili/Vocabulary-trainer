using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vocabulary_trainer.Presenter;

namespace Vocabulary_trainer.View
{
    public partial class LessonView : Form
    {
        public LessonPresenter presenter { get; set; }
        public  LessonView()
        {
          
            InitializeComponent();
        }
        //public LessonView(LessonPresenter presenter)
        //{
        //    this.presenter = presenter;
        //    InitializeComponent();
        //}

        private void LessonView_Load(object sender, EventArgs e)
        {
           
            string[] lessons = presenter.getListLesson();
            foreach (string name in lessons)
            {
                listBox1.Items.Add(name);
              
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex != -1)
            {
                string path = presenter.getPath(listBox1.SelectedItem.ToString());
                if (presenter.IsSuccess(path))
                {
                    string success = "Congratulations. You successfully finished the lesson.";

                    listBox1.Visible = false;
                    label2.Visible = false;
                    button2.Visible = true;
                    label1.Text = success;
                    label1.Font = new Font("Arial", 9, FontStyle.Bold);
                    button1.Visible = false;
                }
                else
                {
                    this.Hide();
                    WordView word = new WordView(listBox1.SelectedItem.ToString());

                    word.ShowDialog();
                    this.Close();
                }

            }
            else { label2.ForeColor = System.Drawing.Color.Red; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            label1.Text = "";
            button2.Visible = false;
            InitializeComponent();
            string[] lessons = presenter.getListLesson();
            foreach (string name in lessons)
            {
                listBox1.Items.Add(name);

            }
        }
    }
}
