using UnityEngine;

namespace Randofai.Method
{
    public class Random
    {
        public static void RandomMove()
        {
            if (!scnCLS.cls) return;
            if (Event.current.isKey && Event.current.keyCode == KeyCode.R)
            {
                CustomLevelTile[] floors = scnCLS.cls.floorContainer.gameObject.GetComponentsInChildren<CustomLevelTile>();
                Transform planet = GameObject.Find("planets").transform.GetChild(0);
                if (floors.Length == 0) return;
                if (planet == null) return;
                CustomLevelTile floor = floors[UnityEngine.Random.Range(0, floors.Length)];
                
                planet.position = floor.transform.position;
                scrCamera.instance.Refocus(planet);
                scnCLS.instance.DisplayLevel(floor.name);
                scnCLS.instance.SelectLevel(floor, true);
            }
        }
    }
}