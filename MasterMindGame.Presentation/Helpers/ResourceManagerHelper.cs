using System;
using System.Resources;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindGame.Presentation.Helpers
{
  public static class ResourceManagerHelper
    {
        private static ResourceManager _resourceManager;

        public static void Init()
        {
            Assembly myAssem = Assembly.GetEntryAssembly();
            _resourceManager= new ResourceManager("MasterMindGame.Presentation.Properties.Resources"
                , myAssem);
        }

        public static string GetResource(string keyName)
        {
            return _resourceManager.GetString(keyName);
        }
    }
}
