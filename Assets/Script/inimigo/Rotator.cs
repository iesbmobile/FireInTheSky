using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	//public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 dir = transform.position - player.transform.position;

		Vector3 playerPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;



		Vector3 direcao = playerPosition - transform.position;
		//Vector3 severino = new Vector3 (GameObject.FindGameObjectWithTag ("Player").transform.position.x - transform.position.x,
		//                                transform.position.y,
		//                                -GameObject.FindGameObjectWithTag ("Player").transform.position.z - transform.position.z);



		//Quaternion r = Quaternion.LookRotation (dir);
		//missil.tranform.rotation = r;

		Vector3 aimVec = new Vector3 (direcao.x, 0, direcao.z);

		// Missil update() { tranform.position = transform.forward * 10}
		Quaternion q = Quaternion.LookRotation (aimVec, Vector3.up);
		transform.rotation = q;//new Quaternion(0, q.y, 0, 1);
	}
}
