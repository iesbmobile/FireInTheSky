using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Camera gameCamera;
	float speed = 7f;


	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
		Vector3 pos = gameCamera.WorldToViewportPoint(transform.position);


		if (Input.GetKey(KeyCode.W) && pos.z<35.0f){
			transform.Translate(0,0,1f * speed * Time.deltaTime);

		}

		if (Input.GetKey(KeyCode.A) && pos.x>0.1f){		
			transform.Translate(-1f * speed * Time.deltaTime,0,0);
		}

		if (Input.GetKey(KeyCode.S)&& pos.z>20.5f ){

			if(pos.x<0.1f){
				transform.Translate(1.5f * Time.deltaTime,0,0);
			}
			if(pos.x>0.9f){
				transform.Translate(-1.5f * Time.deltaTime,0,0);
			}
			transform.Translate(0,0,-1f * speed * Time.deltaTime);

		}


		if (Input.GetKey(KeyCode.D)&& pos.x<0.9f){
			transform.Translate(1f * speed * Time.deltaTime,0,0);
		}

	}

}