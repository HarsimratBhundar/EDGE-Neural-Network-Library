using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    public class Backpropagation : TrainingMethod
    {

        public double AcceptableError
        {
            get;
            set;
        }

        public double LearningRate
        {
            get;
            set;
        }

        public int MaxEpoch
        {
            get;
            set;
        }

        public double[] IdealOutputs
        {
            get;
            set;
        }

        public double[] TrainingInputsSet
        {
            get;
            set;
        }

        private double DefaultAcceptableError
        {
            get
            {
                return 0.1;
            }
        }

        private double DefaultLearningRate
        {
            get
            {
                return 0.7;
            }
        }

        private int DefaultMaxEpoch
        {
            get
            {
                return 100;
            }
        }

        public Backpropagation()
        {
            AcceptableError = DefaultAcceptableError;
            LearningRate = DefaultLearningRate;
            MaxEpoch = DefaultMaxEpoch;
        }

        public override void Train(NeuralNetwork<TrainingMethod> TargetNetwork)
        {
            int Epoch = -1;
            Network = TargetNetwork;

            int OutputCount = Network.OutputSize;

            double[] Outputs = new double[OutputCount];
            double[] OutputLayerDerivatives = new double[OutputCount];
            double[] Error = new double[OutputCount];
            double[] OutputLayerDeltaValues = new double[OutputCount];

            double[][] DeltaValues = new double[Network.Layers.Length][];

            double AverageError = 0;

            do
            {
                Outputs = Network.GetOutputs(TrainingInputsSet);
                OutputLayerDerivatives = Network.GetDerivatives(TrainingInputsSet, OutputCount - 1);

                for (int IndexNumber = 0; IndexNumber < OutputCount; IndexNumber++)
                {
                    Error[IndexNumber] = Outputs[IndexNumber] - IdealOutputs[IndexNumber];
                    OutputLayerDeltaValues[IndexNumber] = Error[IndexNumber] * OutputLayerDerivatives[IndexNumber];
                    AverageError += Error[IndexNumber];
                }
                AverageError /= OutputCount;

                DeltaValues[Network.Layers.Length - 1] = OutputLayerDeltaValues;

                for (int NodeNumber = 0; NodeNumber < OutputCount; NodeNumber++)
                {
                    for (int WeightNumber = 0; WeightNumber < Network.Layers[Network.Layers.Length - 1].Nodes[NodeNumber].Weights.Length; WeightNumber++)
                    {
                        double Gradient = OutputLayerDeltaValues[NodeNumber] * Network.GetOutputs(TrainingInputsSet, Network.Layers.Length - 2)[WeightNumber];

                        Network.Layers[Network.Layers.Length - 1].Nodes[NodeNumber].Weights[WeightNumber] -= Gradient * LearningRate;
                        Network.Layers[Network.Layers.Length - 1].Nodes[NodeNumber].Bias -= Gradient * OutputLayerDeltaValues[NodeNumber];
                    }
                }

                for(int LayerNumber = Network.Layers.Length - 2; LayerNumber > 0; LayerNumber--)
                {
                    DeltaValues[LayerNumber] = new double[Network.Layers[LayerNumber].Nodes.Length];
                    for (int WeightNumber = 0; WeightNumber < Network.Layers[LayerNumber].Nodes.Length; WeightNumber++)
                    {
                        double Sigma = 0;
                        for(int NodeNumber = 0; NodeNumber < Network.Layers[LayerNumber + 1].Nodes.Length; NodeNumber++)
                        {
                            Sigma += DeltaValues[LayerNumber + 1][NodeNumber] * Network.Layers[LayerNumber + 1].Nodes[NodeNumber].Weights[WeightNumber];
                        }
                        double DeltaValue = Network.GetDerivatives(TrainingInputsSet, LayerNumber)[WeightNumber] * Sigma;
                        DeltaValues[LayerNumber][WeightNumber] = DeltaValue;
                    }

                    for (int NodeNumber = 0; NodeNumber < Network.Layers[LayerNumber].Nodes.Length; NodeNumber++)
                    {
                        for(int WeightNumber = 0; WeightNumber < Network.Layers[LayerNumber].Nodes[NodeNumber].Weights.Length; WeightNumber++)
                        {
                            double Gradient = DeltaValues[LayerNumber][NodeNumber] * Network.GetOutputs(TrainingInputsSet, LayerNumber - 1)[WeightNumber];
                            Network.Layers[LayerNumber].Nodes[NodeNumber].Weights[WeightNumber] -= Gradient * LearningRate;
                            Network.Layers[LayerNumber].Nodes[NodeNumber].Bias -= DeltaValues[LayerNumber][NodeNumber] * LearningRate;
                        }
                    }
                }
                Epoch++;
            } while (Epoch < MaxEpoch && Math.Abs(AverageError) > AcceptableError);
        }
    }
}
