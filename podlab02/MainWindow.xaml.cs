using System;
using System.Collections.Generic;
using System.Data;
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
        public MainWindow()
        {
            InitializeComponent();
            Create.Click += Create_Click;
        }
        public static int[,] Generate(int rows, int columns)
        {
            Random rnd = new Random();
            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int k = rnd.Next(0, 100);
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

            DataTable dataTableLeft = new DataTable();
            DataTable dataTableRight = new DataTable();

            for (int j=0; j < Matrix_Size; j++)
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

            GridLeft.RowHeight = RowHeight;
            GridRight.RowHeight = RowHeight;
            GridLeft.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            GridLeft.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            GridRight.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            GridRight.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }

       
    }
}
