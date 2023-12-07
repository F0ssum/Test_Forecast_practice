using System;
using System.IO;
using System.Linq;

public class QuestionReader
{
    public static Question[] ReadQuestions(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        string[] updatedLines = lines.Select(line => line.Length > 3 ? line.Substring(3) : "").ToArray();
        File.WriteAllLines(filename, updatedLines);

        Question[] questions = new Question[updatedLines.Length];

        for (int i = 0; i < updatedLines.Length; i++)
        {
            string text = updatedLines[i];
            questions[i] = new Question(text);
        }

        return questions;
    }
}
