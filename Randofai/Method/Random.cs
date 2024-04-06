using ADOFAI;
using UnityEngine;

namespace Randofai.Method
{
    public class Random
    {
        private static CustomLevelTile[] floors;
        private static CustomLevelTile floor;
        private static GenericDataCLS loadedLevel;
        public static void RandomMove()
        {
            if (!scnCLS.cls) return;
            if (Event.current.isKey && Event.current.keyCode == KeyCode.R)
            {
                floors = scnCLS.cls.floorContainer.gameObject.GetComponentsInChildren<CustomLevelTile>();
                if (floors.Length == 0) return;
                floor = floors[UnityEngine.Random.Range(0, floors.Length)];
                loadedLevel = scnCLS.instance.loadedLevels[floor.levelKey];

                while (loadedLevel.difficulty != Main.difficultyInt)
                {
                    floor = floors[UnityEngine.Random.Range(0, floors.Length)];
                    loadedLevel = scnCLS.instance.loadedLevels[floor.levelKey];
                }
                
                scnCLS.instance.DisplayLevel(floor.name);
                scnCLS.instance.SelectLevel(floor, true);
            }
        }
    }
}