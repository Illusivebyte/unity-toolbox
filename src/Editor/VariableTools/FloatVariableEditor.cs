using UnityEditor;

[CustomEditor (typeof(FloatVariable))]
public class FloatVariableEditor : Editor
{
	public override void OnInspectorGUI()
	{
        FloatVariable targetScript = (FloatVariable)target;
        string fileName = EditorGUILayout.TextField("File Name", targetScript.fileName);
		bool debug = EditorGUILayout.Toggle ("Debug", targetScript.debug);
		float targetValue = EditorGUILayout.FloatField ("Value", targetScript.Value);
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
