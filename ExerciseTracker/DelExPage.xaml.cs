using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelExPage : ContentPage
    {
        public DelExPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetExerciseAsync();
        }

        Exercise lastSelection;
        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lastSelection = e.CurrentSelection[0] as Exercise;
        }

        async void Delete_OnClicked(object sender, EventArgs e)
        {
            await App.Database.DeleteExerciseAsync(lastSelection);

            collectionView.ItemsSource = await App.Database.GetExerciseAsync();
        }
    }
}