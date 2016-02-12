using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Main : Form
    {
        Random randomizer = new Random();

        int timeLeft;

        int addend1;
        int addend2;

        public Main()
        {
            InitializeComponent();
        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            return addend1 + addend2 == sum.Value;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right", "Congratulations!");
                startButton.Enabled = true;
            }
            timeLabel.Text = --timeLeft + " seconds";
            if (timeLeft > 0) return;
            timer1.Stop();
            timeLabel.Text = "Time's up!";
            MessageBox.Show("You didn't finish in time!", "Sorry!");
            sum.Value = addend1 + addend2;
            startButton.Enabled = true;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (null != answerBox) 
                answerBox.Select(0, answerBox.Value.ToString().Length);            
        }
    }
}
