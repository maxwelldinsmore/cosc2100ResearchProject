using Microsoft.Maui.Controls;

namespace cosc1200ResearchProject
{
    public partial class MainPage : ContentPage
    {
        private int numOfDays = 8; // add 1 for the time column
        private int numOfClasses = 0;
        private int startTime = 7; // minus 1 for the time row
        private int endTime = 17;


        public MainPage()
        {
            InitializeComponent();
            generateEmptyGrid();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            AddClass addClass = new AddClass();
            // Was planning on a new window but this is cool too
            Navigation.PushAsync(addClass);
        
        }

        private void generateEmptyGrid()
        {
            Grid grid = new Grid();
            grid.Children.Add(new Border
            {
            });

            for (int days = 0; days < numOfDays; days++)
            {
                ColumnDefinition column = new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                };
                grid.ColumnDefinitions.Add(column);
            }

            for (int hours = startTime; hours < endTime; hours++)
            {
                RowDefinition row = new RowDefinition
                {
                    Height = new GridLength(1, GridUnitType.Star)
                };
                grid.RowDefinitions.Add(row);
            }
            Content = grid;
            for (int row = 0; row < grid.RowDefinitions.Count; row++)
            {
                for (int col = 0; col < grid.ColumnDefinitions.Count; col++)
                {
                    Border border = new Border
                    {
                        Stroke = Colors.Black,
                        StrokeThickness = 1
                    };

                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, col);
                    grid.Children.Add(border);
                }
            }
        }
    }

}
