
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MyCubes : MonoBehaviour
{
    public bool chungus;
}

#if UNITY_EDITOR
[CustomEditor(typeof(MyCubes)), CanEditMultipleObjects]
public class CubeEditor : Editor
{

    public List<GameObject> taggedObjects = new List<GameObject>();
    public void LogTags()
    {
        var taggedObjects = GameObject.FindGameObjectsWithTag("Cube");
    }

    bool enabled;
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Select All Cubes"))
        {
            var allTagCubes = GameObject.FindGameObjectsWithTag("Cube");
            Selection.objects = allTagCubes;

        }

        if (GUILayout.Button("Clear Selection"))
        {
            Selection.objects = null;
        }

        var cachedColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.blue;

        if (GUILayout.Button("Enable/Disable All Cubes", GUILayout.Height(40)))
        {
            foreach (var cubes in taggedObjects)
            {
                cubes.SetActive(enabled);

                GUI.color = Color.grey;
            }
        }

    }
}
#endif