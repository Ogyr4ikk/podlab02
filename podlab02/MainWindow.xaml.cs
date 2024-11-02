using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace podlab02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Matrix_Add<int> _leftMatrixAdd;
        private Matrix_Add<int> _rightMatrixAdd;
        private Matrix_Multiply<int> _leftMatrixMultiply;
        private Matrix_Multiply<int> _rightMatrixMultiply;

        public MainWindow()
        {
            InitializeComponent();
            Create.Click += Create_Click;
            Result.Click += Result_Click;
            Save.Click += Save_Click;


        }
        public static int[,] Generate(int rows, int columns)
        {
            Random rnd = new Random();
            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int k = rnd.Next(1, 100);
                    matrix[i, j] = k;
                }
            }
            return matrix;
        }

        public void Create_Click(object sender, RoutedEventArgs e)
        {
            GridLeft.Columns.Clear();
            GridRight.Columns.Clear();
            int Matrix_Size = Convert.ToInt32(EnterDimensions.Text);


            double GridLeftWidth = GridLeft.ActualWidth;
            double GridLeftHeight = GridLeft.ActualHeight;
            double ColumnWidth = GridLeftWidth / Matrix_Size;
            double RowHeight = GridLeftHeight / Matrix_Size;

            int[,] LeftMatrix = Generate(Matrix_Size, Matrix_Size);
            int[,] RightMatrix = Generate(Matrix_Size, Matrix_Size);

            // Создание матриц типа Matrix<int>
            _leftMatrixAdd = new Matrix_Add<int>(Matrix_Size, Matrix_Size);
            _rightMatrixAdd = new Matrix_Add<int>(Matrix_Size, Matrix_Size);

            _leftMatrixMultiply = new Matrix_Multiply<int>(Matrix_Size, Matrix_Size);
            _rightMatrixMultiply = new Matrix_Multiply<int>(Matrix_Size, Matrix_Size);

            DataTable dataTableLeft = new DataTable();
            DataTable dataTableRight = new DataTable();

            for (int j = 0; j < Matrix_Size; j++)
            {
                dataTableLeft.Columns.Add($"{j}");
                dataTableRight.Columns.Add($"{j}");

            }
            for (int i = 0; i < Matrix_Size; i++)
            {
                DataRow rowLeft = dataTableLeft.NewRow();
                DataRow rowRight = dataTableRight.NewRow();
                for (int j = 0; j < Matrix_Size; j++)
                {
                    rowLeft[j] = LeftMatrix[i, j];
                    rowRight[j] = RightMatrix[i, j];
                }
                dataTableLeft.Rows.Add(rowLeft);
                dataTableRight.Rows.Add(rowRight);
            }


            for (int i = 0; i < Matrix_Size; i++)
            {
                for (int j = 0; j < Matrix_Size; j++)
                {
                    _leftMatrixAdd[i, j] = LeftMatrix[i, j];
                    _rightMatrixAdd[i, j] = RightMatrix[i, j];
                    _leftMatrixMultiply[i, j] = LeftMatrix[i, j];
                    _rightMatrixMultiply[i, j] = RightMatrix[i, j];
                }
            }


            for (int i = 0; i < Matrix_Size; i++)
            {
                DataGridTextColumn columnTextColumnLeft = new DataGridTextColumn();
                columnTextColumnLeft.Width = ColumnWidth;
                columnTextColumnLeft.Binding = new Binding($"[{i}]");
                GridLeft.Columns.Add(columnTextColumnLeft);

                DataGridTextColumn columnTextColumnRight = new DataGridTextColumn();
                columnTextColumnRight.Width = ColumnWidth;
                columnTextColumnRight.Binding = new Binding($"[{i}]");
                GridRight.Columns.Add(columnTextColumnRight);
            }

            GridLeft.ItemsSource = dataTableLeft.DefaultView;
            GridRight.ItemsSource = dataTableRight.DefaultView;

            GridLeft.CellEditEnding += GridLeft_CellEditEnding;
            GridRight.CellEditEnding += GridRight_CellEditEnding;

            GridLeft.RowHeight = RowHeight;
            GridRight.RowHeight = RowHeight;

            GridLeft.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            GridLeft.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            GridRight.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            GridRight.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;


        }

        private void GridLeft_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Получение значения из ячейки
            int rowIndex = e.Row.GetIndex();
            int columnIndex = e.Column.DisplayIndex;
            int value = Convert.ToInt32((e.EditingElement as TextBox).Text);
            _leftMatrixAdd[rowIndex, columnIndex] = value;
        }

        private void GridRight_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Получение значения из ячейки
            int rowIndex = e.Row.GetIndex();
            int columnIndex = e.Column.DisplayIndex;
            int value = Convert.ToInt32((e.EditingElement as TextBox).Text);
            _rightMatrixAdd[rowIndex, columnIndex] = value;
        }
        Stopwatch stopwatch = new Stopwatch();
        int[,] resultArray;
        private void Result_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();
            
            if (Choice.Text == "Сложение")
            {
                Matrix_Add<int> resultMatrix = _leftMatrixAdd + _rightMatrixAdd;
                resultArray = resultMatrix.ToArray();
                stopwatch.Stop();
                MessageBox.Show($"Результат сложения матриц:\n{resultMatrix}\n {stopwatch.ElapsedMilliseconds} мс", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            if (Choice.Text == "Умножение")
            {
                Matrix_Multiply<int> resultMatrix = _leftMatrixMultiply * _rightMatrixMultiply;
                resultArray = resultMatrix.ToArray();
                stopwatch.Stop();
                MessageBox.Show($"Результат умножения матриц:\n{resultMatrix}\n {stopwatch.ElapsedMilliseconds} мс", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение в CSV файл
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                // Получаем путь к файлу
                string filePath = saveFileDialog.FileName;

                // Сохраняем данные в файл
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < resultArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < resultArray.GetLength(1); j++)
                        {
                            writer.Write(resultArray[i, j]);
                            if (j < resultArray.GetLength(1) - 1)
                            {
                                writer.Write(",");
                            }
                        }
                        writer.WriteLine();
                    }
                }
                MessageBox.Show("Матрица сохранена в файл: " + filePath, "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }   

    

       
}
