using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(QuaternionVariable))]
public class QuaternionVariableEditor : Editor
{
	public override void OnInspectorGUI()
	{
        QuaternionVariable targetScript = (QuaternionVariable)target;
        string fileName = EditorGUILayout.TextField("File Name", targetScript.fileName);
		bool debug = EditorGUILayout.Toggle ("Debug", targetScript.debug);
		Quaternion targetValue = Vector4ToQuaternion(EditorGUILayout.Vector4Field ("Value", QuaternionToVector4(targetScript.Value)));
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
	static Vector4 QuaternionToVector4(Quaternion rot)
	{
		return new Vector4(rot.x, rot.y, rot.z, rot.w);
	}

	static Quaternion Vector4ToQuaternion(Vector4 vec)
	{
		return new Quaternion (vec.x, vec.y, vec.z, vec.w);
	}
}
