using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    /// <summary>
    /// Class PerceptronLayer; defines the sturcture of a perceptron layer
    /// </summary>
    public class PerceptronLayer : Layer
    {

        public override Node[] Nodes
        {
            get
            {
                return Perceptrons;
            }
        }

        /// <summary>
        /// The perceptrons in the perceptron layer
        /// </summary>
        protected Perceptron[] Perceptrons
        {
            get;
            set;
        }


        public int LayerSize
        {
            get
            {
                return Perceptrons.Length;
            }
        }

        /// <summary>
        /// Default constructor; creates an instance of an empty perceptron layer
        /// </summary>
        public PerceptronLayer()
        {
            Perceptrons = new Perceptron[0];
        }

        /// <summary>
        /// Constructor; cretes an instance of a perceptron layer with argument defined input size and perceptron count
        /// </summary>
        /// <param name="InputSize"></param>
        /// <param name="PerceptronCount"></param>
        public PerceptronLayer(int InputSize, int PerceptronCount)
        {
            Perceptrons = new Perceptron[PerceptronCount];
            for(int IndexNumber = 0; IndexNumber < PerceptronCount; IndexNumber++)
            {
                this[IndexNumber] = new Perceptron(InputSize);
            }
        }

        /// <summary>
        /// Initalises the parameters of all perceptrons with argument defined weight and bias values
        /// </summary>
        /// <param name="WeightValue">The argument defined weight value.</param>
        /// <param name="BiasValue">The argument defined bias value.</param>
        public void Initalize(double WeightValue, double BiasValue)
        {
            for(int IndexNumber = 0; IndexNumber < Perceptrons.Length; IndexNumber++)
            {
                this[IndexNumber].Bias = BiasValue;
                for(int WeightNumber = 0; WeightNumber < this[IndexNumber].Weights.Length; WeightNumber++)
                {
                    this[IndexNumber].Weights[WeightNumber] = WeightValue;
                }
            }
        }

        /// <summary>
        /// Intialises the parameters of all perceptrons pseudo-randomly
        /// </summary>
        public void IntializeRandom()
        {
            Random Randomizer = new Random();
            for (int IndexNumber = 0; IndexNumber < Perceptrons.Length; IndexNumber++)
            {
                this[IndexNumber].Bias = Randomizer.NextDouble();
                for (int WeightNumber = 0; WeightNumber < this[IndexNumber].Weights.Length; WeightNumber++)
                {
                    this[IndexNumber].Weights[WeightNumber] = Randomizer.NextDouble();
                }
            }
        }

        /// <summary>
        /// Returns the outputs for the layer for an argument defined set of inputs
        /// </summary>
        /// <param name="Inputs">The argument defined set of inputs</param>
        /// <returns></returns>
        public virtual double[] GetOutputs(double[] Inputs)
        {
            double[] Outputs = new double[Perceptrons.Length];
            for(int IndexNumber = 0; IndexNumber < Perceptrons.Length; IndexNumber++)
            {
                Outputs[IndexNumber] = this[IndexNumber].GetOutput(Inputs);
            }
            return Outputs;
        }

        /// <summary>
        /// Returns the derivative outputs for the layer for an argument defined set of inputs
        /// </summary>
        /// <param name="Inputs">The argument defined set of inputs</param>
        /// <returns></returns>
        public double[] GetDerivatives(double[] Inputs)
        {
            double[] Derivatives = new double[Perceptrons.Length];
            for (int IndexNumber = 0; IndexNumber < Perceptrons.Length; IndexNumber++)
            {
                Derivatives[IndexNumber] = this[IndexNumber].GetDerivativeOutput(Inputs);
            }
            return Derivatives;
        }

        /// <summary>
        /// Gets or Sets a specific argument defined Perceptron in the layer
        /// </summary>
        /// <param name="IndexNumber"></param>
        /// <returns></returns>
        public Perceptron this[int IndexNumber]
        {
            get
            {
                return Perceptrons[IndexNumber];
            }

            set
            {
                Perceptrons[IndexNumber] = value;
            }
        }
    }
}
