using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGUI
{
    
    public partial class Form1 : Form
    {
        int startX = 10;
        int startY = 10;
        int spaceBetweenPixels = 20;
        char input;
        string ledMovement = "0000";
        int ballPosX = 0;
        int ballPosY = 0;
        int ballPrevPosX;
        int ballPrevPosY;
        int one = 1;
        private Timer timer1;
        bool serialOpen;

        public Form1()
        {
            InitializeComponent();
            InitTimer();

        }
        
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 10; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g_0 = this.panel1.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.Black);
            g_0.FillEllipse(b, startX + ballPrevPosX * spaceBetweenPixels, startY + ballPrevPosY * spaceBetweenPixels, 10, 10);

            b.Color = Color.Green;
            g_0.FillEllipse(b, startX + ballPosX * spaceBetweenPixels, startY + ballPosY * spaceBetweenPixels, 10, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Send Command to the arduino to turn off LED
            serialPort1.Write("a");
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            // Send Command to the arduino to turn on LED
            serialPort1.Write("A");
        }

        public void MoveRight()
        {
            
            if (ballPosX < 9)
            {
                ballPrevPosX = ballPosX;
                ballPrevPosY = ballPosY;
                ballPosX++;
            }
        }
        public void MoveLeft()
        {
            
            if (ballPosX > 0)
            {
                ballPrevPosX = ballPosX;
                ballPrevPosY = ballPosY;
                ballPosX--;
            }
        }
        public void MoveUp()
        {
            
            if (ballPosY > 0)
            {
                ballPrevPosY = ballPosY;
                ballPrevPosX = ballPosX;
                ballPosY--;
            }
        }
        public void MoveDown()
        {
            
            if (ballPosY < 9)
            {
                ballPrevPosY = ballPosY;
                ballPrevPosX = ballPosX;
                ballPosY++;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g_0 = this.panel1.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.Black);
            for(int y=0; y < 10; y++)
            {
                for(int x = 0; x < 10; x++)
                {
                    g_0.FillEllipse(b, startX + x * spaceBetweenPixels, startY + y * spaceBetweenPixels, 10, 10);
                }
                
            }
            
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
