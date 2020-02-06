using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    internal class UI
    {
        private static char m_AvilableMoveSign = '~';
        private static char m_EmptySign = ' ';
        private const string m_NewGameSign = "Y";
        private const string m_EndGameSign = "Q";

        public static void NewGame()
        {
            OthelloGameSettings gameSettings = new OthelloGameSettings();
            PlayBoardForm playBoard;
            Board board;

            gameSettings.ShowDialog();
            board = new Board(gameSettings.BoardSize, m_AvilableMoveSign, m_EmptySign, gameSettings.PlayerType);
            playBoard = new PlayBoardForm(board);
            playBoard.ShowDialog();

        }


        private static void gameOver(Board i_Board)
        {
            string winnerName, answer;
            int winnerScore;

            if (i_Board.FirstPlayer.Score == i_Board.SecondPlayer.Score)
            {
                winnerName = "It's a draw";
            }
            else if (i_Board.FirstPlayer.Score > i_Board.SecondPlayer.Score)
            {
                winnerName = i_Board.FirstPlayer.Name;
                winnerScore = i_Board.FirstPlayer.Score;
            }
            else
            {
                winnerName = i_Board.SecondPlayer.Name;
                winnerScore = i_Board.SecondPlayer.Score;
            }

            //Ex02.ConsoleUtils.Screen.Clear();
            System.Console.WriteLine(
                @"


                                ======================================================

                                                        GAME OVER

                                                    {0} SCORE IS {1}

                                                    {2} SCORE IS {3}


                                                        THE WINNER IS    

                                                            {4}


                                         DO YOU WANT TO PLAY ANOTHER GAME? Y/N

                                ======================================================
",
                i_Board.FirstPlayer.Name,
                i_Board.FirstPlayer.Score,
                i_Board.SecondPlayer.Name,
                i_Board.SecondPlayer.Score,
                winnerName);
            answer = System.Console.ReadLine();
            if (answer.ToUpper() == m_NewGameSign)
            {
                //Ex02.ConsoleUtils.Screen.Clear();
                NewGame();
            }
        }

        public static int PlayTurn(PlayBoardForm i_PlayBoardForm, char i_PlayerSign, int i_Place)
        {
            Player currentPlayer;
            int nextMove = 0;
            bool legalMove = true, availableMoveOption = !true;
            Random rnd = new Random();
            int selectedOptionToPlay;

            currentPlayer = GameRulesAndLogic.GetPlayerFromSign(i_PlayBoardForm.Board, i_PlayerSign);
            availableMoveOption = GameRulesAndLogic.CheckValidMoves(i_PlayBoardForm.Board, i_PlayerSign);
            if (availableMoveOption)
            {
                if (!currentPlayer.IsComputer && availableMoveOption)
                {
                    do
                    {
                        i_PlayBoardForm.Text = "Otello - " + currentPlayer.Name + "'s Turn";
                        nextMove = i_Place;
                        legalMove = GameRulesAndLogic.CheckAndMakeMove(i_PlayBoardForm.Board, nextMove, i_PlayerSign);
                        if (legalMove != true)
                        {
                            i_PlayBoardForm.BoardRefresh();
                            MessageBox.Show("Illigal move!");
                        }
                        else
                        {
                            GameRulesAndLogic.TakeOutAvailableMoveSigns(i_PlayBoardForm.Board);
                        }
                    }
                    while (legalMove != true);
                }
                else if (availableMoveOption)
                {
                    selectedOptionToPlay = GameRulesAndLogic.ComputerRandomeMove(i_PlayBoardForm.Board);
                    nextMove = selectedOptionToPlay;
                    legalMove = GameRulesAndLogic.CheckAndMakeMove(i_PlayBoardForm.Board, nextMove, i_PlayerSign);
                    if (legalMove)
                    {
                        GameRulesAndLogic.TakeOutAvailableMoveSigns(i_PlayBoardForm.Board);
                    }
                }

                if (i_PlayBoardForm.Board.SecondPlayer.IsComputer)
                {

                }
            }
            else if (GameRulesAndLogic.ThereIsAvailableMovementsOnBoard(i_PlayBoardForm.Board))
            {
                MessageBox.Show(@"
                                    There is no availbale move for {0}
                                    The turn is going to opponent
                                    Press enter to continue", currentPlayer.Name);
            }

            return nextMove;
        }


        public static void GameManagement(PlayBoardForm i_PlayBoardForm, int i_Place, char i_CurrentPlayer)
        {
            int boardSize = i_PlayBoardForm.Board.Columns * i_PlayBoardForm.Board.Rows;
            int nextMove = 1;

            if (GameRulesAndLogic.ThereIsAvailableMovementsOnBoard(i_PlayBoardForm.Board))
            {
                nextMove = PlayTurn(i_PlayBoardForm, i_CurrentPlayer, i_Place);

                if (!GameRulesAndLogic.ThereIsAvailableMovementsOnBoard(i_PlayBoardForm.Board) && GameRulesAndLogic.BoardISNotFull(i_PlayBoardForm.Board))
                {
                    MessageBox.Show(@"                                    
                                There is no availbale move for both players

                                Press enter to continue");
                    // gameOver(i_PlayBoardForm.Board);
                }

                //  gameOver(i_PlayBoardForm.Board);
            }
        }
    }
}
   