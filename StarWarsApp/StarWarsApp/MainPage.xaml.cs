using StarWarsApp.Models;
using StarWarsApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static StarWarsApp.Models.Question;

namespace StarWarsApp
{

    public partial class MainPage : ContentPage
    {

        public int pointsTotal = 0;
        SwapiApiService swapiApiService;

        public MainPage()
        {
            InitializeComponent();
            swapiApiService = new SwapiApiService(new HttpClient());
            listView.BindingContext = QuizQuestion.All;
        }

        public async Task ScoreQuizAsync()
        {
            string characterName = "";
            StarWarsCharacter CharacterResult;

            if(pointsTotal < 0)
            {
                CharacterResult = await swapiApiService.GetStarWarsCharacter("people/4");
                characterName = CharacterResult.name;
            }
            else if (pointsTotal < 0 && pointsTotal < 50)
            {
                CharacterResult = await swapiApiService.GetStarWarsCharacter("people/10");
                characterName = CharacterResult.name;
            }
            else if (pointsTotal < 50 && pointsTotal < 75)
            {
                CharacterResult = await swapiApiService.GetStarWarsCharacter("people/5");
                characterName = CharacterResult.name;
            }
            else if (pointsTotal < 75 && pointsTotal < 100)
            {
                CharacterResult = await swapiApiService.GetStarWarsCharacter("people/1");
                characterName = CharacterResult.name;
            }
            else
            {
                CharacterResult = await swapiApiService.GetStarWarsCharacter("people/3");
                characterName = CharacterResult.name;
            }

            CharacterName.Text = "Wow, you're such a " + characterName + "!";
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
                await ScoreQuizAsync();
            }
            else
            {
                await DisplayAlert("You missed a question!", "Don't be a scruffy looking nerf herder.", "OK");
            }

        }
    }
}