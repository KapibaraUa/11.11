using System;
using System.IO;

namespace FileSystemHw
{
    public class LargeNumberFileAnalyzer
    {
        public void GenerateNumbersFile(string filePath, int count)
        {
            Random random = new Random();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(-100000, 100001);
                    writer.WriteLine(number);
                }
            }
        }

        public void AnalyzeFile(
            string sourcePath,
            string positivePath,
            string negativePath,
            string twoDigitPath,
            string fiveDigitPath)
        {
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException("Numbers file not found", sourcePath);

            int positiveCount = 0;
            int negativeCount = 0;
            int twoDigitCount = 0;
            int fiveDigitCount = 0;

            using (StreamReader reader = new StreamReader(sourcePath))
            using (StreamWriter positiveWriter = new StreamWriter(positivePath))
            using (StreamWriter negativeWriter = new StreamWriter(negativePath))
            using (StreamWriter twoDigitWriter = new StreamWriter(twoDigitPath))
            using (StreamWriter fiveDigitWriter = new StreamWriter(fiveDigitPath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        if (number > 0)
                        {
                            positiveCount++;
                            positiveWriter.WriteLine(number);
                        }
                        else if (number < 0)
                        {
                            negativeCount++;
                            negativeWriter.WriteLine(number);
                        }

                        int absNumber = Math.Abs(number);

                        if (absNumber >= 10 && absNumber <= 99)
                        {
                            twoDigitCount++;
                            twoDigitWriter.WriteLine(number);
                        }

                        if (absNumber >= 10000 && absNumber <= 99999)
                        {
                            fiveDigitCount++;
                            fiveDigitWriter.WriteLine(number);
                        }
                    }
                }
            }

            Console.WriteLine($"Positive numbers: {positiveCount}");
            Console.WriteLine($"Negative numbers: {negativeCount}");
            Console.WriteLine($"Two-digit numbers: {twoDigitCount}");
            Console.WriteLine($"Five-digit numbers: {fiveDigitCount}");
        }
    }
}