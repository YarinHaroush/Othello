using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    internal class GameRulesAndLogic
    {
        private static readonly Direction sr_ToLeftUpperCorner = new Direction(-1, -1);
        private static readonly Direction sr_ToRightLowerCorner = new Direction(1, 1);
        private static readonly Direction sr_ToLeftLowerCorner = new Direction(1, -1);
        private static readonly Direction sr_ToRightUpperCorner = new Direction(-1, 1);
        private static readonly Direction sr_ToLeft = new Direction(0, -1);
        private static readonly Direction sr_ToRight = new Direction(0, 1);
        private static readonly Direction sr_ToUp = new Direction(-1, 0);
        private static readonly Direction sr_ToDown = new Direction(1, 0);
        private static readonly Direction[] sr_AllDirections = new Direction[] { sr_ToLeftUpperCorner, sr_ToRightLowerCorner, sr_ToLeftLowerCorner, sr_ToRightUpperCorner, sr_ToLeft, sr_ToRight, sr_ToUp, sr_ToDown };
        private static Random s_rnd = new Random();
        private const char m_XSign = 'X';
        private const char m_OSign = 'O';
        private const char m_FirstColSign = 'A';
        private const char m_FirstRowSign = '1';

        public static int GetFirstPlayer()
        {
            int number = s_rnd.Next(1, 1000);

            return number % 2;
        }

        private static bool checkPlace(Board i_Board, char i_Row, char i_Col)
        {
            bool legalPlace = false;

            if (char.IsLetter(i_Col) || char.IsDigit(i_Row))
                {
                i_Col = char.ToUpper(i_Col);
                if (i_Col >= m_FirstColSign && i_Col < m_FirstColSign + i_Board.Columns)
                {
                    if (i_Row - m_FirstRowSign >= 0 && i_Row - m_FirstRowSign < i_Board.Rows)
                    {
                        legalPlace = true;
                    }
                }
            }

            return legalPlace;
        }

        public static bool CheckValidMoves(Board i_Board, char i_PlayerSign)
        {
            int cols = i_Board.Columns;
            int rows = i_Board.Rows;
            int currentCol = 0, currentRow = 0;
            bool haveAvailableMovements = !true;

            for (currentRow = 0; currentRow < rows; currentRow++)
            {
                for (currentCol = 0; currentCol < cols; currentCol++)
                {
                    if (i_Board.PlayBoard[currentRow][currentCol] == i_Board.EmptySign || i_Board.PlayBoard[currentRow][currentCol] == i_Board.AvilableMoveSign)
                    {
                        foreach (Direction currentDirection in sr_AllDirections)
                        {
                            if (validMove(i_Board, currentRow, currentCol, i_PlayerSign, currentDirection))
                            {
                                haveAvailableMovements = true;
                                if (i_Board.PlayBoard[currentRow][currentCol] == i_Board.EmptySign)
                                {
                                    i_Board.PlayBoard[currentRow][currentCol] = i_Board.AvilableMoveSign;
                                }
                            }
                        }
                    }
                }
            }

            return haveAvailableMovements;
        }

        private static bool validMove(Board i_Board, int i_Row, int i_Col, char i_PlayerSign, Direction i_Direction)
        {
            char opponentPlayer = m_XSign;

            if (i_PlayerSign == m_XSign)
            {
                opponentPlayer = m_OSign;
            }
            
            if (i_Col + i_Direction.Horizontal < 0 || i_Col + i_Direction.Horizontal > i_Board.Columns - 1)
            {
                return !true;
            }

            if (i_Row + i_Direction.Vertical < 0 || i_Row + i_Direction.Vertical > i_Board.Rows - 1)
            {
                return !true;
            }

            if (i_Board.PlayBoard[i_Row + i_Direction.Vertical][i_Col + i_Direction.Horizontal] != opponentPlayer)
            {
                return !true;
            }

            if (i_Col + i_Direction.Horizontal + i_Direction.Horizontal < 0 || i_Col + i_Direction.Horizontal + i_Direction.Horizontal > i_Board.Columns - 1)
            {
                return !true;
            }

            if (i_Row + i_Direction.Vertical + i_Direction.Vertical < 0 || i_Row + i_Direction.Vertical + i_Direction.Vertical > i_Board.Rows - 1)
            {
                return !true;
            }

            return checkDirection(i_Board, i_Row + i_Direction.Vertical + i_Direction.Vertical, i_Col + i_Direction.Horizontal + i_Direction.Horizontal, i_PlayerSign, i_Direction);
        }

        private static bool checkDirection(Board i_Board, int i_Row, int i_Col, char i_PlayerSign, Direction i_Direction)
        {
            if (i_Board.PlayBoard[i_Row][i_Col] == i_Board.EmptySign || i_Board.PlayBoard[i_Row][i_Col] == i_Board.AvilableMoveSign)
            {
                return !true;
            }

            if (i_Board.PlayBoard[i_Row][i_Col] == i_PlayerSign)
            {
                return true;
            }

            if (i_Col + i_Direction.Horizontal < 0 || i_Col + i_Direction.Horizontal > i_Board.Columns - 1)
            {
                return !true;
            }

            if (i_Row + i_Direction.Vertical < 0 || i_Row + i_Direction.Vertical > i_Board.Rows - 1)
            {
                return !true;
            }

            return checkDirection(i_Board, i_Row + i_Direction.Vertical, i_Col + i_Direction.Horizontal, i_PlayerSign, i_Direction);
        }

        private static void updateBoard(Board i_Board, int i_Row, int i_Col, char i_PlayerSign)
        {
            foreach (Direction currentDirection in sr_AllDirections)
            {
                changeInDirection(i_Board, i_Row, i_Col, i_PlayerSign, currentDirection);
            }
        }

        private static bool changeInDirection(Board i_Board, int i_Row, int i_Col, char i_PlayerSign, Direction i_Direction)
        {
            if (i_Col + i_Direction.Horizontal < 0 || i_Col + i_Direction.Horizontal > i_Board.Columns - 1)
            {
                return !true;
            }

            if (i_Row + i_Direction.Vertical < 0 || i_Row + i_Direction.Vertical > i_Board.Rows - 1)
            {
                return !true;
            }

            if (i_Board.PlayBoard[i_Row + i_Direction.Vertical][i_Col + i_Direction.Horizontal] == i_Board.EmptySign)
            {
                return !true;
            }

            if (i_Board.PlayBoard[i_Row + i_Direction.Vertical][i_Col + i_Direction.Horizontal] == i_Board.AvilableMoveSign)
            {
                return !true;
            }

            if (i_Board.PlayBoard[i_Row + i_Direction.Vertical][i_Col + i_Direction.Horizontal] == i_PlayerSign)
            {
                return true;
            }
            else
            {
                if (i_Board.PlayBoard[i_Row + i_Direction.Vertical][i_Col + i_Direction.Horizontal] != i_Board.AvilableMoveSign)
                {
                    if (changeInDirection(i_Board, i_Row + i_Direction.Vertical, i_Col + i_Direction.Horizontal, i_PlayerSign, i_Direction))
                    {
                        i_Board.PlayBoard[i_Row + i_Direction.Vertical][i_Col + i_Direction.Horizontal] = i_PlayerSign;
                        if (i_Board.FirstPlayer.Sign == i_PlayerSign)
                        {
                            i_Board.FirstPlayer.Score++;
                            i_Board.SecondPlayer.Score--;
                        }
                        else
                        {
                            i_Board.SecondPlayer.Score++;
                            i_Board.FirstPlayer.Score--;
                        }

                        return true;
                    }
                    else
                    {
                        return !true;
                    }
                }
                else
                {
                    return !true;
                }
            }
        }

        public static Player GetPlayerFromSign(Board i_Board, char i_PlayerSign)
        {
            if (i_Board.FirstPlayer.Sign == i_PlayerSign)
            {
                return i_Board.FirstPlayer;
            }
            else
            {
                return i_Board.SecondPlayer;
            }
        }

        public static bool CheckAndMakeMove(Board i_Board, int i_place, char i_PlayerSign)
        {
            bool moveIsInsideBoard = true;
            bool legalMove = true;
            int playerScoreBeforeMovement;
            int placeCol = 0, placeRow = 0;
            Player currentPlayer;

            if (i_Board.FirstPlayer.Sign == i_PlayerSign)
            {
                currentPlayer = i_Board.FirstPlayer;
            }
            else
            {
                currentPlayer = i_Board.SecondPlayer;
            }

            playerScoreBeforeMovement = currentPlayer.Score;


            placeCol = i_place / 10;
            placeRow = i_place % 10;
                if (i_Board.PlayBoard[placeRow][placeCol] == i_Board.AvilableMoveSign)
                {
                    legalMove = true;
                }
                else
                {
                    legalMove = !true;
                }
                
                if (moveIsInsideBoard == legalMove)
                {
                    updateBoard(i_Board, placeRow, placeCol, i_PlayerSign);
                    i_Board.PlayBoard[placeRow][placeCol] = currentPlayer.Sign;
                    currentPlayer.Score++;
                    return true;
                }

            return !true;
        }

        public static int[] CalculateComputerOptionsSet(Board i_Board, int[] i_ComputerOptions, out int i_NumberOfComputerOptions)
        {
            int row, col, numberOfComputerOptions = 0;

            for (row = 0; row < i_Board.Rows; row++)
            {
                for (col = 0; col < i_Board.Columns; col++)
                {
                    if (i_Board.PlayBoard[row][col] == i_Board.AvilableMoveSign)
                    {
                        i_ComputerOptions[numberOfComputerOptions++] = (row * 10) + col;
                    }
                }
            }

            i_NumberOfComputerOptions = numberOfComputerOptions;

            return i_ComputerOptions;
        }

        public static void TakeOutAvailableMoveSigns(Board i_Board)
        {
            int currentRow = 0, currentCol = 0;
            int rows = i_Board.Rows;
            int cols = i_Board.Columns;

            for (currentRow = 0; currentRow < rows; currentRow++)
            {
                for (currentCol = 0; currentCol < cols; currentCol++)
                {
                    if (i_Board.PlayBoard[currentRow][currentCol] == i_Board.AvilableMoveSign)
                    {
                        i_Board.PlayBoard[currentRow][currentCol] = i_Board.EmptySign;
                    }
                }
            }
        }

        public static string IntMovementToString(int i_Movement)
        {
            char colChar = m_FirstColSign;
            char rowChar = m_FirstRowSign;
            int col, row;
            string nextMove;

            for (col = 0; col < i_Movement % 10; col++)
            {
                colChar++;
            }

            for (row = 0; row < i_Movement / 10; row++)
            {
                rowChar++;
            }

            return nextMove = char.ToString(colChar) + char.ToString(rowChar);
        }

        public static bool BoardISNotFull(Board i_Board)
        {
            return (i_Board.FirstPlayer.Score + i_Board.SecondPlayer.Score < i_Board.Columns * i_Board.Rows);
        }

        public static bool ThereIsAvailableMovementsOnBoard(Board i_Board)
        {
            bool thereIsAvailableMovementsOnBoard = false;
            if (BoardISNotFull(i_Board))
            {
                if (CheckValidMoves(i_Board, i_Board.FirstPlayer.Sign))
                {
                    thereIsAvailableMovementsOnBoard = true;
                }
                else if (CheckValidMoves(i_Board, i_Board.SecondPlayer.Sign))
                {
                    thereIsAvailableMovementsOnBoard = true;
                }
            }

            return thereIsAvailableMovementsOnBoard;
        }

        public static int ComputerRandomeMove(Board i_Board)
        {
            int[] computerOptions = new int[i_Board.Columns * i_Board.Rows];
            int numberOfComputerOptions = 0;

            computerOptions = CalculateComputerOptionsSet(i_Board, computerOptions, out numberOfComputerOptions);
            return computerOptions[s_rnd.Next(0, numberOfComputerOptions)];
        }

    }
}