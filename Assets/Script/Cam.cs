using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

	float speed = 4.9f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,0,1f * speed * Time.deltaTime, Space.World);
	}
}
