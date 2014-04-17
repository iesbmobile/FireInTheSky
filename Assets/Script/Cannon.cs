using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20;
	public AudioClip shot;
	private bool canShot = true;

	public float tempoEntreTiro = 0f;
	private float Count = 2f;
	//public string name = "";
	GameObject[] cannons;

	// Use this for initialization
	void Start () {
		Random.seed = 1;
	}
	
	// Update is called once per frame
	void Update () {



		if (Count >= 1.1f) {
			canShot = true;
		}

		if (canShot) {
	
			cannons = GameObject.FindGameObjectsWithTag("Cannon");
			
			for(int x = 0; x < cannons.Length; x++){
				
				StartCoroutine(Shot(cannons[x]));
				//ShotNormal(cannons[x]);
			}
			canShot =  false;

			Count = tempoEntreTiro;
		} 

		Count = Count + Time.deltaTime;

		Debug.Log ("count: " + Count);



	}

	IEnumerator Shot(GameObject cannon) {

		//yield return new WaitForSeconds(1);
		
		//audio.PlayOneShot(shot, 0.7F);
		
		Rigidbody instantiatedProjectile = Instantiate(projectile,cannon.transform.position,cannon.transform.rotation)as Rigidbody;
		instantiatedProjectile.velocity = cannon.transform.TransformDirection(new Vector3(0, 0,speed));


		yield return new WaitForSeconds(2);

		//destroi a instancia \o/
		Destroy(instantiatedProjectile.gameObject);


	}


	public void ShotNormal(GameObject cannon) {

	
		
		audio.PlayOneShot(shot, 0.7F);
		
		Rigidbody instantiatedProjectile = Instantiate(projectile,cannon.transform.position,cannon.transform.rotation)as Rigidbody;
		instantiatedProjectile.velocity = cannon.transform.TransformDirection(new Vector3(0, 0,speed));
		

		//destroi a instancia \o/
		//Destroy(instantiatedProjectile.gameObject);
		

	}


}
