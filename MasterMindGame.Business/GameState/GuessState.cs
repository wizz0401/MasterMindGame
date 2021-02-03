using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MasterMindGame.Business.GameState;

namespace MasterMindGame.Business.Common
{
    /// <summary>
    /// Mark the player guess state.
    /// </summary>
    public class GuessState : IGameState
    {
        private List<string> _answerElementPosition;
        private readonly string _incorrectMark = "X";
        private ILog _logger = LogManager.GetLogger("GameMsg");
        private ICodeMaker _codeMaker = new AutoCodeMaker();

        public void Enter(MasterMindGameTurn gameTurn)
        {
            _answerElementPosition = new List<string>();
            var answerArray = gameTurn.ThisTurnAnswer.ToList();
            for (var i = 0; i < answerArray.Count; i++)
            {
                var pos = string.Format("{0},{1}", answerArray[i], i);
                _answerElementPosition.Add(pos);
            }
        }

        public void Excute(MasterMindGameTurn gameTurn)
        {
            bool iscorrect = true;
            if (_answerElementPosition?.Count > 0)
            {
                foreach (var item in _answerElementPosition)
                {
                    if (!gameTurn.CurrentPlayResult.Contains(item))
                    {
                        iscorrect = false;
                    }
                    else
                    {
                        if (!gameTurn.CurrentCorrectPlayResult.Contains(item))
                        {
                            gameTurn.CurrentCorrectPlayResult.Add(item);
                        }
                    }
                }
            }

            gameTurn.IsGuessAllTheNumber = iscorrect;

            if ((gameTurn.CurrentTries == gameTurn.MaxTries) || iscorrect)
            {
                gameTurn.ChangeState(new EndState());
            }

            ShowCurrentCorrectResult(gameTurn);
        }

        public void Exit(MasterMindGameTurn gameTurn)
        {
            return;
        }

        private void ShowCurrentCorrectResult(MasterMindGameTurn gameTurn)
        {
            var correctResult = new StringBuilder();
            string[] result = new string[gameTurn.NumberLength];
            foreach (var item in gameTurn.CurrentCorrectPlayResult)
            {
                var value = item.Split(',')[0];
                var pos = Convert.ToInt32(item.Split(',')[1]);
                result[pos] = value;
            }
            foreach (var item in result)
            {
                if (string.IsNullOrEmpty(item))
                {
                    correctResult.Append(_incorrectMark);
                }
                else
                {
                    correctResult.Append(item);
                }
            }
            gameTurn.CurrentCorrectPlayResultDisplay =
                correctResult.ToString();
            gameTurn.CurrentCorrectPlayResultInfoDisplay
                = _codeMaker.GetHintDetail(correctResult.ToString().Replace(_incorrectMark, "0"),
                gameTurn.ThisTurnAnswer);
        }
    }
}
