using System;
using System.Collections.Generic;
using System.ComponentModel;
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
