using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogic
{
    public class TestLogic
{
    public int Score { get; private set; }
    public int InsincerityScore { get; private set; }

    private string[] questions;
    private int[] keys;
    private bool[] insincerityQuestions;

    public TestLogic(string[] questions, int[] keys, bool[] insincerityQuestions)
    {
        this.questions = questions;
        this.keys = keys;
        this.insincerityQuestions = insincerityQuestions;
    }

    public string GetQuestion(int index)
    {
        return questions[index];
    }

    public void SubmitAnswer(int index, string answer)
    {
        if (answer == "Да")
        {
            Score += keys[index];
        }
        else if (answer == "Нет")
        {
            Score -= keys[index];
            if (insincerityQuestions[index])
            {
                InsincerityScore++;
            }
        }
    }
}

}