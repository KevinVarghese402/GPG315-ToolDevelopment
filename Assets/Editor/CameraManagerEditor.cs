using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraManager))]
public class CameraManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraManager manager = (CameraManager)target;

        // Get current dimension suffix
        string dimSuffix = manager.gameDimension == CameraManager.GameDimension.TwoD ? "(2D)" : "(3D)";

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Camera Mode Buttons", EditorStyles.boldLabel);

        if (GUILayout.Button("Follow Mode " + dimSuffix))
        {
            manager.SetCameraMode((int)CameraManager.CustomCameraMode.Follow);
        }

        if (GUILayout.Button("Top-Down Mode " + dimSuffix))
        {
            manager.SetCameraMode((int)CameraManager.CustomCameraMode.TopDown);
        }

        if (GUILayout.Button("Side-Scroller Mode " + dimSuffix))
        {
            manager.SetCameraMode((int)CameraManager.CustomCameraMode.SideScoller);
        }

        if (GUILayout.Button("First Person View " + dimSuffix))
        {
            manager.SetCameraMode((int)CameraManager.CustomCameraMode.FirstPersonView);
        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Camera Effects Buttons", EditorStyles.boldLabel);

        if (GUILayout.Button("Camera Shake Effect"))
        {
            Debug.Log("Camera shaking");
            manager.SetCameraMode((int)CameraManager.CustomCameraMode.CameraShake);
        }

        if (GUILayout.Button("Camera Dolly Effect"))
        {
            Debug.Log("Camera dolly started");
            manager.SetCameraMode((int)CameraManager.CustomCameraMode.CameraDolly);
        }
    }
}