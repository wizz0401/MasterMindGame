using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindGame.Business.Common
{
    /// <summary>
    /// This is used to make number codes in the game such like hint number, answer number.
    /// </summary>
   public interface ICodeMaker
    {
        /// <summary>
        /// Get answer
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string GetAnswer(int length);

        /// <summary>
        /// Get hints
        /// </summary>
        /// <returns></returns>
        List<string> GetHints(int length, int capacity);

        /// <summary>
        /// Get detail information about  hints
        /// </summary>
        /// <returns></returns>
        List<string> GetHintsDetail(List<string> hints, string answer);

        /// <summary>
        /// Get hints
        /// </summary>
        /// <param name="length"></param>
        /// <param name="capacity"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        List<string> GetHints(int length, int capacity, string seed);

        /// <summary>
        /// Get hint detail.
        /// </summary>
        /// <param name="hint"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        string GetHintDetail(string hint, string answer);
    }
}
