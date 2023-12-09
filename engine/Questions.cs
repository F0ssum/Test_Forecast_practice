public class Question
{
    public string Text { get; }
    public int Value { get; set; } // Добавляем новое свойство

    public Question(string text)
    {
        Text = text;
    }

    // Добавляем функцию для обработки ответов
    public void AnswerQuestion(bool answer)
    {
        if (answer)
        {
            Value += 1;
        }
        else
        {
            Value -= 1;
        }
    }
}
