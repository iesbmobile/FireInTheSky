using UnityEngine;
using System.Collections;

public class CannonRight : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20;
	public AudioClip shot;


	float delay = 0.1f;
	float timer = 0.0f;


	// Use this for initialization
	void Start () {
		Random.seed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("right")){			
			//if (Input.GetButton("Fire1")){			

			StartCoroutine(MyMethod());

			timer += Time.deltaTime;
			//Debug.Log(timer);
			if (timer >= delay){
				
				Debug.Log("---");
				//timer = 0.0;
				
			}


		}

	}

	IEnumerator MyMethod() {
		Debug.Log("Antes");
		yield return new WaitForSeconds(Random.Range(0, 2));

		audio.PlayOneShot(shot, 0.7F);
		
		Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
		instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));

		Debug.Log("Depois");
	}


}