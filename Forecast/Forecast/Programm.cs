using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using engine;
using Forecast;

internal static class Program
{
    [STAThread]

    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Test test = new Test("questions.txt");

        // Выводим вопросы по одному
        for (int i = 0; i < 10; i++)
        {
            Question question = test.GetCurrentQuestion();

            // Здесь вы можете добавить свой код для отображения вопроса пользователю

            // Предположим, что answer получает значение в результате нажатия кнопки
            string answer = GetAnswerFromButtonPress();

            if (answer == "да")
            {
                HandleYesAnswer(question);
            }
            else if (answer == "нет")
            {
                HandleNoAnswer(question);
            }
            else
            {
                // Здесь вы можете добавить свой код для обработки некорректного ввода
            }
        }

        // Здесь вы можете добавить свой код для отображения результатов теста
    }

    static void HandleYesAnswer(Question question)
    {
        question.AnswerQuestion(true);
    }

    static void HandleNoAnswer(Question question)
    {
        question.AnswerQuestion(false);
    }

    static string GetAnswerFromButtonPress()
    {
        // Здесь вы можете добавить свой код для обработки нажатия кнопки
        return "";
    }
}
