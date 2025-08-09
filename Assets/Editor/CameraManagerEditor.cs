using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraManager))]
public class CameraManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the normal inspector first
        DrawDefaultInspector();

        // Reference to the script
        CameraManager manager = (CameraManager)target;

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Camera Mode Buttons", EditorStyles.boldLabel);

        if (GUILayout.Button("Follow Mode"))
        {
            manager.SetCameraMode(0);
        }

        if (GUILayout.Button("Top-Down Mode"))
        {
            manager.SetCameraMode(1);
        }

        if (GUILayout.Button("Side-Scroller Mode"))
        {
            manager.SetCameraMode(2);
        }

        if (GUILayout.Button("First Person View"))
        {
            manager.SetCameraMode(3);
        }
    }
}