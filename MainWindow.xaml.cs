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

namespace BankoProgramRefactored
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Dictionary<string, Dictionary<string, int[]>> bankoPlates = new Dictionary<string, Dictionary<string, int[]>>();
        public static List<int> drawnNumberList = new List<int>();
        public static string gamePhaseString = "1row";
        public static MainWindow window { get; private set; }
        DrawnNumberButton drawNumber = new DrawnNumberButton();
        PlateFileHandler fileHandler = new PlateFileHandler();
        PlateSelection plateSelection = new PlateSelection();
        FullRowChecker fullRowChecker = new FullRowChecker();

        public MainWindow()
        {
            //Initializes items needed at the start
            InitializeComponent();
            drawnNumberInput.KeyDown += EnterKeyPressed;
            gamePhase.Items.Add("1 Row");
            gamePhase.Items.Add("2 Rows");
            gamePhase.Items.Add("Full Plate");
            gamePhase.SelectedIndex = 0;
            window = this;
        }

        // Used for choosing and handling the banko-file
        private void chooseFile_Click(object sender, RoutedEventArgs e)
        {
            fileHandler.chooseFile();
        }

        // Handles the loading of plates on the screen.
        private void ChoosePlate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            plateSelection.ChoosePlate();
        }

        private void EnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        //Called when pressing "enter" or "Input" button. Adds number to drawnNumberList and WPF list and then checks for full plate or rows
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            drawNumber.DrawnNumber();
            fullRowChecker.CheckForRowsOrFullPlates();
        }

        // Changes which gamephase we are in
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
    }
}