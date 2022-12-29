using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGUI
{
    
    public partial class Form1 : Form
    {
        int spriteStartPosX=50;
        int spriteStartPosY=50;
        int ballPosX = 0;
        int ballPosY = 0;
        int rectHeight;
        int rectWidth;
        public Bitmap bmp;
        int one = 1;
        private Timer timer1;
        bool serialOpen;
        int moveX;
        int moveY;

        int[,] enemy = { { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 } ,
                         { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                         { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                         { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                         { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                         { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                         { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                         { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 } };
        int enemyRowLength;
        int enemyColumnLength;

        public Form1()
        {
            InitializeComponent();
            InitTimer();
            bmp = new Bitmap(panel1.Width, panel1.Height);
            enemyRowLength = enemy.GetLength(0);
            enemyColumnLength = enemy.GetLength(1);


        }
        public void drawSprite(int[,] sprite)
        {

        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bmp.Dispose();
            bmp = new Bitmap(panel1.Width, panel1.Height);
            enemyRowLength = enemy.GetLength(0);
            enemyColumnLength = enemy.GetLength(1);
            panel1.BackgroundImage = (Image)bmp;
            panel1.BackgroundImageLayout = ImageLayout.None;

            for (int i = 0; i < panel1.Height; i++)
            {
                for (int j = 0; j < panel1.Width; j+=10)
                {
                    if ((panel1.Width - j) > 10)
                    {
                        bmp.SetPixel(j, i, Color.Black);
                        bmp.SetPixel(j + 1, i, Color.Black);
                        bmp.SetPixel(j + 2, i, Color.Black);
                        bmp.SetPixel(j + 3, i, Color.Black);
                        bmp.SetPixel(j + 4, i, Color.Black);
                        bmp.SetPixel(j + 5, i, Color.Black);
                        bmp.SetPixel(j + 6, i, Color.Black);
                        bmp.SetPixel(j + 7, i, Color.Black);
                        bmp.SetPixel(j + 8, i, Color.Black);
                        bmp.SetPixel(j + 9, i, Color.Black);
                    }

                }
            }
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i < enemyRowLength; i++)
                {
                    for (int j = 0; j < enemyColumnLength; j++)
                    {
                        if (enemy[i, j] == 1)
                        {
                            bmp.SetPixel(j + spriteStartPosX+20*k, i + spriteStartPosY, Color.Red);
                        }
                    }
                }
            }
            spriteStartPosX++;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Send Command to the arduino to turn off LED
            drawSprite(enemy);
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            // Send Command to the arduino to turn on LED
            serialPort1.Write("A");
        }

        public void MoveRight()
        {
            
        }
        public void MoveLeft()
        {
                
        }
        public void MoveUp()
        {
               
        }
        public void MoveDown()
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void blinkButton_Click(object sender, EventArgs e)
        {
            MoveRight();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            MoveLeft();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            MoveUp();
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            MoveDown();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (serialOpen == false)
            {
                serialPort1.Open();
                statusLabel.Text = "Connect";
                statusLabel.ForeColor = Color.Green;
                serialOpen = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (serialOpen == true)
            {
                serialPort1.Close();
                statusLabel.Text = "Disconnect";
                statusLabel.ForeColor = Color.Red;
                serialOpen = false;
            }
        }
    }
}
