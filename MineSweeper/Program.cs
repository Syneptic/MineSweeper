using System;

namespace MineSweeper;
class Program
{
    static void Main(string[] args)
    {
        int xCell;
        int yCell;
        bool check;
        do
        {
            Console.WriteLine("Choose the number of rows. Between 5 and 30: ");
            check = int.TryParse(Console.ReadLine(), out xCell);
            check = verifyInput(xCell);
        } while (!check);

        do
        {
            Console.WriteLine("Choose the number of columns. Between 5 and 30: ");
            check = int.TryParse(Console.ReadLine(), out yCell);
            check = verifyInput(yCell);
        } while (!check);

        int[,] grid = new int[xCell, yCell];
        bool[,] visited = new bool[xCell, yCell];
        int dx;
        int dy;
        bool gameOver = false;
        bool win = false;
        assignMines(grid);

        while (!gameOver && !win)
        {
            do
            {
                Console.WriteLine($"Choose x (1-{xCell}): ");
                check = int.TryParse(Console.ReadLine(), out dx);
            } while (!check);

            do
            {
                Console.WriteLine($"Choose y (1-{yCell}): ");
                check = int.TryParse(Console.ReadLine(), out dy);
            } while (!check);

            dx = dx -1;
            dy = dy -1;

            Console.WriteLine();
            if (dx < 0 || dy < 0 || dx >= xCell || dy >= yCell)
            {
                Console.WriteLine("Choose numbers within the specified range");
                continue;
            }
            if (grid[dx, dy] == 7)
            {
                Console.WriteLine("You stepped on a mine! Game Over.");
                gameOver = true;
                break;
            }
            if (grid[dx, dy] != 8 && grid[dx, dy] != 7)
            {
                Console.WriteLine("This field has already been cleared. Please choose a different field.");
                continue;
            }
            grid = checkInput(grid, dx, dy);
            if (grid[dx, dy] == 0)
            {
                recursiveCheck(grid, dx, dy, visited);
            }
            win = checkWin(grid);
            print(grid);
            // testPrint(grid);
        }
    }

    private static void recursiveCheck(int[,] arr, int col, int row, bool[,] visited)
    {

        if (!checkInbound(arr, col, row))
        {
            return;
        }

        if (visited[col, row])
        {
            return;
        }

        visited[col, row] = true;

        int count = 0;
        for (int i = col - 1; i <= col + 1; i++)
        {
            for (int j = row - 1; j <= row + 1; j++)
            {
                if (checkInbound(arr, i, j) && arr[i, j] == 7)
                {
                    count++;
                }
            }
        }

        arr[col, row] = count;

        if (count == 0)
        {
            recursiveCheck(arr, col - 1, row - 1, visited);
            recursiveCheck(arr, col - 1, row, visited);
            recursiveCheck(arr, col - 1, row + 1, visited);
            recursiveCheck(arr, col, row - 1, visited);
            recursiveCheck(arr, col, row + 1, visited);
            recursiveCheck(arr, col + 1, row - 1, visited);
            recursiveCheck(arr, col + 1, row, visited);
            recursiveCheck(arr, col + 1, row + 1, visited);
        }
    }

    private static void testPrint(int[,] arr)
    {
        Console.WriteLine("-+-+-+-+-+-Tester-+-+-+-+-+-+-+");
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("-------------------------");
    }

    private static int[,] checkInput(int[,] arr, int i, int j)
    {
        int count = 0;
        for (int x = i - 1; x < i + 2; x++)
        {
            for (int y = j - 1; y < j + 2; y++)
            {
                if (checkInbound(arr, x, y))
                {
                    if (arr[x, y] == 7)
                    {
                        count++;
                    }
                }
            }
        }
        arr[i, j] = count;
       
        return arr;
    }

    private static bool checkInbound(int[,] arr, int col, int row)
    {
        if (col >= 0 && row >= 0 && col < arr.GetLength(0) && row < arr.GetLength(1))
        {
            return true;
        }
        return false;
    }


    private static void print(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.Write("{0}:\t", i + 1);
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i,j] != 7 && arr[i,j] != 8)
                {
                    Console.Write(arr[i, j]);
                }
                
                else
                {
                    Console.Write("x");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("-------------------------");
    }

    private static bool checkWin(int[,] arr)
    {
        bool win = true;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i,j] == 8)
                {
                    win = false;
                }
            }
        }
        if (win)
        {
            Console.WriteLine("Congratulations! You won.\n");
        }
        return win;
    }

    private static void assignMines(int[,] arr)
    {
        Console.Clear();
        Random rnd = new Random();
        int bombOrNot;
        for (int i = 0; i < arr.GetLength(0); i++)
            {
            Console.Write("{0}:\t", i+1);
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    bombOrNot = rnd.Next(0, 6);
                    if (bombOrNot == 0)
                    {
                        arr[i, j] = 7;
                    }
                    else
                    {
                        arr[i, j] = 8;
                    }
                Console.Write("x");
                }
                Console.WriteLine();
            }
        Console.WriteLine("------------------------");
    }

    private static bool verifyInput(int num)
    {
        bool verify = true;
        if (num < 5 || num > 30)
        {
            verify = false;
        }
        return verify;
    }
}

