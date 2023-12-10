using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace engine
{
   public class Test
{
    private List<Question> questions;
    public int CurrentQuestionIndex { get; private set; } = 0;
    private int score = 0;

    public Test(string filename)
    {
        questions = QuestionReader.ReadQuestions(filename);
    }

    public Question GetCurrentQuestion()
    {
        if (CurrentQuestionIndex < questions.Count)
        {
            return questions[CurrentQuestionIndex];
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

        public void AnswerQuestion(Question question, bool answer)
        {
            question.UserAnswer = answer;

            if (question.Value == -1)
            {
                // Обработка вопросов, связанных с искренностью
                if (answer)
                {
                    score -= 1;
                }
                else
                {
                    score += 1;
                }
            }
            else
            {
                // Обработка всех остальных вопросов
                if (answer)
                {
                    score += question.Value;
                }
                else
                {
                    score -= question.Value;
                }
            }

            CurrentQuestionIndex++;
        }

        public int GetSincerityScore()
        {
            return questions.Take(CurrentQuestionIndex).Where(q => q.Value == -1 && q.UserAnswer.HasValue).Sum(q => q.UserAnswer.Value ? -1 : 1);
        }
        public int GetTotalScore()
        {
            return questions.Take(CurrentQuestionIndex).Sum(q => q.Value);
        }
    }
}
