using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(EventObject))]
public class EventObjectEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		EventObject targetScript = (EventObject)target;
		if (GUILayout.Button ("Activate Event"))
		{
			targetScript.Activate();
		}
	}
}
