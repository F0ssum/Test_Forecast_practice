using engine;
using Forecast;
using static System.Net.Mime.MediaTypeNames;
public class Question
{
    public bool? UserAnswer { get; set; } = null;
    private Test test;
    public string Text { get; }
    public int Value { get; set; } // Добавляем новое свойство

    public Question(string text)
    {
        this.Text = text;
    }

    // Добавляем функцию для обработки ответов
    public void AnswerQuestion(bool answer)
    {
        test.AnswerQuestion(this, answer);
    }
}
