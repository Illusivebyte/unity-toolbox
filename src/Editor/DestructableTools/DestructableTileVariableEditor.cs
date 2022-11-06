using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(DestructableTileVariable))]
public class DestructableTileVariableEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DestructableTileVariable targetScript = (DestructableTileVariable) target;
		string targetTileName = EditorGUILayout.TextField ("Tile Name", targetScript.tileName);
		if (targetTileName != targetScript.tileName)
		{
			targetScript.tileName = targetTileName;
			EditorUtility.SetDirty(target);
		}

		int targetTileHealth = EditorGUILayout.IntField ("Tile Health", targetScript.tileHealth);
		if (targetTileHealth != targetScript.tileHealth)
		{
			targetScript.tileHealth = targetTileHealth;
			EditorUtility.SetDirty(target);
		}
        GUIContent content = new GUIContent("Destruction Effect");
		GameObject targetDestructionEffect = (GameObject) EditorGUILayout.ObjectField(content, targetScript.destructionEffect, typeof(GameObject), false, null);
		if ( targetDestructionEffect != targetScript.destructionEffect)
		{
			targetScript.destructionEffect = targetDestructionEffect;
			EditorUtility.SetDirty(target);
		}
	}
}