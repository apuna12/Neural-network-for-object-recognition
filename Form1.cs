using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neuronka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hiddenLayers = 2;
            int neuronsInHiddenLayers = 5;
            int inputNeurons = 2;
            int outputNeurons = 1;
            List<int[]> training = new List<int[]>();

            int[] inputA = { 0, 0, 1, 1 };
            int[] inputB = { 0, 1, 0, 1 };
            int[,] input = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
            int[] desiredOutput = { 0, 1, 1, 0 };
            Random rnd = new Random();

            


            int a = 5;


        }



    }
}
