using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static StarWarsApp.Models.Question;

namespace StarWarsApp
{

    public partial class MainPage : ContentPage
    {

        public int pointsTotal = 0;

        public MainPage()
        {
            InitializeComponent();

            listView.BindingContext = QuizQuestion.All;
        }

        public void ScoreQuiz()
        {
            string CharacterResult = "";

            if(pointsTotal < 0)
            {
                CharacterResult = "Ventress";
            }
            else if (pointsTotal < 0 && pointsTotal < 50)
            {
                CharacterResult = "Hera";
            }
            else if (pointsTotal < 50 && pointsTotal < 75)
            {
                CharacterResult ="Leia";
            }
            else if (pointsTotal < 75 && pointsTotal < 100)
            {
                CharacterResult = "Ahsoka";
            }
            else
            {
                CharacterResult ="Sabine";
            }

            CharacterName.Text = "Wow, you're such a " + CharacterResult + "!";
            pointsTotal = 0;
        }

        void OnNoButtonClicked(int index)
        {
            pointsTotal -= 25;
            QuizQuestion.SetResponse(index, "Y");
        }

        void OnYesButtonClicked(int index)
        {
            pointsTotal += 25;
            QuizQuestion.SetResponse(index, "Y");
        }

        void OnItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null) return;
            ((ListView)sender).SelectedItem = null;
        }

        void OnCellClicked(System.Object sender, System.EventArgs e)
        {
            var x = (Button)sender;
            var a = x.CommandParameter;
            var q = (QuizQuestion)a;

            if (x.Text == "Left")
            {
                OnYesButtonClicked(q.NumberOfQuestion);
            }
            else
            {
                OnNoButtonClicked(q.NumberOfQuestion);
            }
        }

        async void OnScoreQuizClicked(System.Object sender, System.EventArgs e)
        {
            // Check that all questions have been answered
            if (QuizQuestion.AllQuestionsAnswered())
            {
                // Score quiz
                ScoreQuiz();
            }
            else
            {
                await DisplayAlert("You missed a question!", "Don't be a scruffy looking nerf herder.", "OK");
            }

        }
    }
}