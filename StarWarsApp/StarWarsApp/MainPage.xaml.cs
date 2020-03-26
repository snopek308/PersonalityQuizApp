using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StarWarsApp
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IList<Question> Questions { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Questions = new List<Question>();
            Questions.Add(new Question
            {
                questionOne = "Do you prefer to fight for 1) Darkside or 2) Lightside?",
                questionTwo = "Do you prefer to 1) pilot in space or 2) drive an airspeeder?",
                questionThree = "Do you prefer to 1) have a furry companion or 2) have a human companion?",
                questionFour = "Do you prefer to 1) wield a Lightsaber or 2) wield a Blaster?",
                questionFive = "Do you prefer to 1) have a sassy droid or 2) a stable droid?"
            });
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}
