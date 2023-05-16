namespace TicTacToe;
internal class Program
{
    private static void Main(string[] args)
    {
        // declare a starting array
        string[,] array = new string[,]
        {
            {"1","2","3" },
            {"4","5","6" },
            {"7","8","9" }
        };

        // draw an array
        drawCross(array);
        playTheGame(array);

        

    }
    public static void playTheGame(string[,] array)
    {
        while (!isWinner(array, "X") & !isWinner(array, "O") & !isDraw(array))
        {

            string player1Choice;
            do
            {
                Console.WriteLine(" Player 1 : Choose your field");
                player1Choice = Console.ReadLine();
                if (inputValidation(player1Choice))
                {
                    if (isTaken(array, player1Choice))
                    {
                        Console.WriteLine("This field is already taken");
                    }
                }
                else
                {
                    Console.WriteLine("This is incorrect input");
                }
                
            }

            while (inputValidation(player1Choice) == false | isTaken(array, player1Choice));

            changeAField(array, player1Choice, "X");
            Console.Clear();
            drawCross(array);

            if (isWinner(array, "X"))
            {
                Console.WriteLine("Player 1 has won !");
                Console.WriteLine("Press any key to restar a game");
                Console.ReadKey();
                Console.Clear();
                array = new string[,] {
                {"1","2","3" },
                {"4","5","6" },
                {"7","8","9" }
                };
                break;
                
            }
            if (isDraw(array))
            {
                Console.WriteLine("DRAW !");
                Console.WriteLine("Press any key to restar a game");
                Console.ReadKey();
                Console.Clear();
                array = new string[,] {
                {"1","2","3" },
                {"4","5","6" },
                {"7","8","9" }
                };
                break;

            }

            string player2Choice;
            do
            {
                Console.WriteLine(" Player 2 : Choose your field");
                player2Choice = Console.ReadLine();
                if (!inputValidation(player2Choice))
                {
                    Console.WriteLine("This is incorrect input");
                }
                if (isTaken(array, player2Choice))
                {
                    Console.WriteLine("This field is already taken");
                }
            }

            while (inputValidation(player2Choice) == false | isTaken(array, player2Choice));

            changeAField(array, player2Choice, "O");
            Console.Clear();
            drawCross(array);

            if (isWinner(array, "O"))
            {
                Console.WriteLine("Player 2 has won !");
                Console.WriteLine("Press any key to restar a game");
                Console.ReadKey();
                Console.Clear();
                array = new string[,] {
                {"1","2","3" },
                {"4","5","6" },
                {"7","8","9" }
                };
                break;
            }
            if (isDraw(array))
            {
                Console.WriteLine("DRAW !");
                Console.WriteLine("Press any key to restar a game");
                Console.ReadKey();
                Console.Clear();
                array = new string[,] {
                {"1","2","3" },
                {"4","5","6" },
                {"7","8","9" }
                };
                break;

            }
        }
        drawCross(array);
        playTheGame(array); 
        
    }


    // method that validate  a proper user input
    public static bool inputValidation (string playerInput)
    {
        List<string> correctChoice = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        if (correctChoice.Contains(playerInput))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // method that check if someone win or game is over?
    public static bool isWinner(string[,] arr, string sign)
    {
        if ((arr[0, 0] == sign & arr[0, 1] == sign & arr[0, 2] == sign) |
            (arr[1, 0] == sign & arr[1, 1] == sign & arr[1, 2] == sign) |
            (arr[2, 0] == sign & arr[2, 1] == sign & arr[2, 2] == sign) |
            (arr[0, 0] == sign & arr[1, 0] == sign & arr[2, 0] == sign) |
            (arr[0, 1] == sign & arr[1, 1] == sign & arr[2, 1] == sign) |
            (arr[2, 0] == sign & arr[2, 1] == sign & arr[2, 2] == sign) |
            (arr[0, 0] == sign & arr[1, 1] == sign & arr[2, 2] == sign) |
            (arr[0, 2] == sign & arr[1, 1] == sign & arr[2, 0] == sign)) 
        {
            return true;
        }
        else
        {
            return false;
        }


    }

    // creating a function that should draw a cross with actual values of fields
    public static void drawCross(string[,] arr)
    {
        Console.WriteLine("   |   |  ");
        Console.WriteLine($" {arr[0,0]} | {arr[0,1]} | {arr[0,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |  ");
        Console.WriteLine($" {arr[1, 0]} | {arr[1, 1]} | {arr[1, 2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |  ");
        Console.WriteLine($" {arr[2, 0]} | {arr[2, 1]} | {arr[2, 2]} ");
        Console.WriteLine("   |   |   ");

    }

    //method that change specifing field to the X or O 
    public static void changeAField(string[,] arr, string fieldIdentyfier, string sign)
    {
        
        var result = returnCoordinate(arr, fieldIdentyfier);
        int row = result.Item1;
        int col = result.Item2;
        arr[row, col] = sign;
    }

    public static bool isTaken(string[,] arr, string fieldIdentyfier)
    {
        if (!inputValidation(fieldIdentyfier))
        {
            return false;
        }
        var result = returnCoordinate(arr, fieldIdentyfier);
        int row = result.Item1;
        int col = result.Item2;
        if ((arr[row, col] == fieldIdentyfier))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool isDraw(string[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j <arr.GetLength(1); j++)
            {
                if (!(arr[i,j] == "X" | arr[i, j] == "O"))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static Tuple<int,int> returnCoordinate(string[,] arr, string fieldIdentyfier)
    {
        int row = -1;
        int column = -1;
        switch (fieldIdentyfier)
        {
            case "1":       
                row = 0;
                column = 0;
                break;
            case "2":
                row = 0;
                column = 1;
                break;
            case "3":
                row = 0; 
                column = 2;
                break;
            case "4":
                row = 1;
                column = 0;
                break;
            case "5":
                row = 1;
                column = 1;
                break;
            case "6":
                row = 1;
                column = 2;
                break;
            case "7":
                row = 2;
                column = 0;
                break;
            case "8":
                row = 2;
                column = 1;
                break;
            case "9":
                row = 2;
                column = 2;
                break;
        }
        return Tuple.Create(row, column);
    }


}