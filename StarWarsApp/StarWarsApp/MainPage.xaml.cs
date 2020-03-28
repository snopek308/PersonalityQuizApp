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
        QuizDataViewModel qdvm = new QuizDataViewModel();

        public MainPage()
        {
            InitializeComponent();

            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}
