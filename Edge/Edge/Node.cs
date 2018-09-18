using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    public class Node
    {
        public virtual double[] Weights
        {
            get;
            set;
        }

        public virtual double Bias
        {
            get;
            set;
        }
    }

    public class Layer
    {
        public virtual Node[] Nodes
        {
            get;
            set;
        }
    }
}
