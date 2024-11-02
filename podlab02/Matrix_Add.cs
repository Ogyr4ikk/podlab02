using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace podlab02
{
    public class Matrix_Add<T> where T : struct
    {
        // Поля для хранения данных матрицы
        private T[,] _matrix;

        // Свойство для доступа к размеру матрицы
        public int Rows { get; }
        public int Columns { get; }

        // Конструктор для создания матрицы заданного размера
        public Matrix_Add(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _matrix = new T[rows, columns];
        }

        // Индексатор для доступа к элементам матрицы
        public T this[int row, int column]
        {
            get { return _matrix[row, column]; }
            set { _matrix[row, column] = value; }
        }

        // Перегрузка оператора сложения для матриц
        public static Matrix_Add<T> operator +(Matrix_Add<T> matrix1, Matrix_Add<T> matrix2)
        {

            // Создание новой матрицы для хранения результата
            Matrix_Add<T> resultMatrix = new Matrix_Add<T>(matrix1.Rows, matrix1.Columns);

            // Выполнение сложения элементов матриц
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    resultMatrix[i, j] = (dynamic)matrix1[i, j] + (dynamic)matrix2[i, j];
                }
            }

            return resultMatrix;
        }

        // Метод для вывода матрицы в строковое представление
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result += _matrix[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }

        public T[,] ToArray()
        {
            return _matrix;
        }
    }
}
