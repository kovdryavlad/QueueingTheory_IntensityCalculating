using BL.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class STAT
    {
        public double[] d;              //массив для изменения
        public int M;                   //количество столбцов
        public double h;                //шаг
        public double[] masX;
        public double[] masY;
        public double[] masYProbabilities;
        public double Max;
        public double Min;
        public double Expectation;

        public IReproductable _ReproductDistribution;

        //для импирической функции распределения 
        public double[] Seria3X;
        public double[] Seria3Y;

        //для колмогорова
        public double[] _FTeor;

        public STAT(double[] d)
        {
            this.d = d;
            Expectation = d.Average();


            SetM();
            Seth();
            FormDataSeria1();
            FormDataSeria3();
        }

        private void SetM()
        {
            double _m;
            if (d.Length >= 100)
                _m = Math.Truncate(Math.Pow((double)d.Length, 1d / 3));
            else
                _m = Math.Truncate(Math.Pow((double)d.Length, 1d / 2));

            if (_m % 2 == 0)
                _m--;

            M = (int)_m;
        }

        private void Seth()
        {
            this.Max = d.Max();
            this.Min = d.Min();
            this.h = (Max - Min) / M;
            h = Math.Round(h + 0.0001, 4);
        }

        private void FormDataSeria1()
        {
            SetM();
            Seth();

            masX = new double[M];
            masY = new double[M];
            masYProbabilities = new double[M];

            var array = d;
            var n = d.Length;
            var step = h;

            for (int i = 0; i < n; i++)
            {
                int index = (int)Math.Truncate((array[i] - Min) / step);
                masY[index]++;
            }

            // masY[M - 1]++;//добавляем максимальный элемент 
            var Mlen = M;
            for (int i = 0; i < Mlen; i++)
                masX[i] = Min + i * step;

            //для перевода количества вхождений в частоту
            for (int i = 0; i < masY.Length; i++)
                masYProbabilities[i] = masY[i] / d.Length;
        }

        public void ReproductDistribution(Distributions.IReproductable reproductableDistribution)
        {
            _ReproductDistribution = reproductableDistribution;

            _FTeor = d.OrderBy(x => x)
                      .Select(x => _ReproductDistribution.F(x))
                      .ToArray();
        }

        //построить импирическую функцию распределения
        public void FormDataSeria3()
        {
            var arr = d.OrderBy(v => v).ToArray();

            List<double> pointsX = new List<double>();
            List<double> pointskolvoY = new List<double>();//называется как будто там лежит количество повторов каждого 
            //числа, но на деле оно делиться на длинну d.Length потому double

            int _number = 0; //счетчик которой говорит до какого элемента дошли
            int vhod;

            var len = arr.Length;
            for (; _number < len; _number++)
            {
                //pointsX.Add(d[_number]);
                vhod = 1;

                if (_number != len - 1)//чтобы исключить возможность входа в цикл с последним элементом _number == d.Length-1
                {
                    while ((_number + 1) != len && arr[_number + 1] == arr[_number])
                    {
                        vhod++;
                        _number++;
                    }
                }

                //изменения для того, чтобы массивы Seria3X и Seria3Y были
                //такой же длинны как и входной массив
                int j = 0;

                do
                {
                    j++;
                    pointsX.Add(arr[_number]);
                    pointskolvoY.Add((double)vhod / len);

                } while (j != vhod);

            }

            Seria3X = pointsX.ToArray();
            Seria3Y = pointskolvoY.ToArray();

            for (int i = 1; i < Seria3Y.Length; i++)
            {
                //изменено в мае

                if (Seria3X[i] == Seria3X[i - 1])
                    Seria3Y[i] = Seria3Y[i - 1];
                else
                    Seria3Y[i] += Seria3Y[i - 1];

                //Seria3Y[i] = Math.Round(Seria3Y[i], 4);
            }
        }

        public double[] intensities;

        public void CalcStartIntensity()
        {
            intensities = new double[M];

            int N = d.Length;
            int Nj = 0;
            for (int i = 0; i < M; i++)
            {
                Nj += (int)masY[i];

                intensities[i] = masY[i] / ((N - Nj) * h);
                
            }

            //костЫЫль
            intensities[M - 1] = intensities[M - 2]+ 0.3* intensities[M - 2];
        }

        public void MergeIntensities(double alpha)
        {
            for (int i = 0; i < intensities.Length-1; i++)
            {
                double v = intensities[i + 1] - intensities[i];
                v /= Math.Sqrt((masY[i] - 1) * intensities[i + 1] * intensities[i + 1] +
                               (masY[i + 1] - 1) * intensities[i] * intensities[i]);

                double nu = masY[i] + masY[i + 1] - 2;

                v *= Math.Sqrt((masY[i] * masY[i + 1]*nu)/(masY[i] + masY[i + 1]));

                if (Math.Abs(v) > Kvantili.Student(alpha, nu))
                    continue;

                //merging  block

                double tau1 = masX[i+1]- masX[i];
                double tau2 = 0;

                if (i + 2 <= intensities.Length - 1)
                    tau2 = masX[i + 2] - masX[i + 1];
                else
                    tau2 = Max - masX[i + 1];

                double lyambdaMerged = (masY[i] + masY[i + 1]) / ((d.Length - masY.Take(i + 2).Sum()) *(tau1+tau2));

                if (double.IsPositiveInfinity(lyambdaMerged))
                    //lyambdaMerged = 0;
                    lyambdaMerged = intensities[i+1]*1.3;

                masY[i] += masY[i + 1];
                masY = masY.Where((el, index) => index != i + 1).ToArray(); //remove i+1 element

                intensities[i] = lyambdaMerged;
                intensities = intensities.Where((el, index) => index != i + 1).ToArray();

                masX = masX.Where((el, index) => index != i + 1).ToArray();

                i--;
            }
        }
    }
}
