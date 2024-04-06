using HarmonyLib;
using Random = Randofai.Method.Random;

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