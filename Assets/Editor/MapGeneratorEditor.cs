using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator)), CanEditMultipleObjects]
public class MapGeneratorEditor : Editor
{
    // Edit the inspector
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap();
            }
        }

        // Add a "Generate" button to the inspector
        if(GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}
