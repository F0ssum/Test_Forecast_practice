using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace engine
{
    public class Test
{
    private Question[] questions;
    private int currentQuestionIndex = 0;
    private int score = 0;

    public Test(string filename)
    {
        questions = QuestionReader.ReadQuestions(filename);
    }

    public Question GetCurrentQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            return questions[currentQuestionIndex];
        }
        else
        {
            return null;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AnswerQuestion(bool answer)
    {
        if (answer)
        {
            score += questions[currentQuestionIndex].Value;
        }
        else
        {
            score -= questions[currentQuestionIndex].Value;
        }

        currentQuestionIndex++;
    }
}
}