using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    public class ActivationFunction
    {
        public  ActivationFunction()
        {
        }
        public virtual double GetFunction(double x)
        {
            return x;
        }

        public virtual double GetDerivative(double x)
        {
            return 1;
        }
    }

    public class Identity : ActivationFunction
    {
        public Identity()
        {
        }
        public override double GetFunction(double x)
        {
            return base.GetFunction(x);
        }

        public override double GetDerivative(double x)
        {
            return base.GetDerivative(x);
        }
    }

    public class BinaryStep : ActivationFunction
    {
        public BinaryStep()
        {
        }
        public override double GetFunction(double x)
        {
            if(x < 0)
            {
                return 0;
            }

            return 1;
        }

        public override double GetDerivative(double x)
        {
            return 0;
        }
    }

    public class Logistic : ActivationFunction
    {
        public Logistic()
        {
        }
        public override double GetFunction(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public override double GetDerivative(double x)
        {
            double Function = GetFunction(x);
            return Function * (1.0 - Function);
        }
    }

    public class TanH : ActivationFunction
    {
        public TanH()
        {
        }
        public override double GetFunction(double x)
        {
            return 2.0 / (1.0 + Math.Exp(-2.0 * x)) - 1.0;
        }

        public override double GetDerivative(double x)
        {
            double Function = Math.Tanh(x);
            return 1 - (Function * Function);
        }
    }

    public class ArcTan : ActivationFunction
    {
        public ArcTan()
        {
        }
        public override double GetFunction(double x)
        {
            return Math.Atan(x);
        }

        public override double GetDerivative(double x)
        {
            return 1 / ((x * x) + 1);
        }
    }

    public class SoftSign : ActivationFunction
    {
        public SoftSign()
        {
        }
        public override double GetFunction(double x)
        {
            return 1 / (Math.Abs(x) + 1);
        }

        public override double GetDerivative(double x)
        {
            return 1.0 / ((1.0 + Math.Abs(x)) * (1.0 + Math.Abs(x)));
        }
    }

    public class RectifiedLinearUnit : ActivationFunction
    {
        public RectifiedLinearUnit()
        {
        }
        public override double GetFunction(double x)
        {
            if(x < 0)
            {
                return 0;
            }
            return base.GetFunction(x);
        }

        public override double GetDerivative(double x)
        {
            if(x < 0)
            {
                return 0;
            }
            return 1;
        }
    }

    public class SoftPlus : ActivationFunction
    {
        public SoftPlus()
        {
        }
        public override double GetFunction(double x)
        {
            return Math.Log(1 + Math.Exp(x));
        }

        public override double GetDerivative(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }

    public class BentIdentity : ActivationFunction
    {
        public BentIdentity()
        {
        }
        public override double GetFunction(double x)
        {
            return ((Math.Sqrt((x * x) + 1) - 1) / 2) + x;
        }

        public override double GetDerivative(double x)
        {
            return (x / (2 * Math.Sqrt((x * x) + 1))) + 1;
        }
    }

    public class Sinusoid : ActivationFunction
    {
        public Sinusoid()
        {
        }
        public override double GetFunction(double x)
        {
            return Math.Sin(x);
        }

        public override double GetDerivative(double x)
        {
            return Math.Cos(x);
        }
    }

    public class Sinc : ActivationFunction
    {
        public Sinc()
        {
        }
        public override double GetFunction(double x)
        {
            if(x == 0)
            {
                return 1;
            }
            return Math.Sin(x) / x;
        }
        public override double GetDerivative(double x)
        {
            if (x == 0)
            {
                return 0;
            }
            return (Math.Cos(x) / x) - (Math.Sin(x)/(x * x));
        }
    }

    public class Gaussian : ActivationFunction
    {
        public Gaussian()
        {
        }
        public override double GetFunction(double x)
        {
            return Math.Exp(-(x * x));
        }
        public override double GetDerivative(double x)
        {
            return (-2 * x) * Math.Exp(-(x * x));
        }
    }
}
