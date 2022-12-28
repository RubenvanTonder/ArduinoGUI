using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGUI
{
    public partial class Form1 : Form
    {
        char input;
        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
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
            Console.WriteLine("Hello World");
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
                textBox1.Text = input.ToString();
                textBox1.BackColor = Color.Black;
            }
            
        }
    }
}
