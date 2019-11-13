using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TicTacToe.Controllers
{
    public class GameController : ApiController
    {
        GameBoard gameBoard = new GameBoard();

        // GET: api/Game
        public IEnumerable<IEnumerable<char>> Get()
        {
            // return new string[] { "value1", "value2" };
            return gameBoard.CreateBoard();
        }

        // GET: api/Game/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Game
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Game/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Game
        public string Delete()
        {
            gameBoard = new GameBoard().CreateBoard();
        }
    }
}
