using System.Collections.Generic;
using System.Linq;

namespace UserStorySimilarityAddIn
{
    public static class SimilarityEngine
    {
        public static List<(string, string, double)> ComputeSimilarities(List<string> userStories)
        {
            var similarities = new List<(string, string, double)>();

            for (int i = 0; i < userStories.Count; i++)
            {
                for (int j = i + 1; j < userStories.Count; j++)
                {
                    double sim = CalculateCosineSimilarity(userStories[i], userStories[j]);
                    similarities.Add((userStories[i], userStories[j], sim));
                }
            }

            return similarities;
        }

        private static double CalculateCosineSimilarity(string text1, string text2)
        {
            var words1 = text1.Split(' ').GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());
            var words2 = text2.Split(' ').GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());

            var allWords = words1.Keys.Union(words2.Keys);
            double dot = 0, mag1 = 0, mag2 = 0;

            foreach (var word in allWords)
            {
                words1.TryGetValue(word, out int freq1);
                words2.TryGetValue(word, out int freq2);

                dot += freq1 * freq2;
                mag1 += freq1 * freq1;
                mag2 += freq2 * freq2;
            }

            return mag1 == 0 || mag2 == 0 ? 0 : dot / (System.Math.Sqrt(mag1) * System.Math.Sqrt(mag2));
        }
    }
}
