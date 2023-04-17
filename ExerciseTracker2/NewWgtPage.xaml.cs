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
    public partial class NewWgtPage : ContentPage
    {
        public NewWgtPage()
        {
            InitializeComponent();
        }

        async void AddWeight_OnClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(avgWeight.Text))
            {
                //String date = String.Format("{0:dd/MM/yy}", datePicker.Date);
                //DateTime d = datePicker.Date;
                
                

                await App.WgtDatabase.SaveWeightAsync(new Weight
                {
                    DateWeight = datePicker.Date,
                    UserWeight = avgWeight.Text
                });

                avgWeight.Text = String.Empty;

                await DisplayAlert("New Weight Added", "", "OK");
            }
        }
    }
}