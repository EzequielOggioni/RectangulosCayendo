using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumerosCayendo
{

    public partial class Form1 : Form
    {
        private delegate void Callback();
        List<Rectangulo> listaRectangunlos;

        List<Thread> hilos;

        public Form1()
        {

            InitializeComponent();
            listaRectangunlos = new List<Rectangulo>();
            hilos = new List<Thread>();
            listaRectangunlos.Add(new Rectangulo(20, 0, 20, 20, Color.Red));
            listaRectangunlos.Add(new Rectangulo(150, 0, 20, 20, Color.Yellow));
            listaRectangunlos.Add(new Rectangulo(80, 0, 20, 20, Color.Blue));

            foreach (var item in listaRectangunlos)
            {
                hilos.Add(new Thread(new ParameterizedThreadStart(Mover)));

            }


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Rectangulo item in listaRectangunlos)
            {
                Pen colorRojo = new Pen(item.Color);
                for (int i = 0; i < 20; i++)
                {
                    e.Graphics.DrawRectangle(colorRojo, item.X + i, item.Y + i,
                        item.Largo - i, item.Alto - i);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listaRectangunlos.Count; i++)
            {
                hilos[i].Start(this.listaRectangunlos[i]);

            }

        }
        private void Mover(object rec)
        {
            Rectangulo rectangulo = (Rectangulo)rec;

            while (rectangulo.Y < this.Height - rectangulo.Alto - 39)
            {
                rectangulo.Y = rectangulo.Y + 6;
                Callback callback = new Callback(this.Refresh);
                this.Invoke(callback);
                Thread.Sleep(100);
            }

            //TODO
            //callback = new Callback(this.perder);
            //this.Invoke(callback);
        }

        private void MoverAuch()
        {
            foreach (Rectangulo item in listaRectangunlos)
            {
                while (item.Y < this.Height - item.Alto - 39)
                {
                    item.Y = item.Y + 1;

                    Callback callback = new Callback(this.Refresh);
                    this.Invoke(callback);

                    Thread.Sleep(10);
                }
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Thread item in hilos)
            {
                if (item.IsAlive)
                    item.Abort();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            for (int i = 0; i < listaRectangunlos.Count; i++)
            {
                Rectangulo item = listaRectangunlos[i];
                if (item.X < e.X && item.X + 20 > e.X)
                {
                    if (item.Y < e.Y && item.Y + 20 > e.Y)
                    {
                        this.hilos[i].Abort();
                    }
                }


            }
        }
    }

}
