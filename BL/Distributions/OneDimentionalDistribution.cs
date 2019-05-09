using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Distributions
{
    public abstract class OneDimentionalDistribution : IDistribution, IReproductable
    {
        public string Name { get; set; }

        public abstract double f(double x);

        public abstract double F(double x);

        public abstract double DF(double x);

        protected double AutoDF(double x, double dFdt1, double Dt1, double dFdt2, double Dt2, double cov)
        {
            return (dFdt1 * dFdt1 * Dt1 + dFdt2 * dFdt2 * Dt2 + 2 * dFdt1 * dFdt2 * cov);
        }
    }
}
