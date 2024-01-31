using HarmonyLib;
using Randofai.Method;

namespace Randofai.Patch
{
    [HarmonyPatch(typeof(scnCLS),"Update")]
    public class RandomMovePatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            Random.RandomMove();
        }
    }
}