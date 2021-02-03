using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MasterMindGame.Business.Common
{
    /// <summary>
    /// Mark the game start state.
    /// </summary>
    public class StartState : IGameState
    {
        private ICodeMaker _codeMaker;
        private ILog _logger;

        public StartState()
        {
            _logger= LogManager.GetLogger("GameMsg");
            _codeMaker = new AutoCodeMaker();
        }

        public void Enter(MasterMindGameTurn gameTurn)
        {
            try
            {
                _logger.Debug("Start game");
                this._codeMaker = new AutoCodeMaker();
                gameTurn.CurrentCorrectPlayResult = new List<string>();
                gameTurn.ThisTurnAnswer = _codeMaker.GetAnswer(gameTurn.NumberLength);
                gameTurn.ThisTurnHints = _codeMaker.GetHintsDetail(_codeMaker.GetHints(gameTurn.NumberLength,
                    gameTurn.HintCapacity, gameTurn.ThisTurnAnswer), gameTurn.ThisTurnAnswer);
            }
            catch(Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void Excute(MasterMindGameTurn gameTurn)
        {
            return;
        }

        public void Exit(MasterMindGameTurn gameTurn)
        {
            gameTurn.IsGameOver = false;
            gameTurn.IsGameFail = false;
            gameTurn.IsGuessAllTheNumber = false;
            gameTurn.IsOverMaxTries = false;
            gameTurn.CurrentTries = 0;
            gameTurn.CurrentCorrectPlayResult = new List<string>();
            gameTurn.CurrentCorrectPlayResultDisplay = string.Empty;
            gameTurn.CurrentCorrectPlayResultInfoDisplay = string.Empty;
            gameTurn.CurrentPlayResult = new List<string>();
        }
    }
}
