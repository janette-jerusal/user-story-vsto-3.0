using System;
using System.Collections.Generic;
using System.Data;
using Accord.MachineLearning.Text;
using Accord.Statistics.Analysis;

namespace UserStorySimilarityAddIn
{
    public class SimilarityEngine
    {
        public static DataTable ComputeSimilarity(DataTable df1, DataTable df2, float threshold)
        {
            var combined = new List<string>();
            foreach (DataRow row in df1.Rows) combined.Add(row["Desc"].ToString());
            foreach (DataRow row in df2.Rows) combined.Add(row["Desc"].ToString());

            var tfidf = new TfIdfVectorizer();
            double[][] vectors = tfidf.Transform(combined.ToArray());

            int split = df1.Rows.Count;
            var resultTable = new DataTable();
            resultTable.Columns.Add("Story A ID");
            resultTable.Columns.Add("Story A Desc");
            resultTable.Columns.Add("Story B ID");
            resultTable.Columns.Add("Story B Desc");
            resultTable.Columns.Add("Similarity Score");

            for (int i = 0; i < split; i++)
            {
                for (int j = split; j < combined.Count; j++)
                {
                    double score = Cosine(vectors[i], vectors[j]);
                    if (score >= threshold)
                    {
                        resultTable.Rows.Add(
                            df1.Rows[i]["ID"],
                            df1.Rows[i]["Desc"],
                            df2.Rows[j - split]["ID"],
                            df2.Rows[j - split]["Desc"],
                            Math.Round(score, 3)
                        );
                    }
                }
            }

            return resultTable;
        }

        private static double Cosine(double[] v1, double[] v2)
        {
            double dot = 0, norm1 = 0, norm2 = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                dot += v1[i] * v2[i];
                norm1 += v1[i] * v1[i];
                norm2 += v2[i] * v2[i];
            }
            return dot / (Math.Sqrt(norm1) * Math.Sqrt(norm2) + 1e-10);
        }
    }
}
