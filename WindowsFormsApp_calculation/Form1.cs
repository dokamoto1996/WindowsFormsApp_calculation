using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_calculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string inputnum;
        string ope;
        float? left;
        float? right;
        float? result;
        bool minus = false;
        bool dot = false;

        /*********************:*-記号，”．”または”0”がクリックされた時の処理*************************************:*/
        private void textBox1_Click(object sender, EventArgs e)
        {
            if ((((Button)sender).Text == "±") || (((Button)sender).Text == ".") || (((Button)sender).Text == "0"))
            {
                if (((Button)sender).Text == "±")       /*―記号がクリックされた時，文字の先頭に着き，連続で表示されない．*/
                {
                    if (minus)
                    {
                        return;
                    }
                    else
                    {
                        inputnum = "-" + inputnum;
                        textBox1.Text = inputnum;
                        minus = true;
                    }
                }

                if (((Button)sender).Text == ".")       /*"."記号がクリックされた時，文字の先頭で表示されず，連続で表示されない．*/
                {
                    if (inputnum == null)               /*何も数字がクリックされない状態で，”．”が押された時*/
                    {
                        dot = true;                     /*自動でドットの前に数字を表示*/
                        return;
                    }

                    if (dot)                            /*”．”がクリックされていたら，もう”．”を表示しない*/
                    {
                        return;
                    }
                    else
                    {
                        inputnum += ((Button)sender).Text;
                        textBox1.Text = inputnum;
                        dot = true;
                    }
                }

                if (((Button)sender).Text == "0")       /*"0"がクリックされた時，文字の先頭で表示されない.*/
                {
                    if ((inputnum == null) && (ope == null))
                    {
                        return;
                    }
                    else
                    {
                        inputnum += ((Button)sender).Text;
                        textBox1.Text = inputnum;
                    }
                }
            }
            else
            {
                if (dot == true && inputnum == null)    /*”．”が押された後に数字がきたら，先頭に0を表示する*/
                {
                    inputnum = "0" + "." + ((Button)sender).Text;
                    textBox1.Text = inputnum;
                    dot = false;
                }
                else                                    /*数字の表示*/
                {
                    inputnum += ((Button)sender).Text;
                    textBox1.Text = inputnum;
                }
            }
        }
        /*********************C,CEボタンがクリックされた時*************************************:*/
        private void button12_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "C")
            {
                textBox1.Text = "0";
                    inputnum = null;
                         ope = null;
                       right = null;
                        left = null;
                      result = null;
                      minus = false;
                        dot = false;
            }
            else
            {
                if (inputnum != null)                                /*初めての演算結果が出る前にCEがクリックされた時*/
                {
                    textBox1.Text = "0";
                        inputnum = null;
                          minus = false;
                            dot = false;
                }
                else                                                /*演算結果が一回でも出た後にCEがクリックされた時*/
                {
                    textBox1.Text = "0";
                        inputnum = null;                 
                          minus = false;
                            dot = false;
                           left = right;                            /*右辺を左辺に代入*/
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /*********************演算子がクリックされた時*************************************:*/
        private void button13_Click_1(object sender, EventArgs e)
        {
            if(left != null)                                       /*左辺に数字があるとき*/
            {
                if(inputnum != null)                               /*数字が入力されているとき*/
                {
                    right = Convert.ToSingle(textBox1.Text);

                    switch (ope)
                    {
                        case "+":
                            result = left + right;
                            break;

                        case "-":
                            result = left - right;
                            break;

                        case "×":
                            result = left * right;
                            break;

                        case "÷":
                            if (inputnum == "0")
                            {
                                MessageBox.Show("0で除算出来ません．", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Text = "0";
                                inputnum = null;
                                ope = null;
                                right = 0;
                                left = 0;
                                result = 0;
                                minus = false;
                                dot = false;
                                return;
                            }
                            else
                            {
                                result = left / right;
                            }
                            break;
                    }
                    textBox1.Text = result.ToString();
                    left = result;
                    inputnum = null;
                    minus = false;
                    dot = false;
                }
                else
                {
                    ope = ((Button)sender).Text;　　　　　　　　　 /*続けて演算子がクリックされた時*/
                }
            }
            else　　　　　　　　　　　　　　　　　　　　　　　　　 /*左辺に数字が無いとき*/
            {
                left = Convert.ToSingle(textBox1.Text);
                           ope = ((Button)sender).Text;
                                       inputnum = null;             
            }
        }

        /*********************＝がクリックされた時*************************************:*/
        private void button17_Click(object sender, EventArgs e)
        {

        }

        public float mass(float left, float right, float result, string ope, string inputnum,　bool minus, bool dot)
        {

        }
    }
}