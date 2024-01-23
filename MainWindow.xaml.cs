using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Banko_Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Dictionary<string, int[]>> bankoPlates = new Dictionary<string, Dictionary<string, int[]>>();
        List<int> drawnNumberList = new List<int>();
        string gamePhaseString = "1row";

        public MainWindow()
        {
            InitializeComponent();
            drawnNumberInput.KeyDown += EnterKeyPressed;


            //Add gamephases and create dictionaries for plates

            Dictionary<string, int[]> Arian1 = new Dictionary<string, int[]>
        {
            { "Row1", new int[] { 0, 11, 20, 0, 0, 0, 61, 73, 80 } },
            { "Row2", new int[] { 6, 0, 0, 34, 47, 0, 63, 74, 0 } },
            { "Row3", new int[] { 0, 0, 29, 38, 0, 55, 67, 75, 0 } }
        };

            Dictionary<string, int[]> Arian2 = new Dictionary<string, int[]>
        {
            { "Row1", new int[] { 3, 10, 0, 31, 41, 55, 0, 0, 0 } },
            { "Row2", new int[] { 5, 0, 23, 36, 0, 0, 0, 76, 83 } },
            { "Row3", new int[] { 0, 14, 28, 39, 0, 0, 69, 0, 87 } }
        };

            Dictionary<string, int[]> Arian3 = new Dictionary<string, int[]>
        {
            { "Row1", new int[] { 1, 10, 0, 0, 0, 0, 62, 73, 80 } },
            { "Row2", new int[] { 3, 16, 0, 32, 45, 57, 0, 0, 0 } },
            { "Row3", new int[] { 9, 18, 29, 34, 0, 0, 0, 76, 0 } }
        };

            Dictionary<string, int[]> Arian4 = new Dictionary<string, int[]>
        {
            { "Row1", new int[] { 2, 0, 20, 0, 0, 54, 0, 70, 83 } },
            { "Row2", new int[] { 0, 13, 22, 33, 44, 0, 0, 0, 88 } },
            { "Row3", new int[] { 9, 0, 0, 35, 45, 0, 66, 78, 0 } }
        };

            Dictionary<string, int[]> Arian5 = new Dictionary<string, int[]>
        {
            { "Row1", new int[] { 4, 0, 0, 31, 41, 0, 61, 0, 83 } },
            { "Row2", new int[] { 7, 14, 0, 0, 44, 54, 64, 0, 0 } },
            { "Row3", new int[] { 9, 0, 27, 39, 0, 0, 0, 79, 88 } }
        };

            bankoPlates.Add("Arian1", Arian1);
            bankoPlates.Add("Arian2", Arian2);
            bankoPlates.Add("Arian3", Arian3);
            bankoPlates.Add("Arian4", Arian4);
            bankoPlates.Add("Arian5", Arian5);

            gamePhase.Items.Add("1 Row");
            gamePhase.Items.Add("2 Rows");
            gamePhase.Items.Add("Full Plate");
            gamePhase.SelectedIndex = 0;

            choosePlate.ItemsSource = bankoPlates.Keys;
            choosePlate.SelectedIndex = 0;
        }

        //Change banko plate to match the selected dictionary.
        private void ChoosePlate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedPlateName = choosePlate.SelectedItem.ToString();
            if (bankoPlates.ContainsKey(selectedPlateName))
            {
                Dictionary<string, int[]> selectedPlate = bankoPlates[selectedPlateName];
                int[] row1Numbers = selectedPlate["Row1"];
                int[] row2Numbers = selectedPlate["Row2"];
                int[] row3Numbers = selectedPlate["Row3"];

                for (int i = 0; i < row1Numbers.Length; i++)
                {
                    TextBox textBox = (TextBox)this.FindName($"row1box{i + 1}");
                    if (row1Numbers[i] != 0)
                    {
                        textBox.Text = row1Numbers[i].ToString();

                        if (drawnNumberList.Contains(row1Numbers[i]))
                        {
                            textBox.IsEnabled = true;
                            textBox.Background = Brushes.LightGreen;
                        }
                        else
                        {
                            textBox.IsEnabled = true;
                            textBox.Background = Brushes.White;
                        }
                    }
                    else
                    {
                        textBox.Text = "";
                        textBox.Background = Brushes.White;
                        textBox.IsEnabled = false;
                    }
                }

                for (int i = 0; i < row2Numbers.Length; i++)
                {
                    TextBox textBox = (TextBox)this.FindName($"row2box{i + 1}");
                    if (row2Numbers[i] != 0)
                    {
                        textBox.Text = row2Numbers[i].ToString();

                        if (drawnNumberList.Contains(row2Numbers[i]))
                        {
                            textBox.IsEnabled = true;
                            textBox.Background = Brushes.LightGreen;
                        }
                        else
                        {
                            textBox.IsEnabled = true;
                            textBox.Background = Brushes.White;
                        }
                    }
                    else
                    {
                        textBox.Text = "";
                        textBox.Background = Brushes.White;
                        textBox.IsEnabled = false;
                    }
                }

                for (int i = 0; i < row3Numbers.Length; i++)
                {
                    TextBox textBox = (TextBox)this.FindName($"row3box{i + 1}");
                    if (row3Numbers[i] != 0)
                    {
                        textBox.Text = row3Numbers[i].ToString();

                        if (drawnNumberList.Contains(row3Numbers[i]))
                        {
                            textBox.IsEnabled = true;
                            textBox.Background = Brushes.LightGreen;
                        }
                        else
                        {
                            textBox.IsEnabled = true;
                            textBox.Background = Brushes.White;
                        }
                    }
                    else
                    {
                        textBox.Text = "";
                        textBox.Background = Brushes.White;
                        textBox.IsEnabled = false;
                    }
                }
            }
        }

        //Adds drawn number to list, and checks for banko on every plate
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int drawnNumber;

            drawnNumber = int.Parse(drawnNumberInput.Text);
            if (drawnNumber < 0 || drawnNumber > 90)
            {
                MessageBox.Show("Are you drunk? Please input a number from 1-90", "Number Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (drawnNumberList.Contains(drawnNumber))
            {
                MessageBox.Show($@"{drawnNumber} has already been drawn.", "Already Drawn!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            drawnNumberList.Add(drawnNumber);
            drawnNumberInput.Clear();
            drawnNumbersListBox.Items.Add(drawnNumber);
            drawnNumbersListBox.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("", System.ComponentModel.ListSortDirection.Ascending));

            choosePlate.RaiseEvent(new SelectionChangedEventArgs(ComboBox.SelectionChangedEvent, new List<object>(), new List<object>()));

            CheckForRowsOrFullPlates();
        }

        private void EnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        //Gets called when changing the GamePhase in the WPF ComboBox
        private void GamePhase_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (gamePhase.SelectedItem)
            {
                case "1 Row":
                    gamePhaseString = "1row";
                    break;
                case "2 Rows":
                    gamePhaseString = "2rows";
                    break;
                case "Full Plate":
                    gamePhaseString = "fullPlate";
                    break;
            }
        }

        //This checks if a row is full, by checking every number in the row
        private bool IsRowFull(int[] row)
        {
            foreach (int number in row)
            {
                if (!drawnNumberList.Contains(number) && number != 0)
                {
                    return false;
                }
            }
            return true;
        }

        //Notifies the user that there is "Banko" in a plate depending on the gamephase.
        private void CheckForRowsOrFullPlates()
        {
            foreach (KeyValuePair<string, Dictionary<string, int[]>> bankoPlate in bankoPlates)
            {
                int fullRowsCount = 0;
                string plateName = bankoPlate.Key;
                Dictionary<string, int[]> plate = bankoPlate.Value;

                foreach (KeyValuePair<string, int[]> keyValuePair in plate)
                {
                    if (IsRowFull(keyValuePair.Value))
                    {
                        fullRowsCount++;
                    }
                }

                switch (gamePhaseString)
                {
                    case "1row":
                        if (fullRowsCount == 1)
                        {
                            choosePlate.SelectedItem = plateName;
                            MessageBox.Show($"1 Row on plate {plateName}", "Banko!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        break;
                    case "2rows":
                        if (fullRowsCount == 2)
                        {
                            choosePlate.SelectedItem = plateName;
                            MessageBox.Show($"2 Rows on plate {plateName}", "Banko!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        break;
                    case "fullPlate":
                        if (fullRowsCount == 3)
                        {
                            choosePlate.SelectedItem = plateName;
                            MessageBox.Show($"Full Plate on {plateName}!", "Banko!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        break;
                }
            }
        }
    }
}