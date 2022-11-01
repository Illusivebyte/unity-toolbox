using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Vector2Variable))]
public class Vector2VariableEditor : Editor
{
	public override void OnInspectorGUI()
	{
        Vector2Variable targetScript = (Vector2Variable)target;
        string fileName = EditorGUILayout.TextField("File Name", targetScript.fileName);
		bool debug = EditorGUILayout.Toggle ("Debug", targetScript.debug);
		Vector2 targetValue = EditorGUILayout.Vector2Field ("Value", targetScript.Value);
		if (targetValue != targetScript.Value)
		{
			targetScript.Value = targetValue;
			EditorUtility.SetDirty (target);
		}
		if (debug != targetScript.debug)
		{
			targetScript.debug = debug;
			EditorUtility.SetDirty (target);
		}
        if (fileName != targetScript.fileName)
        {
            targetScript.fileName = fileName;
            EditorUtility.SetDirty(target);
        }
	}
}
