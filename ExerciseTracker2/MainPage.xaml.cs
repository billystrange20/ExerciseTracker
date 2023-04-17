using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExerciseTracker2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            chest.ItemsSource = await App.ExDatabase.GetAllExerciseTypeAsync("Chest");
            tricep.ItemsSource = await App.ExDatabase.GetAllExerciseTypeAsync("Tricep");
            bicep.ItemsSource = await App.ExDatabase.GetAllExerciseTypeAsync("Bicep");
            back.ItemsSource = await App.ExDatabase.GetAllExerciseTypeAsync("Back");
            shoulders.ItemsSource = await App.ExDatabase.GetAllExerciseTypeAsync("Shoulders");
            abs.ItemsSource = await App.ExDatabase.GetAllExerciseTypeAsync("Abs");
            legs.ItemsSource = await App.ExDatabase.GetAllExerciseTypeAsync("Legs");
        }

        private async void UpdateEx_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateExPage());
        }

        private async void NewEx_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewExPage());
        }

        private async void DelEx_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DelExPage());
        }
    }
}
