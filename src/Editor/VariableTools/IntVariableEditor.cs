using UnityEditor;

[CustomEditor (typeof(IntVariable))]
public class IntVariableEditor : Editor
{
	public override void OnInspectorGUI()
	{
		IntVariable targetScript = (IntVariable)target;
        string fileName = EditorGUILayout.TextField("File Name", targetScript.fileName);
		bool debug = EditorGUILayout.Toggle ("Debug", targetScript.debug);
		int targetValue = EditorGUILayout.IntField ("Value", targetScript.Value);
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
