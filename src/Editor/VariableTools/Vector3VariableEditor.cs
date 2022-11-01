using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Vector3Variable))]
public class Vector3VariableEditor : Editor
{
	public override void OnInspectorGUI()
	{
        Vector3Variable targetScript = (Vector3Variable)target;
        string fileName = EditorGUILayout.TextField("File Name", targetScript.fileName);
		bool debug = EditorGUILayout.Toggle ("Debug", targetScript.debug);
		Vector3 targetValue = EditorGUILayout.Vector3Field ("Value", targetScript.Value);
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
