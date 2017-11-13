using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                double rand;
                //double[] _vahy = new double[neurons.Length + 1];
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
            MessageBox.Show(Output.ToString() + " ciastkovy sum v aktivacii");
        }


        public double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
