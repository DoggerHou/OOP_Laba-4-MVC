using System;
using System.IO;
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
            model.observers.Invoke(this, null);
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



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//при закрытии формы
        {
            model.saveValues();
        }

        private void Form1_Load(object sender, EventArgs e)//при открытии формы
        {
            model.getValues();
        }
    }

    public class Model
    {
        private int A;
        private int B;
        private int C;

        public System.EventHandler observers;
        public Model()
        {
            StreamReader get = new StreamReader("Values.txt");
            A = Int32.Parse(get.ReadLine());
            B = Int32.Parse(get.ReadLine());
            C = Int32.Parse(get.ReadLine());
            get.Close();
        }
        public void setValue_A(int value)
        {
            A = value;
            if(value > B)
            {
                B = value;
                if(value > C) 
                    C = value;
            }
            observers.Invoke(this, null);
        }

        public void setValue_B(int value)
        {
            if ((A > value) && (value < C))
                B = A;
            else
            {
                if (value > C)
                    B = C;
                if ((A <= value) && (value <= C))
                    B = value;
            }
            observers.Invoke(this, null);
        }

        public void setValue_C(int value)
        {
            C = value;
            if (B > value)
                B = value;
            if (A > B)
                A = B;
            observers.Invoke(this, null);
        }

        public int getValue_A() {   return A;   }
        public int getValue_B() {   return B;   }
        public int getValue_C() {   return C;   }
        public void saveValues()//сохраняем Values в файл
        {
            StreamWriter save = new StreamWriter("Values.txt", false);
            save.WriteLine(A);
            save.WriteLine(B);
            save.WriteLine(C);
            save.Flush();

        }
        public void getValues()//Читаем Values из файла
        {
            StreamReader get = new StreamReader("Values.txt");
            A = Int32.Parse(get.ReadLine());
            B = Int32.Parse(get.ReadLine());
            C = Int32.Parse(get.ReadLine());
            observers.Invoke(this, null);
            get.Close();
        }
    }
}
