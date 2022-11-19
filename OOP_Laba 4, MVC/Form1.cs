﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Laba_4__MVC
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observers += new System.EventHandler(this.UpdateFromModel);
        }
        private void UpdateFromModel(object sender, EventArgs e)
        {
            textBox1.Text = model.getValue_A().ToString();
            numericUpDown1.Value = model.getValue_A();
            trackBar1.Value = model.getValue_A();

            textBox2.Text = model.getValue_B().ToString();
            numericUpDown2.Value = model.getValue_B();
            trackBar2.Value = model.getValue_B();

            textBox3.Text = model.getValue_C().ToString();
            numericUpDown3.Value = model.getValue_C();
            trackBar3.Value = model.getValue_C();

        }

        

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.setValue_A(Decimal.ToInt32(numericUpDown1.Value));
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.setValue_B(Decimal.ToInt32(numericUpDown2.Value));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            model.setValue_C(Decimal.ToInt32(numericUpDown3.Value));
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model.setValue_A(Decimal.ToInt32(trackBar1.Value));
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            model.setValue_B(Decimal.ToInt32(trackBar2.Value));
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            model.setValue_C(Decimal.ToInt32(trackBar3.Value));
        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValue_A(Int32.Parse(textBox1.Text));
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValue_B(Int32.Parse(textBox2.Text));
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValue_C(Int32.Parse(textBox3.Text));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.saveValues();
        }
    }
    public class Model
    {
        private int A;
        private int B;
        private int C;

        public System.EventHandler observers;

        public void setValue_A(int value)
        {
            if(value > C)
            {
                int temp = C;
                C = value;
                A = temp;
            }
            if(value > B)
            {
                A = value;
                B = value;
            }
            else
            {
                A = value;
            }
                
            observers.Invoke(this, null);
        }

        public void setValue_B(int value)
        {
            if (A > B | B > C) 
            {
                MessageBox.Show("Введите 'B' правильно!");
                B = A;
            }
            else
                B = value;
            observers.Invoke(this, null);
        }

        public void setValue_C(int value)
        {
            if (A > value)
            {
                A = C;
                C = value;
            }
            if(value < B)
            {
                C = value;
                B = value;
            }
            else
            {
                C = value;
            }
            observers.Invoke(this, null);
        }

        public int getValue_A()
        {
            return A;
        }

        public int getValue_B()
        {
            return B;
        }

        public int getValue_C()
        {
            return C;
        }
        public void saveValues()
        {

        }

    }
}
