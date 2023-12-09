using System;
using System.Collections.Generic;
using engine;

class Program
{
    static void Main()
    {
        Test test = new Test("questions.txt");

        // Выводим вопросы по одному
        for (int i = 0; i < 10; i++)
        {
            Question question = test.GetCurrentQuestion();
            Console.WriteLine("Вопрос " + (i + 1) + ": " + question.Text);
            Console.Write("Введите ответ (да/нет): ");
            string answer = Console.ReadLine().ToLower();

            // Обрабатываем ответ
            if (answer == "да")
            {
                question.AnswerQuestion(true);
            }
            else if (answer == "нет")
            {
                question.AnswerQuestion(false);
            }
            else
            {
                Console.WriteLine("Неверный формат ответа. Пожалуйста, введите 'да' или 'нет'.");
                i--; // Повторяем вопрос
            }

            Console.WriteLine();
        }

        // Выводим общий результат
        Console.WriteLine("Шкала искренности: " + test.GetSincerityScore());
        Console.WriteLine("Общий счет: " + test.GetTotalScore());
    }
}
