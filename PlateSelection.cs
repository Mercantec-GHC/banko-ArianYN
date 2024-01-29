using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using BankoProgramRefactored;

namespace BankoProgramRefactored
{
    public class PlateSelection
    {
        //Handles the visualization of the Banko-Plates
        public void ChoosePlate()
        {
            string selectedPlateName = MainWindow.window.choosePlate.SelectedItem.ToString();
            if (MainWindow.bankoPlates.ContainsKey(selectedPlateName))
            {
                Dictionary<string, int[]> selectedPlate = MainWindow.bankoPlates[selectedPlateName];
                int[] row1Numbers = selectedPlate["Row1"];
                int[] row2Numbers = selectedPlate["Row2"];
                int[] row3Numbers = selectedPlate["Row3"];

                for (int i = 0; i < row1Numbers.Length; i++)
                {
                    TextBox textBox = (TextBox)MainWindow.window.FindName($"row1box{i + 1}");
                    if (row1Numbers[i] != 0)
                    {
                        textBox.Text = row1Numbers[i].ToString();

                        if (MainWindow.drawnNumberList.Contains(row1Numbers[i]))
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
                    TextBox textBox = (TextBox)MainWindow.window.FindName($"row2box{i + 1}");
                    if (row2Numbers[i] != 0)
                    {
                        textBox.Text = row2Numbers[i].ToString();

                        if (MainWindow.drawnNumberList.Contains(row2Numbers[i]))
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
                    TextBox textBox = (TextBox)MainWindow.window.FindName($"row3box{i + 1}");
                    if (row3Numbers[i] != 0)
                    {
                        textBox.Text = row3Numbers[i].ToString();

                        if (MainWindow.drawnNumberList.Contains(row3Numbers[i]))
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
    }
}
