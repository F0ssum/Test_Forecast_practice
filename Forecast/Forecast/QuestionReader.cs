using System.Collections.Generic;
using System.IO;
using System.Linq;

public class QuestionReader
{
    public static List<Question> ReadQuestions(string filename)
    {
        // Ключи
        HashSet<int> sincerityKeys = new HashSet<int> { 1, 4, 6, 8, 9, 11, 16, 17, 18, 22, 25, 31, 34, 36, 43 };
        HashSet<int> stabilityKeysPositive = new HashSet<int> { 3, 5, 7, 10, 15, 20, 26, 27, 29, 32, 33, 35, 37, 40, 41, 42, 44, 45, 47, 48, 49, 50, 51, 52, 53, 56, 57, 59, 60, 62, 63, 64, 65, 66, 67, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84 };
        HashSet<int> stabilityKeysNegative = new HashSet<int> { 2, 12, 13, 14, 19, 21, 23, 24, 28, 30, 38, 39, 46, 54, 55, 58, 61, 68 };

        string[] lines = File.ReadAllLines(filename);
        string[] updatedLines = lines.Select(line => line.Length > 3 ? line.Substring(0) : "").ToArray();

        List<Question> questions = new List<Question>();

        for (int i = 0; i < updatedLines.Length; i++)
        {
            string text = updatedLines[i];
            Question question = new Question(text);

            // Назначаем оценки вопросам
            if (sincerityKeys.Contains(i + 1))
            {
                question.Value = -1; // Нет (-)
            }
            else if (stabilityKeysPositive.Contains(i + 1))
            {
                question.Value = 1; // Да (+)
            }
            else if (stabilityKeysNegative.Contains(i + 1))
            {
                question.Value = -1; // Нет (-)
            }
            else
            {
                question.Value = 0; // Если вопрос не в ключах
            }

            questions.Add(question);
        }

        return questions;
    }
}
