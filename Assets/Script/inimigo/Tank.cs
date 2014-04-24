using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {
	bool vertical = true;
	// Use this for initialization
	void Start () {
		//Debug.Log ("start tank");
		//float x = Random.Range (1, 10);
		//if(x < 3) {
		//	vertical = false;
		//}
	}
	
	// Update is called once per frame
	void Update () {
		//if(vertical) {
			transform.position = new Vector3(
				transform.position.x, transform.position.y, transform.position.z - 0.9f);

		/*} else {
			float velocityX = 0.0f;
			Debug.Log("HORIZONTAL" + transform.position.x);
			if(transform.position.x >=0.0f && transform.position.x >= -4.0f) {
				Debug.Log("ifffff");
				velocityX = -0.009f;
			} else if(transform.position.x < 0.0f && transform.position.x <=4.0f) {
				Debug.Log("elseeeee");
				velocityX = 0.009f;
			}
			transform.position = new Vector3(
				transform.position.x + velocityX, transform.position.y, transform.position.z);
		}*/
	}
}
