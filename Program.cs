namespace Asterisks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] playing_field = Playing_field();
            int[,] results = new int[3, 3];
            The_GAME(playing_field, results);

            // Сама игра
            void The_GAME(string[,] playing_field, int[,] results)
            {
                int x = 0, y = 0, stroka = 0, stolbec = 0;
                int[] turn = new int[2];
                PrintArray(playing_field);
                Console.WriteLine("Ходит первый игрок. Введите строку и столбец для крестика");
                turn = Check_field(results);
                x = turn[0];
                y = turn[1];
                results[x - 1, y - 1] = 1;
                stroka = Field_into_number(x);
                stolbec = Field_into_number(y);
                The_cross(playing_field, stroka, stolbec);
                PrintArray(playing_field);
                if (
                    results[0, 0] == results[0, 1] && results[0, 0] == results[0, 2] && results[0, 0] == 1 ||
                    results[1, 0] == results[1, 1] && results[1, 0] == results[1, 2] && results[1, 0] == 1 ||
                    results[2, 0] == results[2, 1] && results[2, 0] == results[2, 2] && results[2, 0] == 1 ||
                    results[0, 0] == results[1, 0] && results[0, 0] == results[2, 0] && results[0, 0] == 1 ||
                    results[0, 1] == results[1, 1] && results[0, 1] == results[2, 1] && results[0, 1] == 1 ||
                    results[0, 2] == results[1, 2] && results[0, 2] == results[2, 2] && results[0, 2] == 1 ||
                    results[0, 0] == results[1, 1] && results[0, 0] == results[2, 2] && results[0, 0] == 1 ||
                    results[0, 2] == results[1, 1] && results[0, 2] == results[2, 0] && results[0, 2] == 1 
                    ) 
                {
                    Console.WriteLine("Победил первый игрок!");
                    return;
                }   
                Console.WriteLine("Ходит второй игрок. Введите строку и столбец для крестика");
                turn = Check_field(results);
                x = turn[0];
                y = turn[1];
                results[x - 1, y - 1] = 4;
                stroka = Field_into_number(x);
                stolbec = Field_into_number(y);
                Zero(playing_field, stroka, stolbec);
                PrintArray(playing_field);
                if (
                    results[0, 0] == results[0, 1] && results[0, 0] == results[0, 2] && results[0, 0] == 4 ||
                    results[1, 0] == results[1, 1] && results[1, 0] == results[1, 2] && results[1, 0] == 4 ||
                    results[2, 0] == results[2, 1] && results[2, 0] == results[2, 2] && results[2, 0] == 4 ||
                    results[0, 0] == results[1, 0] && results[0, 0] == results[2, 0] && results[0, 0] == 4 ||
                    results[0, 1] == results[1, 1] && results[0, 1] == results[2, 1] && results[0, 1] == 4 ||
                    results[0, 2] == results[1, 2] && results[0, 2] == results[2, 2] && results[0, 2] == 4 ||
                    results[0, 0] == results[1, 1] && results[0, 0] == results[2, 2] && results[0, 0] == 4 ||
                    results[0, 2] == results[1, 1] && results[0, 2] == results[2, 0] && results[0, 2] == 4
                    )
                {
                    Console.WriteLine("Победил второй игрок!");
                    return;
                }
                The_GAME(playing_field, results);
            }

            // Получение координат для хода с проверкой поля на возможность туда походить
            int[] Check_field(int[,] _results)
            {
                int[] turn = EnterTheNumber();

                int x = turn[0];
                int y = turn[1];

                if (_results[x - 1, y - 1] == 1 || _results[x - 1, y - 1] == 4)
                {
                    Console.WriteLine("Это поле уже занято, введите кординаты другого поля");
                    return Check_field(_results);
                }
                else
                {
                    return turn;
                }
            }

            // Рисование нолика
            string[,] Zero(string[,] playing_field, int x, int y)
            {
                string[,] zero = new string[5, 5];
                int len_cross = zero.GetLength(0), width_cross = zero.GetLength(1); 

                for (int i = 0; i < len_cross; i++)
                {
                    for (int j = 0; j < width_cross; j++)
                    {
                        if (i == 0 && j == 2) playing_field[x + i, y + j] = "0 ";                        
                        else if (i == 1 && j == 1 || i == 1 && j == 3) playing_field[x + i, y + j] = "0 ";                        
                        else if (i == 2 && j == 0 || i == 2 && j == 4) playing_field[x + i, y + j] = "0 ";
                        else if (i == 3 && j == 1 || i == 3 && j == 3) playing_field[x + i, y + j] = "0 ";
                        else if (i == 4 && j == 2) playing_field[x + i, y + j] = "0 ";
                        else playing_field[x + i, y + j] = "  ";                       
                    }
                }
                return playing_field;
            }

            // Рисование крестика
            string[,] The_cross(string[,] playing_field, int x, int y)
            {
                string[,] cross = new string[5, 5];
                int len_cross = cross.GetLength(0), width_cross = cross.GetLength(1);

                for (int i = 0; i < len_cross; i++)
                {
                    for (int j = 0; j < width_cross; j++)
                    {
                        if ((i == j) ^ (i == 2 && j == 2)) playing_field[x + i, y + j] = "\\ ";
                        else if (i == 2 && j == 2) playing_field[x + i, y + j] = "X ";
                        else if (i == len_cross - 1 - j) playing_field[x + i, y + j] = " /";
                        else playing_field[x + i, y + j] = "  ";
                    }
                }
                return playing_field;
            }

            // Разметка игрового поля
            string[,] Playing_field(int x = 17, int y = 17)
            {
                string[,] playing_field = new string[x, y];

                int len_line = playing_field.GetLength(0);
                int len_row = playing_field.GetLength(1);

                for (int i = 0; i < len_line; i++)
                {
                    for (int j = 0; j < len_row; j++)
                    {
                        if (j == 5 || j == 11) playing_field[i, j] = "|";                        
                        else if (i == 5 || i == 11) playing_field[i, j] = "--";
                        else playing_field[i, j] = "  ";
                    }
                }
                return playing_field;
            }

            // Перевод вводимых координат в координаты массива
            int Field_into_number(int x)
            {
                switch (x)
                {
                    case 1: return 0;
                    case 2: return 6;
                    case 3: return 12;
                }
                return x;
            }

            // Вывод массива на экран консоли
            void PrintArray(Array _array)
            {
                Console.Clear();
                switch (_array.Rank)
                {
                    case 1:
                        for (int i = 0; i < _array.GetLength(0); i++)
                            Console.Write($"{_array.GetValue(i)} ");
                        break;
                    case 2:
                        for (int i = 0; i < _array.GetLength(0); i++)
                        {
                            for (int j = 0; j < _array.GetLength(1); j++)
                            {
                                Console.Write($"{_array.GetValue(i, j)}");
                            }
                            Console.WriteLine();
                        }
                        break;
                }
            }

            // Метод ввода поля и проверка на правильность ввода
            int[] EnterTheNumber()
            {
                int line;
                Console.Write("Введите номер строки от 1 до 3: ");
                bool correct_line = int.TryParse(Console.ReadLine(), out line);

                if (!correct_line || line < 1 || line > 3)
                {
                    Console.WriteLine("Некорректный ввод, попробуйте ещё раз");
                    return EnterTheNumber();
                }

                int row;
                Console.Write("Введите номер столбца от 1 до 3: ");
                bool correct_row = int.TryParse(Console.ReadLine(), out row);

                if (!correct_row || row < 1 || row > 3)
                {
                    Console.WriteLine("Некорректный ввод, попробуйте ещё раз");
                    return EnterTheNumber();
                }

                int[] turn = new int[2];
                turn[0] = line;
                turn[1] = row;

                return turn;
            }
        }
    }
}



