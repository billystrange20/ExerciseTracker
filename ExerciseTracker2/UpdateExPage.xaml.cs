using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseTracker2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateExPage : ContentPage
    {
        public UpdateExPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.ExDatabase.GetExerciseAsync();
        }

        Exercise lastSelection;
        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lastSelection = e.CurrentSelection[0] as Exercise;
        }

        async void Update_OnClicked(object sender, EventArgs e)
        {
            if (lastSelection != null)
            {
                lastSelection.AvgWeight = avgWeight.Text;
                lastSelection.PBWeight = pbWeight.Text;

                await App.ExDatabase.UpdateExerciseAsync(lastSelection);

                collectionView.ItemsSource = await App.ExDatabase.GetExerciseAsync();

                await DisplayAlert("Exercise Updated", "", "OK");
            }
        }
    }
}