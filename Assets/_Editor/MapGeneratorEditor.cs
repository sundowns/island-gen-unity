using Assets._Scripts;
using UnityEditor;
using UnityEngine;

namespace Assets._Editor
{
    [CustomEditor(typeof (MapGenerator))]
    public class MapGeneratorEditor : Editor {

        public override void OnInspectorGUI()
        {
            MapGenerator mapGen = (MapGenerator)target;

            if (DrawDefaultInspector())
            {
                if (mapGen.AutoUpdate)
                {
                    mapGen.GenerateMap();
                }
            } 

            if (GUILayout.Button("Generate"))
            {
                mapGen.GenerateMap();
            }
        }
    }
}
