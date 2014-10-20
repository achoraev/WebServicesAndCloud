namespace BullsAndCows.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Web.Models;

    public class gamesController : ApiController
    {
        const int defaultPageSize = 10;

        protected IBullsAndCowsData data;

        public gamesController()
            : this(new BullsAndCowsData())
        {
        }

        public gamesController(IBullsAndCowsData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                return GetAuthorized(1);
            }
            else
            {
                return Get(1);
            }
            
        }

        [HttpGet]
        [Authorize]
        private IHttpActionResult GetAuthorized(int page)
        {
            var games = this.data
                 .Games
                 .All()
                 .Where(g => (g.PlayerColor == PlayerColor.red || g.PlayerColor == PlayerColor.blue) && g.GameState == GameState.WaitingForOpponent)
                 .OrderBy(s => s.GameState == GameState.WaitingForOpponent)
                 .ThenBy(n => n.Name)
                 .ThenBy(d => d.DateCreated)
                 .ThenBy(n => n.RedPlayer)
                 .Skip(page * defaultPageSize)
                 .Take(defaultPageSize);

            return Ok(games);
        }
        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            var games = this.data
                 .Games
                 .All()
                 .OrderBy(s => s.GameState == GameState.WaitingForOpponent)
                 .ThenBy(n => n.Name)
                 .ThenBy(d => d.DateCreated)
                 .ThenBy(n => n.RedPlayer)
                 .Skip(page * defaultPageSize)
                 .Take(defaultPageSize);

            return Ok(games);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetByID(int id)
        {
            var game = this.data.Games.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            // var gameModel = new GameModel(game);
            return Ok(game);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(Game game)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (game.BluePlayer == null)
            {
                game.BluePlayer.Username = "No blue player yet";
            }

            if (game.RedPlayer != null)
            {
                game.RedPlayer.Username = game.RedPlayer.Username;
            }

            var newGame = new Game
            {
                Name = game.Name,
                GuessNumber = game.GuessNumber,
                DateCreated = DateTime.Now,
                RedPlayer = game.RedPlayer,
                BluePlayer = game.BluePlayer,
                GameState = GameState.WaitingForOpponent
            };

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            var gameDataModel = this.data.Games
                        .All()
                        .Where(x => x.Id == newGame.Id)
                        .Select(GameModel.FromGame)
                        .FirstOrDefault();

            // game.Id = newGame.Id;
            return Ok(gameDataModel);
        }
    }
}