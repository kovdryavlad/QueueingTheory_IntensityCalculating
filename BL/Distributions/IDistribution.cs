using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Distributions
{
    public interface IDistribution
    {
        double f(double x);       //функция плотности распределения
        double F(double x);       //функция распределения
    }
}
