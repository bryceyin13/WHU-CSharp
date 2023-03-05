using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hw0.a2_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                double num1 = Convert.ToDouble(textBox1.Text);
                double num2 = Convert.ToDouble(textBox2.Text);
                double res = 0;
                switch (comboBox1.Text)
                {
                    case "+":
                        res = num1 + num2;
                        label1.Text = Convert.ToString(res);
                        break;
                    case "-":
                        res = num1 - num2;
                        label1.Text = Convert.ToString(res);
                        break;
                    case "*":
                        res = num1 * num2;
                        label1.Text = Convert.ToString(res);
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            label1.Text = "Please input a correct operand. ";
                        }
                        else
                        {
                            res = num1 / num2;
                            label1.Text = Convert.ToString(res);
                        }
                        break;
                    default:
                        label1.Text = "Please input a correct operator. ";
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Something is wrong with your input.","Warning");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
