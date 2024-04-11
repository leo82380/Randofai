using System;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using UnityModManagerNet;

namespace Randofai
{
    public static class Main
    {
        public static UnityModManager.ModEntry.ModLogger Logger;
        public static Harmony harmony;
        public static bool IsEnabled = false;
        public static string difficulty;
        public static int difficultyInt = 1;

        public static void Setup(UnityModManager.ModEntry modEntry)
        {
            Logger = modEntry.Logger;
            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = OnGUI;
            difficulty = "";
            difficultyInt = 1;
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            IsEnabled = value;

            if (value)
            {
                harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            else
            {
                harmony.UnpatchAll(modEntry.Info.Id);
            }
            return true;
        }
        
        private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (IsEnabled)
            {
                GUILayout.Label("<size=20>Difficulty</size>");
                difficulty = GUILayout.TextField(difficulty);
                if (IsVaildDifficulty(difficulty) && difficulty != "")
                {
                    
                    difficultyInt = Convert.ToInt32(difficulty);
                    difficultyInt = Mathf.Clamp(difficultyInt, 1, 10);
                }
                else
                {
                    GUI.color = Color.red;
                    GUILayout.Label("Invalid difficulty! Please enter a number between 1 and 10.");
                    GUI.color = Color.white;
                }
            }
        }
        
        private static bool IsVaildDifficulty(string difficulty)
        {
            return int.TryParse(difficulty, out int result) && result >= 1 && result <= 10;
        }
    }
    
}
