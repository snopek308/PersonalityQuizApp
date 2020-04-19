using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StarWarsApp.Models
{
    class Question
    {

        public class QuizQuestion : INotifyPropertyChanged
        {
            public string Question { get; private set; }
            public int NumberOfQuestion { get; private set; }

            string UserResponse;

            public event PropertyChangedEventHandler PropertyChanged;

            public string Response
            {
                private set
                {
                    if (UserResponse != value)
                    {
                        UserResponse = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Response"));
                    }
                }
                get
                {
                    return UserResponse;
                }
            }

            public static IList<QuizQuestion> All { get; set; }

            private QuizQuestion()
            {
            }

            public QuizQuestion(string question, int questionNum, string userResponse)
            {
                Question = question;
                NumberOfQuestion = questionNum;
                UserResponse = userResponse;
            }

            static QuizQuestion()
            {
                List<QuizQuestion> all = new List<QuizQuestion>
                {
                    new QuizQuestion("Darkside or Lightside?", 0, null),
                    new QuizQuestion("Pilot in Space or Pilot a Speeder?", 1, null),
                    new QuizQuestion("Furry Companion or Human Companion?", 2, null),
                    new QuizQuestion("Lightsaber or Blaster?", 3, null),
                    new QuizQuestion("Sassy Droid or Stable Droid?", 4, null),
                };
                All = all;
            }

            public static Boolean AllQuestionsAnswered()
            {
                Boolean done = true;
                foreach (var x in QuizQuestion.All)
                {
                    if (x.UserResponse == null)
                        done = false;
                }

                return done;
            }

            public static void SetResponse(int index, string response)
            {
                QuizQuestion.All[index].UserResponse = response;
            }

            public static void ResetQuestions()
            {
                foreach (QuizQuestion x in QuizQuestion.All)
                {
                    x.UserResponse = null;
                }
            }

        }
    }
}
