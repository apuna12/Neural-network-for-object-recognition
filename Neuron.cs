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

        private double[] _weights;
        private double _input;
        Neuron[] _prev_layer;

        

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

        public Neuron(Neuron[] neurons)
        { 
            if (neurons != null)
            {
                _prev_layer = neurons;
                Random rnd = new Random();
                double rand;
                _weights = new double[neurons.Length + 1];
                int len = _weights.Length;

                for(int o = 0; o < len; o++)
                {
                    rand = rnd.NextDouble();
                    _weights[o] = (rand * 2) - 1;
                }
            }
        }


        public void Activate()
        {
            double sum = 0;
            for (int i = 0; i < _prev_layer.Length; i++)
            {
                sum += _prev_layer[i].Output * _weights[i];
                
            }
            sum += _weights[_weights.Length-1];
            Input = sum;
            Output = Sigmoid(Input);
        }


        public double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
