using UnityEngine;
using UnityEditor;
public class CameraManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // normal inspector first
        DrawDefaultInspector();
        
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
      
        GUILayout.Space(10);
        EditorGUILayout.LabelField("Camera Effects Button", EditorStyles.boldLabel);
        
        if (GUILayout.Button("Camera Shake Effect"))
        {
            manager.SetCameraMode(4);
        }
    }
    
}