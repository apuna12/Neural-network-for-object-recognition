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
            double[,] firstWeights = new double[4,2];
            double[] firstTresh = new double[4];
            double[,] firstOutput = new double[4, 2];
            int[] help = new int[2];
            int[] desiredOutput = { 0, 1, 1, 0 };
            double[,,] firstHiddenLayer = new double[2, 4, 2];
            double[,,] secondHiddenLayer = new double[2, 4, 2];


            Random rnd = new Random();

            double[] weights = new double[hiddenLayers + 1];
            for (int i=0;i<4;i++)
            {
                firstTresh[i] = rnd.NextDouble();
                for (int j=0; j<2; j++)
                {
                    firstWeights[i, j] = (rnd.NextDouble()) * 2 - 1;                   
                    firstOutput[i, j] = input[i, j] * firstWeights[i, j] * firstTresh[i];
                }
            }

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 4; i++)
                {

                    for (int j = 0; j < 2; j++)
                    {
                        firstHiddenLayer[k, i, j] = Sigmoid(firstOutput[i, j]);
                    }

                }
            }

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 4; i++)
                {

                    for (int j = 0; j < 2; j++)
                    {
                        secondHiddenLayer[k, i, j] = Sigmoid(firstHiddenLayer[k, i, j]);
                    }

                }
            }


            int a = 5;


        }

        public double Sigmoid (double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }


    }
}
