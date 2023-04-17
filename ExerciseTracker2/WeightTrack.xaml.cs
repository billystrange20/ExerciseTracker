using Microcharts;
using SkiaSharp;
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
    public partial class WeightTrack : ContentPage
    {

        public WeightTrack()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var weightDB = new List<Weight>(await App.WgtDatabase.GetAllWeightDateOrderedChartAsync());
            var weightData = new Dictionary<DateTime, int>();
            foreach (var info in weightDB)
            {
                var date = info.DateWeight;
                var weight = info.UserWeight;
                weightData.Add(date, Int32.Parse(weight));
            }

            var entries = new List<ChartEntry>();
            foreach (var data in weightData)
            {
                entries.Add(new ChartEntry(data.Value)
                {
                    Label = data.Key.ToString("dd/MM/yy"),
                    ValueLabel = data.Value.ToString() + "kg",
                    Color = SKColor.Parse("#283A77")
                });
            }
            
            
            collectionView.ItemsSource = await App.WgtDatabase.GetAllWeightDateOrderedAsync();            
            
            chartViewLine.Chart = new LineChart { Entries = entries, LineMode = LineMode.Spline, LabelTextSize = 30f, LabelOrientation = Orientation.Vertical, ValueLabelOrientation = Orientation.Horizontal };

        }

        Weight lastSelection;
        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lastSelection = e.CurrentSelection[0] as Weight;
        }

        async void DelWgt_OnClicked(object sender, EventArgs e)
        {
            await App.WgtDatabase.DeleteWeightAsync(lastSelection);

            collectionView.ItemsSource = await App.WgtDatabase.GetAllWeightDateOrderedAsync();

            await DisplayAlert("Weight Deleted", "", "OK");

            OnAppearing();
        }

        private async void NewWgt_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewWgtPage());
        }

    }
}