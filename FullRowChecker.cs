using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankoProgramRefactored
{
    public class FullRowChecker
    {
        //Checks for full rows or plates.
        public void CheckForRowsOrFullPlates()
        {
            foreach (KeyValuePair<string, Dictionary<string, int[]>> bankoPlate in MainWindow.bankoPlates)
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

                switch (MainWindow.gamePhaseString)
                {
                    case "1row":
                        if (fullRowsCount == 1)
                        {
                            MainWindow.window.choosePlate.SelectedItem = plateName;
                            MessageBox.Show($"1 Row on plate {plateName}", "Banko!", MessageBoxButton.OK, MessageBoxImage.Information);
                            MainWindow.window.gamePhase.SelectedItem = "2 Rows";
                        }
                        break;
                    case "2rows":
                        if (fullRowsCount == 2)
                        {
                            MainWindow.window.choosePlate.SelectedItem = plateName;
                            MessageBox.Show($"2 Rows on plate {plateName}", "Banko!", MessageBoxButton.OK, MessageBoxImage.Information);
                            MainWindow.window.gamePhase.SelectedItem = "Full Plate";
                        }
                        break;
                    case "fullPlate":
                        if (fullRowsCount == 3)
                        {
                            MainWindow.window.choosePlate.SelectedItem = plateName;
                            MessageBox.Show($"Full Plate on {plateName}!", "Banko!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        break;
                }
            }
        }

        //Checks each row for numbers that are drawn
        private bool IsRowFull(int[] row)
        {
            foreach (int number in row)
            {
                if (!MainWindow.drawnNumberList.Contains(number) && number != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
