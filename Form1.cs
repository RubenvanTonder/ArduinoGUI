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
        int ballStartPosX = 0;
        int ballStartPosY = 0;
        int one = 1;
        private Timer timer1;

        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
            InitTimer();
 
        }
        
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g_0 = this.panel1.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.Green);

            g_0.FillEllipse(b, startX + ballStartPosX * spaceBetweenPixels, startY + ballStartPosY * spaceBetweenPixels, 10, 10);
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
            ballStartPosX++;


        }

        private void blinkButton_Click(object sender, EventArgs e)
        {
            serialPort1.Write("b");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("t");
            Read();
        }
        public void Read()
        {
            input = (char)serialPort1.ReadChar();
            if ( input == 'H') {
                Console.WriteLine(input);

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
    }
}
