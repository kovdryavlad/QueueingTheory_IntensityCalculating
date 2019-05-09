using System;

namespace BL
{
    public class Hypotheses
    {
        public static string KZKolvogorov(STAT stat, double alpha = 0.05)
        {
            double DNm = 0;
            double DNp = Math.Abs(stat.Seria3Y[0] - stat._FTeor[0]);

            for (int i = 1; i < stat.d.Length; i++)
            {
                DNp = Math.Max(DNp, Math.Abs(stat.Seria3Y[i] - stat._FTeor[i]));
                DNm = Math.Max(DNm, Math.Abs(stat.Seria3Y[i] - stat._FTeor[i - 1]));
            }

            double z = Math.Sqrt(stat.d.Length) * Math.Max(DNp, DNm);

            int k = 0;
            double sum = 0;
            double temp = 0;

            do
            {
                k++;

                double f1 = k * k - 0.5 * (1 - Math.Pow(-1, k));
                double f2 = 5 * k * k + 22 - 7.5 * (1 - Math.Pow(-1, k));

                #region temp-овые переменные, для упрощения большой суммы
                double a = Math.Pow(-1, k) * Math.Exp(-2 * k * k * z * z);
                double b = 1 - 2 * k * k * z / (3 * Math.Sqrt(stat.d.Length));
                double c = 1d / (18 * stat.d.Length) * ((f1 - 4 * (f1 + 3)) * k * k * z * z + 8 * Math.Pow(k, 4) * Math.Pow(z, 4));

                //d использовать нельзя
                double e = k * k * z / (27 * Math.Pow(stat.d.Length, 3d / 2)) *
                           (f2 * f2 / 5d - 4 * (f2 + 45) * k * k * z * z / 15 + 8 * Math.Pow(k, 4) * Math.Pow(z, 4));

                #endregion

                temp = a * (b - c + e);
                sum += temp;

            } while (temp >= 0.0001);

            double Kz = 1 + 2 * sum;
            double Pz = 1 - Kz;

            //Вывод решения решение
            string result="";
            Action<string> add2log = v => result += v + Environment.NewLine;
            Func<double, double> r = v => Math.Round(v);

            add2log("");
            add2log("Критерій Колмогорова:");
            add2log("Pz = " + r(Pz));
            add2log("alpha = " + alpha);
            if (Pz >= alpha)
            {
                add2log("Pz >= alpha");
                add2log("Пройдено");
            }
            else
            {
                add2log("Pz < alpha");
                add2log("Не Пройдено");
            }
            return result;
        }

        public static string KZPirsona(STAT stat, double alpha = 0.05)
        {
            double min = 0;
            double max = 0;
            double sum = 0;

            for (int i = 0; i < stat.M; i++)
            {
                min = stat.Min + stat.h * i;
                max = min + stat.h;

                double n0 = stat._ReproductDistribution.F(max) - stat._ReproductDistribution.F(min);

                n0 *= stat.d.Length;
                double ni = stat.masY[i];

                sum += Math.Pow((ni - n0), 2) / n0;
            }

            string result = "";
            double kv = Kvantili.Hi2(alpha, stat.M - 1);

            Action<string> add2log = v => result += v + Environment.NewLine;
            Func<double, double> r = v => Math.Round(v);

            add2log("");
            add2log("Критерій Пірсона:");
            add2log("kv = " + r(kv));
            add2log("sum = " + r(sum));
            if (sum < kv)
            {
                add2log("sum < kv");
                add2log("Пройдено");
            }
            else
            {
                add2log("sum >= kv");
                add2log("Не пройдено");
            }

            return result;
        }
    }
}
