using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using BankoProgramRefactored;

namespace BankoProgramRefactored
{
    public class DrawnNumberButton
    {
        // Processes the drawn number in the input
        public void DrawnNumber()
        {
            int drawnNumber;
            try
            {
                drawnNumber = int.Parse(MainWindow.window.drawnNumberInput.Text);
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error with inputted number {error.Message}");
                return;
            }
            if (drawnNumber < 0 || drawnNumber > 90)
            {
                MessageBox.Show("Are you drunk? Please input a number from 1-90", "Number Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MainWindow.drawnNumberList.Contains(drawnNumber))
            {
                MessageBox.Show($@"{drawnNumber} has already been drawn.", "Already Drawn!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            MainWindow.drawnNumberList.Add(drawnNumber);
            MainWindow.window.drawnNumberInput.Clear();
            MainWindow.window.drawnNumbersListBox.Items.Add(drawnNumber);
            MainWindow.window.drawnNumbersListBox.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("", System.ComponentModel.ListSortDirection.Ascending));

            MainWindow.window.choosePlate.RaiseEvent(new SelectionChangedEventArgs(ComboBox.SelectionChangedEvent, new List<object>(), new List<object>()));
        }
    }
}
