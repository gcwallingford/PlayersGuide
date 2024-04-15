using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise_28;

public class Board
{
    public Board()
    {
        char[,] board = new char[3,3];

        for (int column = 0; column < 2; column++)
        {
            for (int row = 0; row < 2; row++)
            {
                board[column, row] = ' ';
            }
        }
    }

    public void DetectWin(char[,] board)
    {

        if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
        {
            
        }
        if (board[1, 0] == board[1, 1] && board[1, 1] == board[0, 2])
        {
            
        }
        if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2])
        {
            
        }
        
        if (board[0, 0] == board[1, 0] && board[0, 1] == board[2, 0])
        {
            
        }
        if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1])
        {
            
        }
        if (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2])
        {
            
        }
        
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            
        }
        if (board[0, 2] == board[1, 1] && board[0, 1] == board[2, 0])
        {
            
        }
    }
    
    public void PlaceChar(char player, int space, char[,] board)
    {
        if (player == 'X')
        {
            switch (space)
            {
                case 1:
                    board[0, 0] = 'X';
                    break;
                case 2:
                    board[0, 1] = 'X';
                    break;
                case 3:
                    board[0, 2] = 'X';
                    break;
                case 4:
                    board[1, 0] = 'X';
                    break;
                case 5:
                    board[1, 1] = 'X';
                    break;
                case 6:
                    board[1, 2] = 'X';
                    break;
                case 7:
                    board[2, 0] = 'X';
                    break;
                case 8:
                    board[2, 1] = 'X';
                    break;
                case 9:
                    board[2, 2] = 'X';
                    break;
            }
        }

        if (player == 'O')
        {
            switch (space)
            {
                case 1:
                    board[0, 0] = 'O';
                    break;
                case 2:
                    board[0, 1] = 'O';
                    break;
                case 3:
                    board[0, 2] = 'O';
                    break;
                case 4:
                    board[1, 0] = 'O';
                    break;
                case 5:
                    board[1, 1] = 'O';
                    break;
                case 6:
                    board[1, 2] = 'O';
                    break;
                case 7:
                    board[2, 0] = 'O';
                    break;
                case 8:
                    board[2, 1] = 'O';
                    break;
                case 9:
                    board[2, 2] = 'O';
                    break;
            }
        }
    }
}