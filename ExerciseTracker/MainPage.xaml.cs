using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExerciseTracker
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
            chest.ItemsSource = await App.Database.GetAllExerciseTypeAsync("Chest");
            tricep.ItemsSource = await App.Database.GetAllExerciseTypeAsync("Tricep");
            bicep.ItemsSource = await App.Database.GetAllExerciseTypeAsync("Bicep");
            back.ItemsSource = await App.Database.GetAllExerciseTypeAsync("Back");
            shoulders.ItemsSource = await App.Database.GetAllExerciseTypeAsync("Shoulders");
            abs.ItemsSource = await App.Database.GetAllExerciseTypeAsync("Abs");
            legs.ItemsSource = await App.Database.GetAllExerciseTypeAsync("Legs");
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
