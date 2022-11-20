using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour {
	public ObjectPool pool { get; set; }

	public bool timedReturn;
	public float returnDelay;

	public void OnEnable()
	{
		if(timedReturn)
			StartCoroutine(ReturnRoutine());
	}

	private IEnumerator ReturnRoutine()
	{
		yield return new WaitForSeconds(returnDelay);
		ReturnToPool();
	}

	public void ReturnToPool () {
		if (pool) {
			pool.AddObject(this);
		}
		else {
			Destroy(gameObject);
		}
	}
}
