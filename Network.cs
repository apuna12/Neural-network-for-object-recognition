using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuronka
{
    class Network
    {
        private Neuron[][] _net;
        private int[] _layers;
        private double _learn_rate;

        public int[] Layers
        {
            get
            {
                return _layers;
            }

            set
            {
                if (_layers.Length >= 2)
                {
                    if(_layers.Contains(0))
                        throw new System.ArgumentException("Parameter should not have 0 in layers", "original");
                    else
                        _layers = value;
                }

                else
                    throw new System.ArgumentException("Parameter should have at least 2 elements", "original");

            }
        }

        public Network(int[] layers, double learning_rate)
        {
            Layers = layers;
            _net = new Neuron[layers.Length][];

            try
            {

                for (int i = 0; i < layers.Length; i++)
                {
                    _net[i] = new Neuron[layers[i]];


                    for (int j = 0; j < layers[i]; j++)
                    {
                        if (i == 0)
                        {
                            _net[i][j] = new Neuron(null);
                        }


                        else
                        {
                            _net[i][j] = new Neuron(_net[i - 1]);
                        }
                    }

                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Run(double[] inputData)
        {
            try
            {
                for (int i = 0; i < inputData.Length; i++)
                {
                    _net[0][i].Output = inputData[i];
                }
                for (int i = 0; i < Layers.Length; i++)
                {
                    for (int j = 0; j < Layers[i]; j++)
                    {
                        _net[i][j].Activate();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
