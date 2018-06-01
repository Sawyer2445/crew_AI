using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Crew
{
    // <summary>
    /// Class of neuron
    /// Класс нейрона
    /// </summary>
    class Web
    {
        /// <summary>
        /// Отмаштабированные сигналы
        /// </summary>
        public int[,] mul;
        /// <summary>
        /// Веса
        /// </summary>
        public int[,] weight;
        /// <summary>
        /// Входная информация
        /// </summary>
        public int[,] input;
        /// <summary>
        /// Порог
        /// </summary>
        public int limit = 640;
        /// <summary>
        /// Сумма масштабированных сигналов
        /// </summary>
        public int sum;
        /// <summary>
        /// Сивол, который определяет нейрон
        /// </summary>
        public int sizeX;
        public int sizeY;

        public Web(int sizeX, int sizeY)
        {
            weight = new int[sizeX, sizeY];
            mul = new int[sizeX, sizeY];

            input = new int[sizeX, sizeY];
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
        public Web(int sizeX, int sizeY, string pathWeight)
        {
            int[,] arr;
            using (StreamReader sr = new StreamReader(pathWeight))
            {
                int n = int.Parse(sr.ReadLine()); //число строк
                int m = int.Parse(sr.ReadLine()); //число столбцов
                arr = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    //Считываем очередную строку из файла, в которой хранятся значения столбцов текущей строки
                    //Методом Split разбиваем ее по пробелам и заполняем массив.
                    string temp = sr.ReadLine();
                    string[] line = temp.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < m; j++)
                    {
                        arr[i, j] = int.Parse(line[j]);
                    }
                }
            }
            this.weight = arr;
            mul = new int[sizeX, sizeY];

            input = new int[sizeX, sizeY];
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
        /// <summary>
        /// Масштабирование
        /// </summary>
        public void mul_w()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    mul[x, y] = input[x, y] * weight[x, y];
                }
            }
        }
        /// <summary>
        /// Сложение
        /// </summary>
        public void Sum()
        {
            sum = 0;
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    sum += mul[x, y];
                }
            }
        }
        /// <summary>
        /// Сравнение
        /// </summary>
        /// <returns></returns>
        public bool Rez()
        {
            return sum >= limit ? true : false;
        }

        public void incW()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    weight[x, y] += input[x, y];
                }
            }
        }
        public void decW()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    weight[x, y] -= input[x, y];
                }
            }
        }
        public void saveWeight(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(weight.GetLength(0));
                sw.WriteLine(weight.GetLength(1));
                for (int i = 0; i < weight.GetLength(0); i++)
                {
                    string[] line = new string[weight.GetLength(1)];
                    for (int j = 0; j < weight.GetLength(1); j++)
                    {
                        //Cобираем в строковый массив столбцы текущей строки массива
                        line[j] = weight[i, j].ToString();
                    }
                    //Метод Join() склеивает элементы массива line в одну строку, разделяя их пробелами
                    sw.WriteLine(String.Join(" ", line));
                }
            }
        }
    }
}
