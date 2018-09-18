using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    /// <summary>
    /// Class Perceptron, defines the structure of a perceptron.
    /// </summary>
    public class Perceptron : Node
    {
        ///The parameters of the Perceptron
        #region Parameters
        /// <summary>
        /// The values for the synaptic weights in the perceptron
        /// </summary>
        public override double[] Weights
        {
            get;
            set;
        }

        /// <summary>
        /// The bias value for the perceptron
        /// </summary>
        public override double Bias
        {
            get;
            set;
        }
        #endregion
        /// <summary>
        /// The Activation Function used by the perceptron
        /// </summary>
        public ActivationFunction TransferFunction
        {
            get;
            set;
        }


        /// <summary>
        /// The input size for the perceptron which is parallel to the number of weight values
        /// </summary>
        public int InputSize
        {
            get
            {
                return Weights.Length;
            }
        }

        /// <summary>
        /// Default constructor; creates an instance of type perceptron with default properties
        /// </summary>
        public Perceptron()
        {
            Weights = new double[0];
            Bias = 0;
            TransferFunction = new SoftSign();
        }

        /// <summary>
        /// Constructor; creates an instance of type perceptron with an argument defined input size
        /// </summary>
        /// <param name="InputSize">The argument defined input size</param>
        public Perceptron(int InputSize)
        {
            Weights = new double[InputSize];
            Bias = 0;
            TransferFunction = new SoftSign();
        }

        /// <summary>
        /// Constructor; createsan instance of type perceptron with argument defined input size and bias value
        /// </summary>
        /// <param name="InputSize">The argument defined input size</param>
        /// <param name="BiasValue">The argument defined bias value</param>
        public Perceptron(int InputSize, double BiasValue)
        {
            Weights = new double[InputSize];
            Bias = BiasValue;
            TransferFunction = new SoftSign();
        }

        /// <summary>
        /// Constructor; creates an instance of type perceptron with argument defined input size, bias value and Activation Function
        /// </summary>
        /// <param name="InputSize">The argument defined input size</param>
        /// <param name="BiasValue">The argument defined bias value</param>
        /// <param name="Activation">The argument defined activation function</param>
        public Perceptron(int InputSize, double BiasValue, ActivationFunction Activation)
        {
            Weights = new double[InputSize];
            Bias = BiasValue;
            TransferFunction = Activation;
        }

        /// <summary>
        /// Retrurns the output for a given set of argument defined inputs
        /// </summary>
        /// <param name="Inputs">The argument defined set of inputs</param>
        /// <returns></returns>
        public double GetOutput(double[] Inputs)
        {
            double WeightInputSigma = 0;
            for(int IndexNumber = 0; IndexNumber < InputSize; IndexNumber++)
            {
                WeightInputSigma += Weights[IndexNumber] * Inputs[IndexNumber];
            }
            return TransferFunction.GetFunction(WeightInputSigma + Bias);
        }

        /// <summary>
        /// Retrurns the derivative output for a given set of argument defined inputs
        /// </summary>
        /// <param name="Inputs">The argument defined set of inputs</param>
        /// <returns></returns>
        public double GetDerivativeOutput(double[] Inputs)
        {
            double WeightInputSigma = 0;
            for (int IndexNumber = 0; IndexNumber < InputSize; IndexNumber++)
            {
                WeightInputSigma += Weights[IndexNumber] * Inputs[IndexNumber];
            }
            return TransferFunction.GetDerivative(WeightInputSigma + Bias);
        }
    }
}
