using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(EnemyScenceConfig))]
public class EnemyScenceConfigEditor : Editor
{
  
    EnemyScenceConfig myscript;

    private void OnEnable()
    {
        myscript = (EnemyScenceConfig)target;
    }


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GUILayout.Label("------- Add Action Enemy Point -----------");
      
        if (GUILayout.Button("Add Point"))
        {
            myscript.OnAddEnemyActionPoint();
        }
    }
}
