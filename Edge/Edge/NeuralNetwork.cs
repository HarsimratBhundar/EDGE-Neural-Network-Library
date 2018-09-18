using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    public class NeuralNetwork<TrainingTechnique> where TrainingTechnique : TrainingMethod
    {
        public virtual int OutputSize
        {
            get
            {
                return 0;
            }
        }
       
        public virtual Layer[] Layers
        {
            get;
            set;
        }

        public virtual double[] GetOutputs(double[] Inputs)
        {
            return Inputs;
        }

        public virtual double[] GetOutputs(double[] Inputs, int LayerNumber)
        {
            return Inputs;
        }

        public virtual double[] GetDerivatives(double[] Inputs)
        {
            return Inputs;
        }

        public virtual double[] GetDerivatives(double[] Inputs, int LayerNumber)
        {
            return Inputs;
        }

        public virtual void Train()
        {
        }

        public virtual void Initalize()
        {
        }
    }
}
