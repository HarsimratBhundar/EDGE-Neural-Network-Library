using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    public class TrainingMethod
    {

        public NeuralNetwork<TrainingMethod> Network
        {
            get;
            set;
        }

        public virtual void Train(NeuralNetwork<TrainingMethod> TargetNetwork)
        {
            Network = TargetNetwork;
        }
    }
}
