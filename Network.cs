using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neuronka
{
    class Network
    {
        private Neuron[][] _net;
        private int[] _layers;
        private double _learn_rate;
        private short INPUT_LAYER = 0;

        public int[] Layers
        {
            get
            {
                return _layers;
            }

            set
            {
                if (value.Length >= 2)
                {
                    if (value.Contains(0))
                        throw new SystemException("Wrong parameter inserted");
                    else
                        _layers = value;
                }

                else
                    throw new SystemException("Wrong parameter inserted");

            }
        }

        public Network(int[] layers, double learning_rate)
        {
            Layers = layers;
            _learn_rate = learning_rate;
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
                throw new SystemException(e.ToString());
            }
        }

        public double[] Run(double[] inputData)
        {
            double[] ret = new double[_net[Layers.Length - 1].Length];
            try
            {
                for (int i = 0; i < inputData.Length; i++)
                {
                    _net[INPUT_LAYER][i].Output = inputData[i];
                }
                for (int i = 1; i < Layers.Length; i++)
                {
                    for (int j = 0; j < Layers[i]; j++)
                    {
                        _net[i][j].Activate();
                        
                    }
                }



            }
            catch(Exception e)
            {
                throw new SystemException(e.ToString());
            }

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = _net[Layers.Length - 1][i].Output;
            }

            return ret;
        }
    }
}
