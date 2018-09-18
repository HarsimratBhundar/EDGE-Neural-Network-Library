using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    public class RecurrentNeuralNetwork
    {
        double S_inital = 0;
        public double[] x { get; set; }
        int TimeSteps { get; set; }
        
        double[]o { get; set; }
        double[]s { get; set; }
        double[]y { get; set; }

        #region training
        double AcceptableError;
        int MaxEpoch;
        double LearningRate;
        #endregion

        ActivationFunction f { get; set; }
        ActivationFunction g { get; set; }

        public RecurrentNeuralNetwork(double[] input, double[] idealSet)
        {
            x = input;
            y = idealSet;
            TimeSteps = input.Count();
            AcceptableError = 4;
            MaxEpoch = 10000;
            LearningRate = 0.01;
        }

        public void InitalizeParameters()
        {
            U = 0;
            V = 0;
            W = 0;
        }

        public void InitalizeActivationFuntion()
        {
            f = new Identity();
            g = new BentIdentity();
        }

        public void InitalizeActivationFuntion(ActivationFunction a)
        {
            f = a;
        }

        public void InitalizeParameters(int u, int v, int w)
        {
            U = u;
            V = v;
            W = w;
        }


        public double GetOutput(int T)
        {
            double[] O = new double[T+1];
            double[] S = new double[T+1];

            for (int t = 0; t <= T; t++)
            {
                if (t == 0)
                {
                    S[t] = f.GetFunction((U * x[t]) + (W * S_inital));
                }

                else
                {
                    S[t] = f.GetFunction((U * x[t]) + (W * S[t-1]));
                }
                O[t] = g.GetFunction(V * S[t]);
            }
            return O[T];
        }

        public double GetState(int T)
        {
            double[] S = new double[T + 1];
            if (T == 0)
            {
                return f.GetFunction((U * x[T]) + (W * S_inital));
            }
            else
            {
                for (int t = 1; t <= T; t++)
                {
                    S[t] = f.GetFunction((U * x[t]) + (W * S[t - 1]));
                }
            }
            return S[T]; 
        }

        public void Train()
        {
            int i = 0;
            double Error = 0;
            do
            {
                o = GetOutputs();
                s = GetStates();
                Error = GetSumSquaredError(o, y);
                double VDelta = 0;
                double UDelta = 0;
                double WDelta = 0;

                VDelta += (y[0]-o[0])* -g.GetDerivative(S_inital * V) * S_inital;
                UDelta += (y[0] - o[0])* -g.GetDerivative(S_inital * V) * V * f.GetDerivative(U*x[0] + W*S_inital)*x[0];
                UDelta += (y[0] - o[0]) * -g.GetDerivative(S_inital * V) * V * f.GetDerivative(U * x[0] + W * S_inital) * S_inital;

                for (int t = 1; t < TimeSteps; t++)
                {
                    VDelta += (y[t] - o[t]) * -g.GetDerivative(s[t] * V) * s[t];
                    UDelta += (y[t] - o[t]) * -g.GetDerivative(s[t] * V) * V * f.GetDerivative(U * x[t] + W * s[t-1]) * x[t];
                    WDelta += (y[t] - o[t]) * -g.GetDerivative(s[t] * V) * V * f.GetDerivative(U * x[t] + W * s[t-1]) * s[t-1];
                }

                VDelta *= -LearningRate;
                UDelta *= -LearningRate;
                WDelta *= -LearningRate;

                V += VDelta;
                U += UDelta;
                W += WDelta;
                i++;
                
            } while (i < MaxEpoch && Error > AcceptableError);
            Console.WriteLine("Training complete in a total #" + i + " iterations and an error of" + Error);
        }

        public double GetOutput()
        {
            return GetOutput(TimeSteps-1);
        }

        public double GetState()
        {
            return GetState(TimeSteps - 1);
        }

        public double[] GetOutputs()
        {
            double[] O = new double[TimeSteps];

            for (int t = 0; t < TimeSteps; t++)
            {
                O[t] = GetOutput(t);
            }
            return O;
        }
        

        public double[] GetStates()
        {
            double[] S = new double[TimeSteps];

            for (int t = 0; t < TimeSteps; t++)
            {
                S[t] = GetState(t);
            }
            return S;

        }

        public double GetMeanError(double[] O, double[] Y)
        {
            double error = 0;
            for(int t = 0; t < O.Length; t++)
            {
                error += O[t] - Y[t];
            }
            return error / O.Length;
        }

        public double GetSumSquaredError(double[] O, double[] Y)
        {
            double error = 0;
            for (int t = 0; t < O.Length; t++)
            {
                error += Math.Pow((O[t] - Y[t]), 2);
            }
            return error / 2;
        }

        public double GetPrediction()
        {
            x = y;
            return GetOutput(TimeSteps - 1);
        }

        public double GetVGradient()
        {
            double Gradient = 1;
            return Gradient;
        }

        double U { get; set; }
        double V { get; set; }
        double W { get; set; }
    }
}
