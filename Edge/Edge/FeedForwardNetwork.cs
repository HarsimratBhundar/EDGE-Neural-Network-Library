using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    public class FeedForwardNetwork<TrainingTechnique> : NeuralNetwork<TrainingMethod> where TrainingTechnique : TrainingMethod
    {
        public TrainingTechnique TrainingStrategy
        {
            get;
            set;
        }

        public override Layer[] Layers
        {
            get
            {
                return PerceptronLayers;
            }
        }

        public PerceptronLayer[] PerceptronLayers
        {
            get;
            set;
        }

        public override int OutputSize
        {
            get
            {
                return PerceptronLayers[PerceptronLayers.Length - 1].LayerSize;
            }
        }



        public override double[] GetDerivatives(double[] Inputs)
        {
            double[] Derivatives = Inputs;
            for (int IndexNumber = 0; IndexNumber < PerceptronLayers.Length; IndexNumber++)
            {
                Derivatives = PerceptronLayers[IndexNumber].GetDerivatives(Derivatives);
            }
            return Derivatives;
        }

        public override double[] GetDerivatives(double[] Inputs, int LayerNumber)
        {
            double[] Derivatives = Inputs;
            for (int IndexNumber = 0; IndexNumber < LayerNumber; IndexNumber++)
            {
                Derivatives = PerceptronLayers[IndexNumber].GetOutputs(Derivatives);
            }

            return PerceptronLayers[LayerNumber].GetDerivatives(Derivatives);
        }

        public override double[] GetOutputs(double[] Inputs)
        {
            double[] Outputs = Inputs;
            for (int IndexNumber = 0; IndexNumber < PerceptronLayers.Length; IndexNumber++)
            {
                Outputs = PerceptronLayers[IndexNumber].GetOutputs(Outputs);
            }
            return Outputs;
        }

        public override double[] GetOutputs(double[] Inputs, int LayerNumber)
        {
            double[] Outputs = Inputs;

            for (int IndexNumber = 0; IndexNumber < LayerNumber; IndexNumber++)
            {
                Outputs = PerceptronLayers[IndexNumber].GetOutputs(Outputs);
            }
            return PerceptronLayers[LayerNumber].GetOutputs(Inputs);
        }

        public override void Initalize()
        {
            for(int IndexNumber = 0; IndexNumber < PerceptronLayers.Length; IndexNumber++)
            {
                this[IndexNumber].IntializeRandom();   
            }
        }

        public void Initalize(double WeightValue, double BiasValue)
        {
            for (int IndexNumber = 0; IndexNumber < PerceptronLayers.Length; IndexNumber++)
            {
                this[IndexNumber].Initalize(WeightValue, BiasValue);
            }
        }

        public override void Train()
        {
            TrainingStrategy.Train(this);
        }

        public PerceptronLayer this[int IndexNumber]
        {
            get
            {
                return PerceptronLayers[IndexNumber];
            }
            set
            {
                PerceptronLayers[IndexNumber] = value;
            }
        }
    }
}
