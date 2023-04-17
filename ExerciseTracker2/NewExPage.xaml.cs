using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseTracker2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExPage : ContentPage
    {

        public NewExPage()
        {
            InitializeComponent();
        }

        public string pickerItem;  

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            pickerItem = selectedItem.ToString();
        }

        async void AddEx_OnClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(exName.Text) && !string.IsNullOrWhiteSpace(avgWeight.Text) && !string.IsNullOrWhiteSpace(pbWeight.Text))
            {
                await App.ExDatabase.SaveExerciseAsync(new Exercise
                {
                    ExName = exName.Text,
                    ExType = pickerItem,
                    AvgWeight = avgWeight.Text,
                    PBWeight = pbWeight.Text
                    
                }) ;

                exName.Text = String.Empty;
                avgWeight.Text = String.Empty;
                pbWeight.Text = String.Empty;

                await DisplayAlert("New Exercise Added", "", "OK");
            }
        }
    }
}