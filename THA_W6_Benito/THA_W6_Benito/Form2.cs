using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_Benito
{
    public partial class Form2 : Form
    {
        Button[,] buttons;
        int Guess,x, y;
        List<string> wordlist;
        string jawaban;
        string[] qwerty;
        int posisix, posisiy;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string file = "Wordle Word List.txt";
            string[] wordLines = File.ReadAllLines(file);
            wordlist = new List<string>();
            foreach (string wordLine in wordLines)
            {
                wordlist.AddRange(wordLine.Split(','));
            }
            jawaban = wordlist[new Random().Next(wordlist.Count - 1)].ToUpper();
            x = 10;
            y = 10;
            posisix = 0;
            posisiy = 0;    
            Guess = Form1.userinput;
            buttons = new Button[5, Guess];
            for (int i = 0; i <5; i++)
            {
                for (int j = 0; j < Guess; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Tag = i.ToString() + "," + j.ToString();
                    buttons[i, j].Size = new Size(50, 50);
                    buttons[i, j].Location = new Point(x, y);
                    this.Controls.Add(buttons[i, j]);
                    y += 50;
                }
                x += 50;
                y = 10;

            }
            qwerty = new string[28] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L","ENTER", "Z", "X", "C", "V", "B", "N", "M","DELETE" };
            x = 350;
            y = 45;
            
            foreach (string huruf in qwerty)
            {
                Button button = new Button();
                if (huruf == "A")
                {
                    x = 370;
                    y = 105;
                    button.Size = new Size(50, 50);
                    button.Click += jitt;
                }
                else if (huruf == "ENTER")
                {
                    x = 355;
                    y = 165;
                    button.Size = new Size (70,50);
                    button.Click += enterclick;

                }
                else if (huruf == "DELETE")
                {
                    button.Size = new Size(70, 50);
                    button.Click += deleteclick;
                }
                else
                {
                    button.Size = new Size(50, 50);
                    button.Click += jitt;
                }
          
                button.Text = huruf;
                button.Location = new Point (x, y);
                this.Controls.Add(button);
                if (huruf == "ENTER")
                {
                    x += 70;
                }
                else
                {
                    x += 50;
                }
              
            }
            
        }
        private void jitt (object sender , EventArgs e)
        {
            var send = sender as Button;
            if (posisix<=4)
            {
                buttons[posisix, posisiy].Text = send.Text;
                posisix++;
            }
            
        }
        private void enterclick (object sender ,  EventArgs e )
        {
            int jawabanbenar = 0;
            if (posisix != 5)
            {
                MessageBox.Show("Harus 5 Huruf !");
            }
            else
            {
                string kata = "";
                for (int i = 0; i < posisix; i++)
                {
                    kata += buttons[i,posisiy].Text;    
                }
                if (wordlist.Contains(kata.ToLower()))
                {
                    for (int i = 0; i < posisix; i++)
                    {
                        if (jawaban[i].ToString() == (buttons[i,posisiy].Text))
                        {
                            buttons[i,posisiy].BackColor = Color.Green;
                            jawabanbenar++;
                        }
                        else if (jawaban.Contains(buttons[i,posisiy].Text))
                        {
                            buttons[i,posisiy].BackColor = Color.Yellow;   
                        }
                        else
                        {
                            buttons[i,posisiy].BackColor = Color.Black;
                        }
      
                    }
                    posisiy++;
                    posisix = 0;
                    if (jawabanbenar==5)
                    {
                        MessageBox.Show("You Win !");
                    }
                    else if (jawabanbenar<5&&posisiy==Guess)
                    {
                        MessageBox.Show("You Lose !, the answer is "+ jawaban);
                    }
                }
                else
                {
                    MessageBox.Show("Kata tidak ditemukan !");
                }
                  

            }
            
        
        }
        private void deleteclick (object sender , EventArgs e)
        {
           
            if (posisix >0)
            {
                posisix -= 1;
                buttons[posisix, posisiy].Text = "";
            }
        }

    
    }
}
