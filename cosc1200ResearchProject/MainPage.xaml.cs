using Microsoft.Maui.Controls;

namespace cosc1200ResearchProject
{
    public partial class MainPage : ContentPage
    {
        private int numOfDays = 8; // add 1 for the time column
        private int numOfClasses = 0;
        private int startTime = 7; // minus 1 for the time row
        private int endTime = 17;

        enum weekDays
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }
        
        public MainPage()
        {
            InitializeComponent();
            generateEmptyGrid();
        }

        private void generateEmptyGrid()
        {
            Grid grid = new Grid();
            

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
                    Label label = new Label
                    {
                        HorizontalOptions = LayoutOptions.Fill,
                        VerticalOptions = LayoutOptions.Fill,
                        Margin = new Thickness(1),
                        BackgroundColor = Color.FromRgba(200, 255, 255, 255),
                        TextColor = Color.FromRgba(1, 1, 1, 255),

                    };
                    if (col == 0 && row !=0)
                    {
                        int currentTime = startTime + row;
                        label = new Label
                        {
                            Text = currentTime + ":00",
                            HorizontalOptions = LayoutOptions.Fill,
                            VerticalOptions = LayoutOptions.Fill,
                            Margin = new Thickness(1),
                            BackgroundColor = Color.FromRgba(200, 255, 255, 255),
                            TextColor = Color.FromRgba(1, 1, 1, 255),

                        };
                        ToolTipProperties.SetText(label, "Time for" + currentTime + ":00");
                    } 
                    else if (row == 0 && col != 0)
                    {
                        string weekday = Enum.GetName(typeof(weekDays), col);
                        label = new Label
                        {
                            Text = weekday,
                            HorizontalOptions = LayoutOptions.Fill,
                            VerticalOptions = LayoutOptions.Fill,
                            Margin = new Thickness(1),
                            BackgroundColor = Color.FromRgba(200, 255, 255, 255),
                            TextColor = Color.FromRgba(1, 1, 1, 255),

                        };
                        ToolTipProperties.SetText(label, "Day of week: " + weekday);
                    } 
                    else
                    {
                        label = new Label
                        {
                            HorizontalOptions = LayoutOptions.Fill,
                            VerticalOptions = LayoutOptions.Fill,
                            Margin = new Thickness(1),
                            BackgroundColor = Color.FromRgba(200, 255, 255, 255),
                            TextColor = Color.FromRgba(1, 1, 1, 255),
                        };
                        ToolTipProperties.SetText(label, "Click to add a class at this time");

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += OnLabelClick;
                        label.GestureRecognizers.Add(tapGestureRecognizer);
                    }
                    Grid.SetRow(label, row);
                    Grid.SetColumn(label, col);
                    grid.Children.Add(label);
                }
            }
        }

        private void OnLabelClick(object sender, EventArgs e)
        {
            AddClass addClass = new AddClass();
            // Was planning on a new window but this is cool too
            Navigation.PushAsync(addClass);
        }
    }

}
