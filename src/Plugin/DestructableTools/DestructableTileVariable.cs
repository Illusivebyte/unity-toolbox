using UnityEngine;

[CreateAssetMenu(menuName="Destructable/New Destructable Tile")]
public class DestructableTileVariable: ScriptableObject
{
    [SerializeField]
	public string tileName;
    [SerializeField]
    public int tileHealth;
    [SerializeField]
    public GameObject destructionEffect;
}