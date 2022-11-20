using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
	private PooledObject prefab;
	private List<PooledObject> availableObjects = new List<PooledObject>();
	private List<PooledObject> unavailableObjects = new List<PooledObject>();

	public static ObjectPool GetPool (PooledObject prefab) {
		GameObject obj;
		ObjectPool pool;
		if (Application.isEditor) {
			obj = GameObject.Find(prefab.name + " Pool");
			if (obj) {
				pool = obj.GetComponent<ObjectPool>();
				if (pool) {
					return pool;
				}
			}
		}
		obj = new GameObject(prefab.name + " Pool");
		pool = obj.AddComponent<ObjectPool>();
		pool.prefab = prefab;
		return pool;
	}
		
	public PooledObject GetObject () {
		PooledObject obj;
		int lastAvailableIndex = this.availableObjects.Count - 1;
		if (lastAvailableIndex >= 0) {
			obj = this.availableObjects[lastAvailableIndex];
			this.availableObjects.RemoveAt(lastAvailableIndex);
			obj.gameObject.SetActive(true);
		}
		else {
			obj = Instantiate<PooledObject>(this.prefab);
			obj.transform.SetParent(this.transform, false);
			obj.pool = this;
		}
		this.unavailableObjects.Add (obj);
		return obj;
	}

    public PooledObject[] GetActiveObjects()
    {
        return availableObjects.ToArray();
    }

	public void AddObject (PooledObject obj) {
		obj.gameObject.SetActive(false);
		this.availableObjects.Add(obj);
		this.unavailableObjects.Remove (obj);
	}

	public void RecallAllObjects(){
		PooledObject[] objs = this.unavailableObjects.ToArray ();
		for (int i = 0; i < objs.Length; i++) {
			objs [i].ReturnToPool ();
		}
	}
		
}
