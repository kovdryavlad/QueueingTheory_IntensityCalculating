using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace BL
{
    public class FileReader
    {
        public double[] Read(string fileName)
        {
            List<double> result = new List<double>();

            using (StreamReader streamReader =  File.OpenText(fileName))
            {
                string s = null;

                while ((s = streamReader.ReadLine())!= null)  
                    result.AddRange(ConvertStringToDoubleArray(s));
            }

            return result.ToArray();
        }

        private List<double> ConvertStringToDoubleArray(string s)
        {
            string[] arr =  s.Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return arr.Select(el => Convert.ToDouble(el.Replace('.', ',')))
                      .ToList();
        }
    }
}
