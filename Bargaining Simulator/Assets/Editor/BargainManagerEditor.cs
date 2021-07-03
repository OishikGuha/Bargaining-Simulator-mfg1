using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BargainManager))]
public class BargainManagerEditor : Editor {
    
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        BargainManager manager = (BargainManager)target;

        EditorGUILayout.BeginHorizontal();        
        if(GUILayout.Button("Reduce Cost!"))
        {
            manager.ReduceCost(1);
        }

        if (GUILayout.Button("Add Cost"))
        {
            manager.ReduceCost(-1);
        }
        EditorGUILayout.EndHorizontal();
    }
}