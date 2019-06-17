using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Intro_Heli_Physics
{
    public class Helicopter_Menu
    {
        [MenuItem("Indie Pixel/Vehicles/Set Up New Helicopter")]
        public static void CreateNewHelicopter()
        {
            GameObject newHeli = new GameObject("Helicopter", typeof(Heli_Controller));

            //Create COG
            GameObject cog = new GameObject("COG");
            cog.transform.parent = newHeli.transform;

            //Create Grapics_GRP
            GameObject grapics = new GameObject("Grapics_GRP");
            grapics.transform.parent = newHeli.transform;

            //Create Audio_GRP
            GameObject audio = new GameObject("Audio_GRP");
            audio.transform.parent = newHeli.transform;

            //Create Colider_GRP
            GameObject coliders = new GameObject("Colider_GRP");
            coliders.transform.parent = newHeli.transform;

            newHeli.GetComponent<Heli_Controller>().m_COG = cog.transform;

            Selection.activeObject = newHeli;
        }
    }
}
