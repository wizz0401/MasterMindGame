using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MasterMindGame.Business.Common
{
    /// <summary>
    /// This class is used to mark the each round of game play.
    /// </summary>
   public class MasterMindGameTurn
    {
        private int _maxLength;
        private int _hintCapacity;
        private int _numberLength;
        private int _maxTries;

        public MasterMindGameTurn()
        {
            Init();
        }

        private void Init()
        {
            GameBasicSettings.Init();
            log4net.Config.XmlConfigurator.Configure();
            _maxLength = GameBasicSettings.MaxLength;
            _hintCapacity = GameBasicSettings.HintCapacity;
            _numberLength = GameBasicSettings.NumberLength;
            _maxTries = GameBasicSettings.MaxTries;
            this.ChangeState(new StartState());
        }

        /// <summary>
        /// Method to changed the game state. In future, it could be moved to the specific class 'state manager'
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(IGameState state)
        {
            state.Exit(this);
            state.Enter(this);
            state.Excute(this);
        }


        /// <summary>
        /// This value is to get the length of number in the master mind game.
        /// </summary>
        public int NumberLength
        {
            get
            {
                return _numberLength;
            }
        }

        /// <summary>
        /// This value is to get the number of hint given to the player.
        /// </summary>
        public int HintCapacity
        {
            get
            {
                return _hintCapacity;
            }
        }

        /// <summary>
        /// This value is to get the max length of the number in the game.
        /// </summary>
        public int MaxLength
        {
            get
            {
                return _maxLength;
            }
        }

        /// <summary>
        ///  This value is to get or set the hints information
        /// </summary>
        public List<string> ThisTurnHints
        {
            get;
            set;
        }

        /// <summary>
        /// This value is to get or set the answer in the game.
        /// </summary>
        public string ThisTurnAnswer
        {
            get;
            set;
        }

        /// <summary>
        /// This value is to get or set the current count for the player guess.
        /// </summary>
        public int CurrentTries
        {
            get;
            set;
        }

        /// <summary>
        /// This value is to get or set the max count for the player guess.
        /// </summary>
        public int MaxTries
        {
            get
            {
                return this._maxTries;
            }
        }

        /// <summary>
        /// This value is to get or set the current play results.
        /// </summary>
        public List<string> CurrentPlayResult
        {
            get;
            set;
        }

        /// <summary>
        /// This value is to get or set the current correct results guessed by the player.
        /// </summary>
        public List<string> CurrentCorrectPlayResult
        {
            get;
            set;
        }

        /// <summary>
        /// This value is to get or set the display for current correct results guessed by the player.
        /// </summary>
        public string CurrentCorrectPlayResultDisplay
        {
            get;
            set;
        }

        public string CurrentCorrectPlayResultInfoDisplay
        {
            get;
            set;
        }

        /// <summary>
        ///  The mark for game fails or not
        /// </summary>
        public bool IsGameFail
        {
            get;
            set;
        }

        /// <summary>
        /// The mark whether over max tries or not
        /// </summary>
        public bool IsOverMaxTries
        {
            get;
            set;
        }

        /// <summary>
        ///  The mark whether player have guessed all the number correctly or not.
        /// </summary>
        public bool IsGuessAllTheNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The mark whether game is over or not.
        /// </summary>
        public bool IsGameOver
        {
            get;
            set;
        }
    }
}
