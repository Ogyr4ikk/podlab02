using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace podlab02
{
    public class Matrix_Multiply<T> where T : struct
    {
        // Поля для хранения данных матрицы
        private T[,] _matrix;

        // Свойство для доступа к размеру матрицы
        public int Rows { get; }
        public int Columns { get; }

        // Конструктор для создания матрицы заданного размера
        public Matrix_Multiply(int rows, int columns)
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

        // Перегрузка оператора умножения для матриц
        public static Matrix_Multiply<T> operator *(Matrix_Multiply<T> matrix1, Matrix_Multiply<T> matrix2)
        {

            // Создание новой матрицы для хранения результата
            Matrix_Multiply<T> resultMatrix = new Matrix_Multiply<T>(matrix1.Rows, matrix2.Columns);

            // Выполнение умножения элементов матриц
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    dynamic sum = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        sum += (dynamic)matrix1[i, k] * (dynamic)matrix2[k, j];
                    }
                    resultMatrix[i, j] = sum;
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
