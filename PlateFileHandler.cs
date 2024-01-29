using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;

namespace BankoProgramRefactored
{
    public class PlateFileHandler
    {
        //Prompts the user to choose a file
        public void chooseFile()
        {
            OpenFileDialog selectFile = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Select a CSV File"
            };

            if (selectFile.ShowDialog() == true)
            {
                string bankoFilePath = selectFile.FileName;

                List<BankoPlateClass> bankoPlatesFromFile = ReadBankoPlateFromCsv(bankoFilePath);

                foreach (BankoPlateClass bankoPlate in bankoPlatesFromFile)
                {
                    if (!MainWindow.bankoPlates.Keys.Contains(bankoPlate.plate))
                    {
                        var rowsForThisPlate = bankoPlatesFromFile
                        .Where(row => row.plate == bankoPlate.plate)
                        .OrderBy(row => row.row)
                        .ToList();

                        // Create a dictionary for the current plate
                        Dictionary<string, int[]> plateData = new Dictionary<string, int[]>
                        {
                            { "Row1", rowsForThisPlate[0].column },
                            { "Row2", rowsForThisPlate[1].column },
                            { "Row3", rowsForThisPlate[2].column }
                        };
                        MainWindow.bankoPlates.Add(bankoPlate.plate, plateData);
                    }
                }
                MainWindow.window.choosePlate.ItemsSource = MainWindow.bankoPlates.Keys;
                MainWindow.window.choosePlate.SelectedIndex = 0;
            }
        }

        // Reads the chosen file and returns it to a list
        private List<BankoPlateClass> ReadBankoPlateFromCsv(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            using (CsvReader csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return csvReader.GetRecords<BankoPlateClass>().ToList();
            }
        }
    }

}
