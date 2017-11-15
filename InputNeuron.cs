using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neuronka
{
    class InputNeuron
    {
        public double _output;

        public double Output
        {
            get
            {
                return _output;
            }

            set
            {
                if (value < 0 || value > 1)
                    throw new SystemException("Wrong parameter inserted");
                else
                    _output = value;
            }
        }

        public InputNeuron()
        {

        }
    }
}
