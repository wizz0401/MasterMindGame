using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterMindGame.Business.Common;

namespace MasterMindGame.Business
{
    /// <summary>
    ///  Implement for the code maker. This auto code maker can make any code automaticly.
    /// </summary>
    public class AutoCodeMaker : ICodeMaker
    {
        public string GetAnswer(int length)
        {
            var answerBuilder = new StringBuilder();
            var rand = new Random();
            for (var i = 0; i < length; i++)
            {
                answerBuilder.Append(rand.Next(1, 9).ToString());
            }
            return answerBuilder.ToString();
        }

        public List<string> GetHints(int length, int capacity)
        {
            var hints = new List<string>();
            var rand = new Random();
            for (var i = 0; i < capacity; i++)
            {
                var hintBuilder = new StringBuilder();
                for (var j = 0; j < length; j++)
                {
                    hintBuilder.Append(rand.Next(1, 9).ToString());
                }
                hints.Add(hintBuilder.ToString());
            }
            return hints;
        }

        public List<string> GetHints(int length, int capacity, string seed)
        {
            var random = new Random();
            var hints = GetHints(length, capacity);

            if (!string.IsNullOrEmpty(seed))
            {
                var changedHints = new List<string>();
                var index = 0;
                foreach (var hint in hints)
                {
                    var hintArray = hint.ToArray();
                    var seedLength = seed.ToList().Count;
                    var seedArray = seed.ToArray();
                    var randPos = random.Next(1, seedLength);
                    hintArray[randPos] = seedArray[randPos];
                    if(index==0)
                    {
                        hintArray[0] = Convert.ToChar(random.Next(1, 9).ToString());
                    }
                    var changedHint = new StringBuilder();
                    foreach (var item in hintArray)
                    {
                        changedHint.Append(item);
                    }
                    changedHints.Add(changedHint.ToString());
                    index++;
                }
                hints = changedHints;
            }
            return hints;
        }

        public List<string> GetHintsDetail(List<string> hints, string answer)
        {
            var hintsDetails = new List<string>();
            foreach (var hint in hints)
            {
                hintsDetails.Add(string.Format("{0}_{1}", hint
                    , GetHintDetail(hint, answer)));
            }
            return hintsDetails;
        }

        public string GetHintDetail(string hint, string answer)
        {
            int a = 0;
            int b = 0;

            var hintArray = hint.ToList();
            var answerArray = answer.ToList();
            var hintNumberCount = new Dictionary<char, int>();
            var answerNumberCount = new Dictionary<char, int>();

            for (var i = 0; i < hintArray.Count; i++)
            {
                if (!hintNumberCount.ContainsKey(hintArray[i]))
                {
                    hintNumberCount.Add(hintArray[i], 1);
                }
                else
                {
                    hintNumberCount[hintArray[i]]++;
                }
                if (hintArray[i] == answerArray[i])
                {
                    a++;
                }
            }

            for (var i = 0; i < answerArray.Count; i++)
            {
                if (!answerNumberCount.ContainsKey(answerArray[i]))
                {
                    answerNumberCount.Add(answerArray[i], 1);
                }
                else
                {
                    answerNumberCount[answerArray[i]]++;
                }
            }

            foreach (var answerNumber in answerNumberCount)
            {
                if (hintNumberCount.ContainsKey(answerNumber.Key))
                {
                    b += Math.Min(hintNumberCount[answerNumber.Key]
                        , answerNumber.Value);
                }
            }

            return string.Format("{0},{1}", a, b - a);
        }
    }
}
