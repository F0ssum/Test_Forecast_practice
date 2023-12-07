using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogic
{
    class Program
    {
    static void Main()
        {
        string[] questions = new string[84]; // Заполните вопросами
        int[] keys = new int[84]; // Заполните ключами
        bool[] insincerityQuestions = new bool[84]; // Заполните, какие вопросы увеличивают шкалу неискренности

        TestLogic test = new TestLogic(questions, keys, insincerityQuestions);

        for (int i = 0; i < questions.Length; i++)
            {
            Console.WriteLine(test.GetQuestion(i));
            string userAnswer = Console.ReadLine();
            test.SubmitAnswer(i, userAnswer);
            }

        Console.WriteLine("Тест завершен. Ваш счет: " + test.Score);
        Console.WriteLine("Шкала неискренности: " + test.InsincerityScore);
        }
    }
}