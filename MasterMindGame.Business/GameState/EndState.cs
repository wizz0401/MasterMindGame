using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MasterMindGame.Business.Common;

namespace MasterMindGame.Business.GameState
{

    /// <summary>
    ///  Mark the end state in the game.
    /// </summary>
    public class EndState : IGameState
    {
        private ILog _logger = LogManager.GetLogger("GameMsg");

        public void Enter(MasterMindGameTurn gameTurn)
        {
            _logger.Debug("This game is over");
        }

        public void Excute(MasterMindGameTurn gameTurn)
        {
            gameTurn.IsGameOver = true;
            gameTurn.IsGameFail = gameTurn.IsOverMaxTries
                || ((gameTurn.CurrentTries == gameTurn.MaxTries) && !gameTurn.IsGuessAllTheNumber);
        }

        public void Exit(MasterMindGameTurn gameTurn)
        {
            return;
        }
    }
}
