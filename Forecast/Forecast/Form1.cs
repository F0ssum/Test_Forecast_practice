using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using engine;

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
            test.AnswerQuestion(true);

            // Загрузка следующего вопроса
            LoadQuestion();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Обработка ответа пользователя
            test.AnswerQuestion(true);

            // Загрузка следующего вопроса
            LoadQuestion();
        }
    }
}
