using System;
using UnityEngine;
using UnityEditor;

public class HelloWorldWindow : EditorWindow
{
    public string Name = "Kevin";
    [MenuItem("Window/Hello World")]
    public static void ShowWindow()
    {
        GetWindow<HelloWorldWindow>("Hello World");
    }

    private void Update()
    {
        Debug.Log(Name);
    }

    void OnGUI()
    {
        // Create a custom GUIStyle for the label
        GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel);
        titleStyle.fontSize = 30;
        titleStyle.normal.textColor = Color.cyan;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.margin = new RectOffset(0, 0, 20, 20);
        
        GUILayout.Label("Hello World!", titleStyle, GUILayout.ExpandWidth(true));

        GUI.backgroundColor = Color.black;

        
        if (GUILayout.Button("Close", GUILayout.Width(150), GUILayout.Height(40)))
        {
            this.Close();
        }

        // Reset the background color after the button
        GUI.backgroundColor = Color.white;
    }
}
