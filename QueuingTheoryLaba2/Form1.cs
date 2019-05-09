using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BL;
using BL.Distributions.OneDimentionalDistributions;

namespace QueuingTheoryLaba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        STAT stat;
        FileReader fileReader = new FileReader();
        double[] m_d;

        private void ЗчитатиВыдлікиЧасуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] d = null;
            if (GetFileName(out string filename))
                d = fileReader.Read(filename);

            else
                return;

            m_d =new double[d.Length - 1];

            for (int i = 1; i < d.Length; i++)
                m_d[i-1] = d[i] - d[i - 1];

            chart2.Series.Clear();
            OutputReadedDataOnForm(filename);
        }
        private void ЗчитатиІнтервалиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetFileName(out string filename))
                m_d = fileReader.Read(filename);

            else
                return;

            chart2.Series.Clear();
            OutputReadedDataOnForm(filename);
        }
        public bool GetFileName(out string filename)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename =  ofd.FileName;
                return true;
            }

            filename = null;
            return false;
        }

        void OutputReadedDataOnForm(string filename)
        {
            logTextBox.Text = $"Зчитано файл {Path.GetFileName(filename)}"+ Environment.NewLine;  

            stat = new STAT(m_d);

            double l = 1d / stat.Expectation;

            double Dl = l * l / stat.d.Length;

            stat.ReproductDistribution(new Exponential(l, Dl));

            chart1.Series[0].Points.DataBindXY(stat.masX.Select(el => el + 0.5 * stat.h).ToArray(), 
                                               stat.masYProbabilities);


            chart1.ChartAreas[0].AxisX.Interval = stat.h;
            chart1.ChartAreas[0].AxisX.Minimum = stat.Min;
            chart1.ChartAreas[0].AxisX.Maximum= stat.Max;

            chart2.ChartAreas[0].AxisX.Interval = stat.h;
            chart2.ChartAreas[0].AxisX.Minimum = stat.Min;
            chart2.ChartAreas[0].AxisX.Maximum = stat.Max;
        }


        double m_aplha;
        private void parseParamsFromForm()
        {
            if (!double.TryParse(alphatextBox.Text.Replace(".",","), out m_aplha))
            {
                logTextBox.Text += "Помилка зчитування альфа";
                m_aplha = 0.05;
                alphatextBox.Text = m_aplha.ToString();
            }
        }

        private void КритерійКолмогороваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parseParamsFromForm();

            logTextBox.Text += Hypotheses.KZKolvogorov(stat, m_aplha);
        }

        private void КритерійПірсонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parseParamsFromForm();

            logTextBox.Text += Hypotheses.KZPirsona(stat, m_aplha);
        }

        private void Інтенсивність1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Series s = new Series();
            s.ChartType = SeriesChartType.Line;
            s.BorderWidth = 2;

            s.Points.AddXY(stat.Min, 1d / stat.Expectation);
            s.Points.AddXY(stat.Max, 1d / stat.Expectation);
            chart2.Series.Add(s);

            logTextBox.Text = "Інтенсивність: " + (1d / stat.Expectation).ToString("0.0000")+Environment.NewLine;
        }

        private void ІнтенсивністьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            stat.CalcStartIntensity();
            OutputIntensity();
        }

        void OutputIntensity()
        {
            chart2.Series.Clear();

            logTextBox.Text += "Інтенсивності: " + Environment.NewLine;

            for (int i = 0; i < stat.intensities.Length; i++)
            {
                Series s = new Series();
                s.ChartType = SeriesChartType.Line;
                s.BorderWidth = 2;

                //не включая последнюю
                if (!(i == stat.intensities.Length - 1))
                {
                    s.Points.AddXY(stat.masX[i], stat.intensities[i]);
                    s.Points.AddXY(stat.masX[i + 1], stat.intensities[i]);
                }
                else // для последней
                {
                    s.Points.AddXY(stat.masX[i], stat.intensities[i]);
                    s.Points.AddXY(stat.Max, stat.intensities[i]);
                }

                    chart2.Series.Add(s);
            }

            for (int i = 0; i < stat.intensities.Length; i++)            
                logTextBox.Text += $"λ{i}: {stat.intensities[i].ToString("0.0000")}"+Environment.NewLine;
        }

        private void обєднатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parseParamsFromForm();
            stat.MergeIntensities(m_aplha);
            OutputIntensity();
        }
    }
}
