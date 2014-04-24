using UnityEngine;
using System.Collections;

public class WayPoints : MonoBehaviour {

	private float distanceLess = 900;
	private int index = 0;
	public GameObject[] arrayPoints;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}

	void SearchWayPoint(){
		for(int i = 0; i < arrayPoints.Length; i++){
			GameObject wayPoint = arrayPoints[i];
			if(Vector3.Distance (transform.position, wayPoint.transform.position) < distanceLess){
				distanceLess = Vector3.Distance (transform.position, wayPoint.transform.position);
				index = i;
			}

		}
	}

}
