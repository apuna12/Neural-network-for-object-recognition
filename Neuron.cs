using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neuronka
{
    class Neuron:InputNeuron
    {

        private double[][] _weights;
        private double _input;
        Neuron[][] _prev_layers;
        private double _bias;
        
        

        

        public double Input
        {
            get
            {
                return _input;
            }

            set
            {

                _input = value;

            }
        }

        public Neuron(Neuron[][] neurons)
        { 
            if (neurons != null)
            {
                _prev_layers = neurons;
                Random rnd = new Random();
                double rand;
                _weights = new double[neurons.Length][];
                _bias = rnd.NextDouble();

                for(int i=0;i<neurons.Length;i++)
                {
                    _weights[i] = new double[neurons[i].Length];

                    for (int o = 0; o < neurons[i].Length; o++)
                    {
                        rand = rnd.NextDouble();
                        _weights[i][o] = (rand * 2) - 1;

                    }
                }    
            }
        }


        public void Activate()
        {
            double sum = 0;
            for (int i = 0; i < _prev_layers.Length; i++)
            {
                for (int j = 0; j < _prev_layers[i].Length; j++)
                {
                    sum += _prev_layers[i][j].Output * _weights[i][j];
                }
            }
            sum += _bias;
            Input = sum;
            Output = Sigmoid(Input);
        }


        public double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
