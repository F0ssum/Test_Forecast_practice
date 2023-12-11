using System.Collections.Generic;
using System.Linq;

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
        public int GetTotalQuestions()
        {
            return questions.Count;
        }

        public int GetScore()
        {
            return score;
        }

        public int GetCurrentQuestionIndex()
        {
            return CurrentQuestionIndex;
        }

        public void DecrementQuestionIndex()
        {
            if (CurrentQuestionIndex > 0)
            {
                CurrentQuestionIndex--;
            }
        }


        public void AnswerQuestion(Question question, bool answer)
        {
            if (question.UserAnswer.HasValue)
            {
                // Если на вопрос уже был дан ответ, отмени предыдущий ответ
                score -= question.UserAnswer.Value ? question.Value : -question.Value;
            }

            // Обновите ответ пользователя
            question.UserAnswer = answer;

            // Обработка ответа пользователя
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
