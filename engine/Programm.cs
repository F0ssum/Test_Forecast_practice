using System;

class Program
{
    static void Main()
    {
        Question[] questions = QuestionReader.ReadQuestions("questions.txt");

        // Выводим первые десять вопросов
        for (int i = 0; i < Math.Min(10, questions.Length); i++)
        {
            Console.WriteLine("Вопрос " + (i + 1) + ": " + questions[i].Text);
            Console.WriteLine();
        }
    }
}
