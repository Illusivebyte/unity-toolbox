using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
[RequireComponent(typeof(TilemapCollider2D))]
public class DestructableTileMap : MonoBehaviour
{
    public bool debug;
    protected Tilemap tilemap;
    protected Dictionary<Vector3Int, DestructableTile> tilesDictionary;
    public int defaultTileHealth;
    public GameObject defaultTileDestructionEffect;
    public DestructableTileVariable[] destructableTileVariables;

    protected void Awake()
    {
        tilemap = this.gameObject.GetComponent<Tilemap>();
        tilesDictionary = new Dictionary<Vector3Int, DestructableTile>();


        BoundsInt bounds = tilemap.cellBounds;
        for (int x = bounds.xMin; x < bounds.xMax; x++) 
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++) 
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(tilePosition);
                if (tile != null) 
                {
                    if (debug)
                    {
                        Debug.Log(string.Format("Found tile at ({0},{1}) with name: {2}", x, y, tile.name));
                    }
                    DestructableTileVariable destructableTileVariable = null;
                    foreach (DestructableTileVariable variable in destructableTileVariables)
                    {
                        if (variable.tileName == tile.name)
                        {
                            if (debug)
                            {
                                Debug.Log("Found Matching DestructableTile Name");
                            }
                            destructableTileVariable = variable;
                            break;
                        }
                    }
                    DestructableTile destructableTile;
                    if (destructableTileVariable != null)
                    {
                        destructableTile = new DestructableTile(destructableTileVariable.tileName, destructableTileVariable.tileHealth, destructableTileVariable.destructionEffect); 
                    }
                    else 
                    {
                        if (debug)
                        {
                            Debug.Log(string.Format("Did not find a matching DestruvtableTile Name for {0}, resorting to defaults", tile.name));
                        }
                        destructableTile = new DestructableTile(tile.name, defaultTileHealth, defaultTileDestructionEffect); 
                    }
                    if (!tilesDictionary.ContainsKey(tilePosition))
                    {
                        tilesDictionary.Add(tilePosition, destructableTile);
                    }
                }
            }
        } 
        if (debug)
        {
            Debug.Log(string.Format("Found a total of {0} tiles", tilesDictionary.Keys.Count));
        }
    }


    public int TakeDamage(ContactPoint2D[] contacts, int damage)
    {
        Vector3 hitPosition = Vector3.zero;
        int totalDamageDone = 0;
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
            DestructableTile destructableTile = new DestructableTile();
            bool retVal = tilesDictionary.TryGetValue(tilePosition, out destructableTile);
            if (!retVal)
            {
                continue;
            }
            totalDamageDone += destructableTile.takeDamage(damage);
            if (destructableTile.isDestroyed())
            {
                if (debug)
                {
                    Debug.Log(string.Format("tile {0} is destroyed! removing from tiles lookup", destructableTile.tileName));
                }
                tilemap.SetTile(tilePosition, null);
                tilesDictionary.Remove(tilePosition);
                if (destructableTile.destructionEffect != null)
                {
                    if (debug)
                    {
                        Debug.Log("playing tile destruction effect");
                    }
                    Vector3 worldPosition = tilemap.CellToWorld(tilePosition);
                    GameObject.Instantiate(destructableTile.destructionEffect, worldPosition, Quaternion.identity);
                }
                
            } 
            
        }
        return totalDamageDone;
    }
    public class DestructableTile {
        public string tileName {get;}
        protected int tileHealth {get; set;}

        public GameObject destructionEffect {get;}

        public DestructableTile()
        {
            this.tileName = "notset";
            this.tileHealth = 0;
            this.destructionEffect = null;
        }

        public DestructableTile (string tileName, int tileHealth, GameObject destructionEffect)
        {
            this.tileName = tileName;
            this.tileHealth = tileHealth;
            this.destructionEffect = destructionEffect;
        }

        public bool isDestroyed()
        {
            return tileHealth <= 0;
        }

        public int takeDamage(int damage)
        {
            tileHealth -= damage;
            if (tileHealth < 0)
            {
                return damage + tileHealth;
            }
            else 
            {
                return damage;
            }
            
        }
    }
}
