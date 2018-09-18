using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    public class InputLayer : PerceptronLayer
    {
        public InputLayer(int InputSize, int PerceptronCount)
        {
            Perceptrons = new Perceptron[PerceptronCount];
            for (int IndexNumber = 0; IndexNumber < PerceptronCount; IndexNumber++)
            {
                this[IndexNumber] = new Perceptron(InputSize, 0);
                this[IndexNumber].Weights = new double[InputSize];
            }
        }

        public override double[] GetOutputs(double[] Inputs)
        {
            return Inputs;
        }
    }
}