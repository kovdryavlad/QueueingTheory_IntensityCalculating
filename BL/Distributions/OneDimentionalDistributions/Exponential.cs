using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Distributions.OneDimentionalDistributions
{
    public class Exponential : OneDimentionalDistribution
    {
        public double _l;

        public double _Dl;

        public Exponential(double lyambda)
        {
            Name = "Експоненціальний";

            _l = lyambda;
        }

        public Exponential(double lyambda, double Dl)
            : this(lyambda)
        {
            _Dl = Dl;
        }

        //пошла чистая математика(программирование формул)

        public override double f(double x)
        {
            if (x < 0)
                return 0;
            else
                return _l * Math.Exp(-_l * x);
        }

        public override double F(double x)
        {
            if (x < 0)
                return 0;
            else
                return 1 - Math.Exp(-_l * x);
        }

        public override double DF(double x)
        {
            return x * x * Math.Exp(-2 * _l * x) * _Dl;
        }
    }
}
