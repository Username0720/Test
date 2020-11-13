using System;

namespace Test_01
{
    class Program
    {
        //метод для вывода массива
        static void Show(int[] arr)
        {
            foreach (int c in arr)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            char ch = 'y';  //конструкция while для многократного использования приложения
            while (ch == 'y')
            {
                int max = 0;    //переменная для хранения макс элемента
                bool check = false; //переменная, с помощью которой проверям наличие четного элемента стоящего на нечетном месте
                int n = 10; //размерность массиво по умолчанию десять

                bool accepted = false;
                while(!accepted)
                {
                    Console.Write("Введите размерность массива: ");
                    try
                    {
                        n = Convert.ToInt32(Console.ReadLine());
                        accepted = true;
                    }
                    catch (Exception e) 
                    { Console.WriteLine("Введите целое значение. Иначе размерность массива будет по умолчанию (10).", e); }
                    
                }//с помощью while и try catch обрабатываем ошибку неверного ввода размерности массива

                int[] array = new int[n];
                Random rnd = new Random();
                //создаем массив натуральных чисел, заполняем рандомными значениями
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(100);
                }
                Console.WriteLine("Исходный массив натуральных чисел: ");
                Show(array);    //выводим массим
                //удваиваем значения четных переменных, находящихся на нечетных местах
                for (int i = 1; i < array.Length; i += 2)   //массив начинается с 0(четного) элемента
                {
                    if (array[i] % 2 == 0)
                    {
                        check = true;   //если if сработал, сообщение не выводится
                        array[i] *= 2;
                    }
                }
                //ищем макс знач нечетн эл, стоящих на четных местах
                for (int i = 0; i < array.Length; i += 2)   //массив начинается с 0(четного) элемента
                {
                    if (array[i] % 2 != 0)
                        if (max < array[i]) max = array[i];
                }

                Console.WriteLine("Прим. массив начинается с 0(четного) места");
                Console.WriteLine("Преобразованный массив: ");
                Show(array);
                Console.WriteLine($"Максимальное значение из нечетных элементов стоящих на четных местах - {max}");
                if (check == false)
                    Console.WriteLine("В массиве не оказалось ни одного четного элемента стоящего на нечетном месте");

                Console.WriteLine("Нажмите - y, чтобы попробовать заново, другую, чтобы выйти.");
                ch = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
