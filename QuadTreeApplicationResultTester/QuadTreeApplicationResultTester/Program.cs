using System;
using System.IO;
using System.Windows.Forms;

namespace QuadTreeApplicationResultTester
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string fileName = GetFilePath();
            string[] contents = File.ReadAllLines(fileName);
            Console.WriteLine("Enter the coordinates range XLeft, XRight, YLower, YUpper (With Commas)");
            string[] coordinates = Console.ReadLine().Split(',');
            CheckCoordinates(contents, coordinates);
        }

        private static void CheckCoordinates(string[] contents, string[] coordinates)
        {
            int counter = 0;
            for(int i = 0; i < contents.Length; i++ )
            {
                string[] contentsCoordinates = contents[i].Split(',');
                if((Convert.ToDouble(contentsCoordinates[0]) >= Convert.ToInt32(coordinates[0]) &&
                    Convert.ToDouble(contentsCoordinates[0]) <= Convert.ToInt32(coordinates[1])) &&
                   (Convert.ToDouble(contentsCoordinates[1]) >= Convert.ToInt32(coordinates[2]) &&
                    Convert.ToDouble(contentsCoordinates[1]) <= Convert.ToInt32(coordinates[3])))
                {
                    counter++;
                }
                else
                {
                    Console.WriteLine("Not in range X:" + contentsCoordinates[0] + " Y:" + contentsCoordinates[1]);
                }
            }
            Console.WriteLine(counter + "/" + contents.Length + " records within range");
            var pause = Console.ReadLine();
        }

        private static string GetFilePath()
        {
            string fileName = "";
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            fileName = openFileDialog.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return fileName;
        }
    }
}
