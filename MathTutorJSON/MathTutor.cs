using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathTutorJSON
{
    public partial class MathTutor : Form
    {
        private string operation = "add";
        private int level = 1;
        private Equation currentEquation;
        private HttpClient service = new HttpClient();
        public MathTutor()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string jsonString = await service.GetStringAsync(new Uri("http://localhost:55482/EquationGeneratorService.svc/equation/"+operation+"/"+level));
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Equation));
            currentEquation =
                (Equation)jsonSerializer.ReadObject(new MemoryStream(Encoding.Unicode.GetBytes(jsonString)));
            Console.WriteLine(jsonString + currentEquation.Result);
            label1.Text = currentEquation.LeftHandSide;
            button1.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text))
            {

                if (currentEquation.Result == Convert.ToInt32(textBox1.Text))
                {
                    label1.Text = string.Empty;
                    textBox1.Clear();
                    button1.Enabled = false;
                    MessageBox.Show("Correct!!");
                }
                else
                {
                    MessageBox.Show("Incorrect");
                }
                }
            }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                operation = "add";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                operation = "subtract";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                operation = "multiply";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked)
            {
                level = 1;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                level = 2;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                level = 3;
            }
        }
    }
    
}
