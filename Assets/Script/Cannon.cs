using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	public AudioClip shootSound;
	public bool canShoot = true;

	public float lastShot = 0;
	public float shootCooldown = 0.5f;
	public Transform[] cannonPositions;

	void Update ()
	{
		if (canShoot && Time.time - lastShot > shootCooldown)
		{
			lastShot = Time.time;
			ObjectPool.Instance.GetObjectForType("Projectile", cannonPositions[0].position);
		}
	}


	/*

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

		GameObject instantiatedProjectile = Instantiate(projectilePrefab, cannon.transform.position, cannon.transform.rotation) as GameObject;
		instantiatedProjectile.rigidbody.velocity = cannon.transform.TransformDirection(new Vector3(0, 0,speed));


		yield return new WaitForSeconds(2);

		//destroi a instancia \o/
		Destroy(instantiatedProjectile.gameObject);


	}


	public void ShotNormal(GameObject cannon) {

	
		
		audio.PlayOneShot(shot, 0.7F);

		GameObject instantiatedProjectile = Instantiate(projectilePrefab, cannon.transform.position, cannon.transform.rotation) as GameObject;
		instantiatedProjectile.rigidbody.velocity = cannon.transform.TransformDirection(new Vector3(0, 0,speed));
		

		//destroi a instancia \o/
		//Destroy(instantiatedProjectile.gameObject);
		

	}
	*/

}
