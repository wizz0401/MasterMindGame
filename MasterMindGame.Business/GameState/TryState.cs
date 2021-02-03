using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MasterMindGame.Business.GameState;

namespace MasterMindGame.Business.Common
{
    public class TryState : IGameState
    {
        private ILog _logger= LogManager.GetLogger("GameMsg");

        public void Enter(MasterMindGameTurn gameTurn)
        {
            _logger.Debug("User start to try this game.");
            gameTurn.CurrentTries++;
        }

        public void Excute(MasterMindGameTurn gameTurn)
        {
            try
            {
                if (gameTurn.CurrentTries > gameTurn.MaxTries)
                {
                    gameTurn.IsOverMaxTries = true;
                    gameTurn.ChangeState(new EndState());
                }
                else
                {
                    gameTurn.ChangeState(new GuessState());
                }
            }
            catch(Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void Exit(MasterMindGameTurn gameTurn)
        {
            return;
        }
    }
}
