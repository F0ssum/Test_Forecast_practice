public class Question
{
    public string Text { get; }
    public int Value { get; set; } // Добавляем новое свойство

    public Question(string text)
    {
        Text = text;
    }
}