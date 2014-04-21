using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float velocity = 20f;
	public float duration = 5f;

	float startTime;

	void OnEnable ()
	{
		startTime = Time.time;
	}

	void FixedUpdate ()
	{
		if (Time.time - startTime > duration)
		{
			ObjectPool.Instance.PoolObject(gameObject);
		}
		else
		{
			transform.rigidbody.velocity = transform.forward * velocity;
		}
	}
}
