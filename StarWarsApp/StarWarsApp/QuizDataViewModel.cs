using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StarWarsApp
{
    class QuizDataViewModel : INotifyPropertyChanged
    {
        public static List<Question> questionList { private get; set; }
        public string currentQuestion;
        public int questionIndex = 0;
        public int pointCounter = 0;
        private string newQuestion;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand userResponse { protected set; get; }

        public QuizDataViewModel()
        {
            //This adds questions to the List that the code will cycle through
            questionList = new List <Question>
                {
                    new Question("Do you prefer to fight for 1) Darkside or 2) Lightside?"),
                    new Question("Do you prefer to 1) pilot in space or 2) drive an airspeeder?"),
                    new Question("Do you prefer to 1) have a furry companion or 2) have a human companion?"),
                    new Question("Do you prefer to 1) wield a Lightsaber or 2) wield a Blaster?"),
                    new Question("Do you prefer to 1) have a sassy droid or 2) a stable droid?")
                };

            //This sets the currentQuestion to whatever the questionindex is of the questionList
            currentQuestion = questionList[questionIndex].text;

            //This sets up whatever the user chooses (true or false) and adds points to the pointCounter
            userResponse = new Command<string>((key) =>
            {
                int response;
                if (key == "True")
                    {
                    //if the user picks the left button, it adds to the left side
                        pointCounter += 25;
                         response = 1; 
                    }
                else 
                    {
                    //if the user picks the right side, it subtracts points
                        pointCounter -= 25;
                        response = 0; 
                    }
                //this sets up if there is another question to be read to the users
                if (questionIndex < questionList.Count)
                {
                    questionList[questionIndex].answer = response;
                }
                nextQuestion();
            },
            (key) =>
            {
                return questionIndex >= questionList.Count - 1 ? false : true;
            });

        }

        //this not only flips the code of the question, but also adds points to and determines the returned value of the character
        public void nextQuestion()
        {
            if(questionIndex < questionList.Count-1)
            {
                CurrentQuestion = questionList[++questionIndex].text;
            }
            else
            {
                if(pointCounter < 0)
                {
                    returnedCharacter("Ventress");
                }
                else if(pointCounter <0 && pointCounter <=50)
                {
                    returnedCharacter("Hera");
                }
                else if (pointCounter < 50 && pointCounter <= 75)
                {
                    returnedCharacter("Leia");
                }
                else if (pointCounter < 75 && pointCounter <= 100)
                {
                    returnedCharacter("Ahsoka");
                }
                else
                {
                    returnedCharacter("Sabine");
                }
            }
        }

        //this method returns the character the person choose
        public void returnedCharacter(string value)
        {
            CurrentQuestion = "Wow, you're such a " + value + "!";
            ((Command)userResponse).ChangeCanExecute();
        }

        //This method is called above to help change the question
        public string CurrentQuestion
        {
            protected set
            {
                if(currentQuestion != value)
                {
                    currentQuestion = value;
                    OnPropertyChanged("CurrentQuestion");
                }
            }
            get { return currentQuestion; }
        }

            
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}





