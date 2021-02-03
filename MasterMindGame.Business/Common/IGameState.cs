using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindGame.Business.Common
{
    /// <summary>
    /// This method is used to mark the game state.
    /// </summary>
    public interface IGameState
    {
        void Enter(MasterMindGameTurn gameTurn);

        void Excute(MasterMindGameTurn gameTurn);

        void Exit(MasterMindGameTurn gameTurn);
    }
}
