
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MyCubes : MonoBehaviour
{
    public int size;
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
        var size = serializedObject.FindProperty("size");
        EditorGUILayout.PropertyField(size);
        serializedObject.ApplyModifiedProperties();

        if (size.intValue < 0)
        {
            EditorGUILayout.HelpBox("The size cannot be less than 0", MessageType.Warning);
        }

        if (GUILayout.Button("Select All Cubes"))
        {
            //alex code
            //var allTagCubes = GameObject.FindGameObjectsWithTag("Cube");
            //Selection.objects = allTagCubes;

            var allTagCubes = GameObject.FindGameObjectsWithTag("Cube");
            var allObjectCubes = allTagCubes
            .Select(enemy => enemy.gameObject)
            .ToArray();
            Selection.objects = allObjectCubes;

        }

        if (GUILayout.Button("Clear Selection"))
        {
            Selection.objects = null;
        }

        var cachedColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.blue;

        if (GUILayout.Button("Enable/Disable All Cubes", GUILayout.Height(40)))
        {
            foreach (var cubes in GameObject.FindGameObjectsWithTag("Cube"))
            {
                Undo.RecordObject(cubes.gameObject, "Enable/Disable All Cubes");
                cubes.gameObject.SetActive(!cubes.gameObject.activeSelf);

                GUI.color = Color.grey;
            }
        }

    }
}
#endif