using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    class Program
    {
        static void Main(string[] args)
        {
            CommodityMarketTest c = new CommodityMarketTest();
            c.RunTest();
            Console.ReadLine();
            /*/test
            FeedForwardNetwork<Backpropagation> Test = new FeedForwardNetwork<Backpropagation>();
            Backpropagation test = new Backpropagation();

            double[] Inputs = { 0.71, 0.41, 0.42, 1.05 };
            double[] IdealOutputs = { 0.7 };

            test.IdealOutputs = IdealOutputs;
            test.TrainingInputsSet = Inputs;

            Test.TrainingStrategy = test;

            Test.PerceptronLayers = new PerceptronLayer[3];

            Test.PerceptronLayers[0] = new InputLayer(4, 4);
            
            Test.PerceptronLayers[1] = new PerceptronLayer(4, 4);
            Test.PerceptronLayers[1].Initalize(0.3, 0);

            Test.PerceptronLayers[2] = new PerceptronLayer(4, 1);
            Test.PerceptronLayers[2].Initalize(0.3, 0);
            

            Test.Train();
            Console.WriteLine(Test.GetOutputs(Inputs)[0]);
            Console.ReadLine();
            */
        }
    }
}
