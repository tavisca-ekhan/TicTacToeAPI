using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class GameController : ApiController
    {
        static int player = 1;
        static char[,] board = new char[3, 3] { { '-', '-', '-' },
                                                { '-', '-', '-' },
                                                { '-', '-', '-' } };

        // GET: api/Game
        public char[,] Get()
        {
            // return new string[] { "value1", "value2" };
            return board;
            
        }

        // GET: api/Game/5
        public string Get(int id)
        {
            return "value of id " + id;
        }

        // POST: api/Game/playerId
        public string Post([FromBody]Vector vector)
        {
            if (player == 1) return PlayGame('x', player, vector);
            else if (player == 2) return PlayGame('o', player, vector);

            if (IsDraw()) return "Game is Draw";

            return "Move Done";
        }

        private bool IsDraw()
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (board[row, col] == '-') return false;

            return true;       
        }

        private string PlayGame(char ele, int playerId, Vector vector)
        {
            int row = vector.row;
            int col = vector.col;

            if (row > 2 || col > 2) return "Enter a valid move";

            if (board[row, col] == '-')
            {
                board[row, col] = ele;
                if (GameOver(ele))
                    return "Player " + playerId + " wins";
                player = playerId == 1 ? 2 : 1;
                return "Player " + player + " chance";
            }
            else
            {
                return "Invalid Move!!! Try Again";
            }
        }

        private bool GameOver(char ch)
        {
            for (int row = 0; row < 3; row++)
            {
                if (board[0, row] == ch && 
                    board[1, row] == ch && 
                    board[2, row] == ch)
                    return true;

                if (board[row, 0] == ch && 
                    board[row, 1] == ch && 
                    board[row, 2] == ch)
                    return true;
            }

            if ((board[0, 0] == ch && 
                board[1, 1] == ch && 
                board[2, 2] == ch) ||
               (board[0, 2] == ch && 
               board[1, 1] == ch && 
               board[2, 0] == ch))
                return true;

            return false;
        }

        // PUT: api/Game/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Game
        public void Delete()
        {
            // Deletion done
            board = new char[3, 3] { { '-', '-', '-' },
                                     { '-', '-', '-' },
                                     { '-', '-', '-' } };
        }
    }
    
}
