using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuronka
{
    class Neuron
    {

        private double[] _weights;
        private double _input;
        private double _output;
        Neuron[] _prev_layer;

        public double Output
        {
            get
            {
                return _output;
            }

            set
            {
                if(value < 0 || value > 1)
                {
                    throw new System.ArgumentException("Parameter is out of bond", "original");
                }
                else
                {
                    _output = value;
                }
            }
        }

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
                _weights = new double[neurons.Length + 1];
                int len = _weights.Length;
                for (int i = 0; i < len; i++)
                {
                    neurons[i]._weights[i] = (rnd.NextDouble()) * 2 - 1;
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
