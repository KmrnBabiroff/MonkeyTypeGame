using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonkeyTypeGame
{
    public partial class Form2 : Form
    {
        private System.Windows.Forms.Timer timer;
        private double timeRemaining;
        private int score;
        public Form2()
        {
            InitializeComponent();


            InitializeGame();

            textBox1.KeyPress += textBox1_KeyPress;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void InitializeGame()
        {
            StartRound();
        }

        private void StartRound()
        {
            Random rnd = new Random();
            string currentText = "";

            switch (GameData.Mode)
            {
                case GameMode.WordOnly:
                    currentText = GameData.Words[rnd.Next(GameData.Words.Count)];
                    break;
                case GameMode.SentencesOnly:
                    currentText = GameData.Sentences[rnd.Next(GameData.Sentences.Count)];
                    break;
                case GameMode.Both:
                    currentText = GameData.All[rnd.Next(GameData.All.Count)];
                    break;
            }

            textBox1.Clear();
            textBox2.Text = currentText;

            timeRemaining = 15;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += TimerElapsed;
            timer.Start();
        }

        private void CloseForm2()
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            timeRemaining -= 0.1;

            if (timeRemaining <= 0)
            {
                timer.Stop();
                MessageBox.Show("Time's up!");
                CloseForm2();
            }
            else
            {
                label1.Invoke((MethodInvoker)delegate {
                    label1.Text = $"{timeRemaining.ToString("0.0")}";
                });
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CheckAnswer();
            }
        }

        private void CheckAnswer()
        {
            if (textBox1.Text == textBox2.Text)
            {
                score += 3;
                label2.Text = $"{score}";
                timer.Stop();
                StartRound();
            }
        }

    }

}
