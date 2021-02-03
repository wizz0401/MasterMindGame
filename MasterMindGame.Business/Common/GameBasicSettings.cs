using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindGame.Business.Common
{
    public static class GameBasicSettings
    {

        public static void Init()
        {
            MaxLength = GameContants.DefaultMaxLength;
            HintCapacity = GameContants.DefaultHintCapacity;
            NumberLength = GameContants.DefaultNumberLength;
            MaxTries = GameContants.DefaultMaxTries;
        }

        public static int MaxLength
        {
            get;
            set;
        }

        public static int HintCapacity
        {
            get;
            set;
        }

        public static int NumberLength
        {
            get;
            set;
        }

        public static int MaxTries
        {
            get;
            set;
        }
    }
}
