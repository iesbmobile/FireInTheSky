using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public static Movement Instance = null;

	public bool move = true;
	public float speed = 4.9f;
	
	void Awake ()
	{
		Instance = this;
	}

	// Update is called once per frame
	void Update ()
	{
		if (move)
			transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
	}
}