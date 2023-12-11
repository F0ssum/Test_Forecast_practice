using engine;
using System;
using System.Windows.Forms;

namespace Forecast
{
    public partial class Form1 : Form
    {
        Test test;

        public Form1()
        {
            InitializeComponent();
            // Установка размера формы в соответствии с размером TabControl
            this.Size = new System.Drawing.Size(tabControl1.Width, tabControl1.Height);

            // Инициализация теста
            test = new Test("questions.txt");

            // Установка максимального значения ProgressBar
            progressBar1.Maximum = test.GetTotalQuestions();

            // Загрузка первого вопроса
            LoadQuestion();
        }
        private void LoadQuestion()
        {
            // Получение текущего вопроса
            Question question = test.GetCurrentQuestion();

            if (question != null)
            {
                // Отображение вопроса в Label
                label1.Text = question.Text;
            }
            else
            {
                //Вывод резудьтата теста
                int totalScore = test.GetScore();
                int sincerityScore = test.GetSincerityScore();
                MessageBox.Show($"Тест завершен. Ваш общий счет: {totalScore}, Шкала искренности: {sincerityScore}");
                label1.Text = "Тест завершен";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Обработка ответа пользователя
            test.AnswerQuestion(test.GetCurrentQuestion(), true);

            // Обновление ProgressBar
            progressBar1.Value = test.GetCurrentQuestionIndex();

            // Загрузка следующего вопроса
            LoadQuestion();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Обработка ответа пользователя
            test.AnswerQuestion(test.GetCurrentQuestion(), false);

            // Обновление ProgressBar
            progressBar1.Value = test.GetCurrentQuestionIndex();

            // Загрузка следующего вопроса
            LoadQuestion();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Проверка, есть ли предыдущий вопрос
            if (test.GetCurrentQuestionIndex() > 0)
            {
                // Уменьшение индекса текущего вопроса
                test.DecrementQuestionIndex();

                // Загрузка предыдущего вопроса
                LoadQuestion();
            }
        }
    }
}
