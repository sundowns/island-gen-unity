using Assets._Scripts;
using UnityEditor;
using UnityEngine;

namespace Assets._Editor
{
    [CustomEditor(typeof (WorldGenerator))]
    public class WorldGeneratorEditor : Editor {

        public override void OnInspectorGUI()
        {
            WorldGenerator worldGen = (WorldGenerator)target;

            if (DrawDefaultInspector())
            {
                //if (worldGen.AutoUpdate)
                //{
                //    worldGen.GenerateWorld();
                //}
            } 

            if (GUILayout.Button("Generate"))
            {
                worldGen.GenerateWorld();
            }
        }
    }
}
