using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalculator
{
    public partial class Form1 : Form
    {
        int leftValue = 0, rightValue = 0, result = 0;
        string preOperator = "+";

        public Form1()
        {
            InitializeComponent();
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            rightValue = int.Parse(rightValue.ToString() + btn.Text);
            lblCal.Text = rightValue.ToString();

        }

        //private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        //{
            
        //}

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                int temp = (int)e.KeyCode - 96;

                rightValue = int.Parse(rightValue.ToString() + temp.ToString());
                lblCal.Text = rightValue.ToString();
            }
            else
            {
                if (e.KeyCode == Keys.Add)
                {
                    button16.PerformClick();
                }
                else if (e.KeyCode == Keys.Subtract)
                {
                    button15.PerformClick();
                }
                else if (e.KeyCode == Keys.Multiply)
                {
                    button14.PerformClick();
                }
                else if (e.KeyCode == Keys.Divide)
                {
                    button13.PerformClick();
                }
            }
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            //이전 연산자로 계산
            switch (preOperator)
            {
                case "+":
                    result = leftValue + rightValue;
                    break;
                case "-":
                    result = leftValue - rightValue;
                    break;
                case "*":
                    result = leftValue * rightValue;
                    break;
                case "/":
                    if(rightValue == 0)
                    {
                        MessageBox.Show("0으로 나눌 수 없습니다.");
                        return;
                    }
                    result = leftValue / rightValue;
                    break;
            }
            //이번 연산자를 다음번을 위해서 저장
            Button b1 = (Button)sender;
            preOperator = b1.Text;
            lblCal.Text = result.ToString();
            leftValue = result;
            rightValue = 0;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            lblCal.Text = "";
            leftValue = rightValue = result = 0;
            preOperator = "+";
        }

    }
}
