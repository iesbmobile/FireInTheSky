using UnityEngine;
using System.Collections;

public class ControleInimigos : MonoBehaviour {

	public GameObject mainCamera;
	public int qntdeInimigos = 10;
	public bool podeCriarInimigo = true;

	public GameObject tanquePrefab;
	// Use this for initialization
	void Start () {
		StartCoroutine(criarInimigos());
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Inimigo")) {
		//foreach(GameObject obj in GameObject.FindGameObjectWithTag("Player")) {
			if(obj.transform.position.z < mainCamera.transform.position.z){
				Destroy(obj);
			}
		}
	}

	IEnumerator criarInimigos() {
		float waitTime = Random.Range(2,4);
		yield return new WaitForSeconds(waitTime);
		instanciarInimigo();
		StartCoroutine(criarInimigos());
	}

	void instanciarInimigo() {
		Debug.Log ("Inicio Inimigo");

		if(GameObject.FindGameObjectsWithTag("Inimigo").Length <= 10) {
			if(podeCriarInimigo){
				criarInimigo();
			}
		}


	}

	void criarInimigo() {
		Debug.Log(GameObject.FindGameObjectsWithTag("Inimigo").Length);
		
		float posicaoX = Random.Range(4,-4);
		Vector3 startPosition  = new Vector3(
			posicaoX,
			0.65f,
			mainCamera.transform.position.z + 30);
		Vector3 posicao = mainCamera.transform.position;
		Quaternion rotation = new Quaternion();
		Instantiate(tanquePrefab, startPosition , rotation);//mainCamera.transform.rotation);
	}
}


/*

 void Start() {
        print("Starting " + Time.time);
        StartCoroutine(createAsteroids());
		print("Before WaitAndPrint Finishes " + Time.time);
    }
	
    IEnumerator createAsteroids() {
		float waitTime = Random.Range(0,5);
        yield return new WaitForSeconds(waitTime);
		instantiateAsteroid();
        StartCoroutine(createAsteroids());
    }
	
	
	void instantiateAsteroid() {*/