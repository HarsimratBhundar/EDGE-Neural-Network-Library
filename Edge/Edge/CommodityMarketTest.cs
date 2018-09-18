using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    public class CommodityMarketTest
    {
        public void RunTest()
        {
            double[] TestInputs = { 1.12, 0.99, -1.44, -0.29, 0.41, -1.41 };
            double[] TestOutputs = { 0.99, -1.44, -0.29, 0.41, -1.41, -0.84 };

            RecurrentNeuralNetwork r = new RecurrentNeuralNetwork(TestInputs, TestOutputs);
            r.InitalizeParameters(1, 1, 1);
            r.InitalizeActivationFuntion();
            r.Train();
            double []o = r.GetOutputs();
            for (int i = 0; i < o.Length; i++)
            {
                Console.WriteLine(o[i]);
            }

            Console.WriteLine("The prediction = " + r.GetPrediction());
        }
    }
}
