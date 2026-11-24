using System;

namespace FileSystemHw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Generate 100 numbers (primes and Fibonacci)");
                Console.WriteLine("2. Search and replace word in file");
                Console.WriteLine("3. Text moderator");
                Console.WriteLine("4. Reverse file content");
                Console.WriteLine("5. Analyze 100000 numbers file");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine() ?? String.Empty;
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            NumberFileGenerator generator = new NumberFileGenerator();
                            generator.GenerateAndSave("primes.txt", "fibonacci.txt");
                            break;

                        case "2":
                            Console.Write("Enter file path: ");
                            string replacePath = Console.ReadLine() ?? String.Empty;
                            Console.Write("Enter word to search: ");
                            string searchWord = Console.ReadLine() ?? String.Empty;
                            Console.Write("Enter replacement word: ");
                            string replaceWord = Console.ReadLine() ?? String.Empty;

                            FileWordReplacer replacer = new FileWordReplacer();
                            replacer.ReplaceWord(replacePath, searchWord, replaceWord);
                            break;

                        case "3":
                            Console.Write("Enter text file path: ");
                            string textPath = Console.ReadLine() ?? String.Empty;
                            Console.Write("Enter moderation words file path: ");
                            string badWordsPath = Console.ReadLine() ?? String.Empty;

                            TextModerator moderator = new TextModerator();
                            moderator.ModerateFile(textPath, badWordsPath);
                            break;

                        case "4":
                            Console.Write("Enter source file path: ");
                            string sourcePath = Console.ReadLine() ?? String.Empty;
                            string reversedPath = "reversed_" + System.IO.Path.GetFileName(sourcePath);

                            FileContentReverser reverser = new FileContentReverser();
                            reverser.ReverseFile(sourcePath, reversedPath);
                            break;

                        case "5":
                            LargeNumberFileAnalyzer analyzer = new LargeNumberFileAnalyzer();
                            string numbersFile = "numbers_100000.txt";
                            analyzer.GenerateNumbersFile(numbersFile, 100000);
                            analyzer.AnalyzeFile(
                                numbersFile,
                                "positive.txt",
                                "negative.txt",
                                "two_digit.txt",
                                "five_digit.txt");
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}