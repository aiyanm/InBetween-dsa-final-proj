using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TitleBarHelpButton();
        }
        private int difficulty;

        Form2 guessForm;
        public int Difficulty
        {
            get { return difficulty; }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            guessForm = new Form2();
        }

        private void easyBtn_Click(object sender, EventArgs e)
        {
            difficulty = 0;
            this.Close();
            

        }

        private void mediumBtn_Click(object sender, EventArgs e)
        {
            difficulty = 1;
            this.Close();

            
        }

        private void hardBtn_Click(object sender, EventArgs e)
        {
            difficulty = 2;
            this.Close();
            //guessForm.ShowDialog();
        }

        public void TitleBarHelpButton()
        {
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.HelpButtonClicked += ShapedForm1_HelpButtonClicked;
            this.easyBtn.HelpRequested += easyBtn_help;
            this.easyBtn.HelpRequested += easyBtn_help;
            this.mediumBtn.HelpRequested += mediumBtn_help;
            this.hardBtn.HelpRequested += HardBtn_help;
        }

        private void ShapedForm1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Do you need help?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void easyBtn_help(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Guess a number between 1-20");
        }
        private void mediumBtn_help(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Guess a number between 1-50");
        }
        private void HardBtn_help(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Guess a number between 1-100","Hard huh?");
        }
    }
}
