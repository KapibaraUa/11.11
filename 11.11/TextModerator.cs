using System;
using System.IO;

namespace FileSystemHw
{
    public class TextModerator
    {
        public void ModerateFile(string textFilePath, string badWordsFilePath)
        {
            if (!File.Exists(textFilePath))
                throw new FileNotFoundException("Text file not found", textFilePath);

            if (!File.Exists(badWordsFilePath))
                throw new FileNotFoundException("Moderation words file not found", badWordsFilePath);

            string text = File.ReadAllText(textFilePath);
            string badWordsContent = File.ReadAllText(badWordsFilePath);

            char[] separators = new char[] { ' ', '\n', '\r', '\t' };
            string[] badWords = badWordsContent.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in badWords)
            {
                string mask = new string('*', word.Length);
                text = text.Replace(word, mask);
            }

            File.WriteAllText(textFilePath, text);
            Console.WriteLine("Moderation completed successfully.");
        }
    }
}