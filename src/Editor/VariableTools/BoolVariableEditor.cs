using UnityEditor;

[CustomEditor (typeof(BoolVariable))]
public class BoolVariableEditor : Editor
{
	public override void OnInspectorGUI()
	{
		BoolVariable targetScript = (BoolVariable)target;
        string fileName = EditorGUILayout.TextField("File Name", targetScript.fileName);
		bool debug = EditorGUILayout.Toggle ("Debug", targetScript.debug);
		bool targetValue = EditorGUILayout.Toggle ("Value", targetScript.Value);
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
