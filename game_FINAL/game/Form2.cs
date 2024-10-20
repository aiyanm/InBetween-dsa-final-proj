
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.CodeDom;


namespace game
{
    public partial class Form2 : Form
    {
        // Create ng bagong last input copy
        int last_input_copy = 0;


         int randomIndex;
        //private int targetNumber = 20;
         int numberofGuesses = 0;
         int difficulty;
        Form1 difficultyForm;
        Target_Numbers targetNumbers;
       
        public Form2()
        {
            InitializeComponent();
            InitializeGuessLabels();



        }

        List<System.Windows.Forms.Label> resultLabels;
        int counter = 0;

        private void Form2_Load(object sender, EventArgs e)
        {
            // Random index 

            // Difficulty Invoke
            difficultyForm = new Form1();
            difficultyForm.ShowDialog();

            difficulty = difficultyForm.Difficulty;

            // Target_Number Class
            targetNumbers = new Target_Numbers();

            Random random = new Random();
            randomIndex = random.Next(1, targetNumbers.ListofTargetNums[difficulty].Count());
            resultLabels = new List<System.Windows.Forms.Label>();

            resultLabels.Add(label6);
            resultLabels.Add(label7);
            resultLabels.Add(label8);
            resultLabels.Add(label9);
            resultLabels.Add(label10);




        }

        private void InitializeGuessLabels()
        {
            for (int i = 1; i <= 5; i++)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Text = i.ToString();
                textBox1.Clear();
                this.Controls.Add(label);

            }
        }


        public void verify_input_num(int userGuess)
        {
            numberofGuesses++;
            if (numberofGuesses <= 5)
            {
                string LabelText = $"Guess {numberofGuesses}: {userGuess}";
                textBox1.Clear();
                this.Controls.Find($"Label{numberofGuesses}", true)[0].Text = LabelText;
            }

            if (userGuess < targetNumbers.ListofTargetNums[difficulty][randomIndex])
            {
                DisplayMessage("Higher", Color.DarkBlue);

            }
            else if (userGuess > targetNumbers.ListofTargetNums[difficulty][randomIndex])
            {
                DisplayMessage("Lower", Color.OrangeRed);
            }

            else if (userGuess == targetNumbers.ListofTargetNums[difficulty][randomIndex])
            {
                // show dialog para play again or back to menu
                DisplayMessage("Correct", Color.Green);
                button10.Enabled = false;
                MessageBox.Show("Congratulations! you have guessed the correct number.");
                Form grats = new Form6();
                grats.ShowDialog();

            }

            if (numberofGuesses == 5 && userGuess != targetNumbers.ListofTargetNums[difficulty][randomIndex])
            {
                //show dialog para try again or back to menu
                MessageBox.Show("The number was " + targetNumbers.ListofTargetNums[difficulty][randomIndex], "You Lose ,Try Again");
                this.Close();
                Form menu = new Form3();
                menu.ShowDialog();
            }

            last_input_copy = userGuess;
        }

        private void buttonGuess_Click(object sender, EventArgs e)
        {
            // Create if para check yung input muna bago verification
          //  ans.Text = targetNumbers.ListofTargetNums[difficulty][randomIndex].ToString();

            if (int.TryParse(textBox1.Text, out int userGuess))
            {
               
                {

                    numberofGuesses++;
                
                    if (numberofGuesses <= 5)
                    {
                        string LabelText = $"Guess {numberofGuesses}: {userGuess}";
                        textBox1.Clear();
                        this.Controls.Find($"Label{numberofGuesses}", true)[0].Text = LabelText;
                    }

                    if (userGuess < targetNumbers.ListofTargetNums[difficulty][randomIndex])
                    {
                        DisplayMessage("Higher", Color.DarkBlue);

                    }
                    else if (userGuess > targetNumbers.ListofTargetNums[difficulty][randomIndex])
                    {
                        DisplayMessage("Lower", Color.OrangeRed);

                    }

                    else if (userGuess == targetNumbers.ListofTargetNums[difficulty][randomIndex])
                    {
                        DisplayMessage("Correct", Color.Green);
                        button10.Enabled = false;
                        MessageBox.Show("Congratulations! you have guessed the correct number.");
                        this.Close();
                        Form grats = new Form6();
                        grats.ShowDialog();

                    }

                   if (numberofGuesses == 5 && userGuess != targetNumbers.ListofTargetNums[difficulty][randomIndex])
                    {
                        MessageBox.Show("The number was " + targetNumbers.ListofTargetNums[difficulty][randomIndex], "You Lose");
                        this.Close();
                        Form menu = new Form3();
                        menu.ShowDialog();
                    }

              

                    last_input_copy = userGuess;


                }
            }
        }


        private void DisplayMessage(string message, Color color)
        {

            if (counter < 6)
            {


                resultLabels[counter].Text = message;
                resultLabels[counter].ForeColor = color;

                counter++;

            }

        }


        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            if (button != null)
            {
                textBox1.Text += button.Text;
            }


        }


        private void button10_Click(object sender, EventArgs e)
        {
            buttonGuess_Click(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        /*  DI PA NEED 
         *  private void ResetForm()
           {
               // Reset elements as needed
               textBox1.Clear();
               foreach (var label in resultLabels)
               {
                   label.Text = string.Empty;
                   label.ForeColor = SystemColors.ControlText; // Reset label color
               }

               numberofGuesses = 0;
               last_input_copy = 0;
               counter = 0;
          **/


    }
}

