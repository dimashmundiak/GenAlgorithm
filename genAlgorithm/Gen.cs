using System;
using System.Linq;

namespace genAlgorithm
{
    public class Gen
    {
        private readonly int[,] _arr;

        private readonly int[] _schema = {0, 2, 6, 9};

        private int _maxFf = 0;

        private int _maxIndex = 0;

        public Gen()
        {
            _arr = new int[10, 10];
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _arr[i, j] = random.Next(0, 16);
                }
            }
        }

        public void ShowArray()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"[{i}] = ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"{_arr[i,j]} ");
                }
                Console.WriteLine($" FF={Count(i)}");
            }
        }

        public int Count(int index)
        {
            var sum = _arr[index, 1] + _arr[index, 3] + _arr[index, 6];
            var mul = _arr[index, 0] * _arr[index, 2] * _arr[index, 4] * _arr[index, 5] * _arr[index, 7] *
                      _arr[index, 8] * _arr[index, 9];
            var result = sum + mul;
            if (result > _maxFf)
            {
                _maxIndex = index;
                _maxFf = result;
            }
            return sum + mul;
        }

        public void Crossing(int father, int mother, int firstChildIndex, int secondChildIndex)
        {
            for (int i = 0; i < 10; i++)
            {
                if (_schema.Contains(i))
                {
                    _arr[firstChildIndex, i] = _arr[father, i];
                    _arr[secondChildIndex, i] = _arr[mother, i];
                }
                else
                {
                    _arr[firstChildIndex, i] = _arr[mother, i];
                    _arr[secondChildIndex, i] = _arr[father, i];
                }
            }
        }

        public void Mutation()
        {
            var random = new Random();
            for (int i = 6; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (random.NextDouble() < 0.24)
                    {
                        _arr[i, j] = random.Next(0, 16);
                    }
                }
            }
        }

        public void ShowMax()
        {
            Console.WriteLine($"Max is {_maxIndex} = {_maxFf}");
        }
    }
}
