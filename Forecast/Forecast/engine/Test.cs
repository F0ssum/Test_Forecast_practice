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

        public void AnswerQuestion(bool answer)
        {
            if (answer)
            {
                score += questions[CurrentQuestionIndex].Value;
            }
            else
            {
                score -= questions[CurrentQuestionIndex].Value;
            }

            CurrentQuestionIndex++;
        }

        public int GetSincerityScore()
        {
            return questions.Where(q => q.Value == -1).Sum(q => q.Value);
        }

        public int GetTotalScore()
        {
            return questions.Sum(q => q.Value);
        }
    }
}
