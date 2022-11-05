using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
[RequireComponent(typeof(TilemapCollider2D))]
public class DestructableTileMap : MonoBehaviour
{
    public bool debug;
    protected Tilemap tilemap;
    protected void Awake()
    {
        tilemap = this.gameObject.GetComponent<Tilemap>();
    }


    public void TakeDamage(ContactPoint2D[] contacts, int damage)
    {
        Vector3 hitPosition = Vector3.zero;
        foreach (ContactPoint2D hit in contacts)
        {
            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
            Vector3Int tilePosition = tilemap.WorldToCell(hitPosition);                 
            TileBase tileHit = tilemap.GetTile(tilePosition);
            if (!tileHit)
            {
                continue;
            }
            if (debug)
            {
                Debug.Log(string.Format("tile hit! name: {0}", tileHit.name));
            }        
            tilemap.SetTile(tilePosition, null);
        }
    }
}
