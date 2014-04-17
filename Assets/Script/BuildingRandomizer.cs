using UnityEngine;
using System.Collections;

public class BuildingRandomizer : MonoBehaviour
{
	public Transform[] buildings;

	public void Randomize()
	{
		int randomBuilding = Random.Range(0, buildings.Length);
		Transform t = Instantiate(buildings[randomBuilding], transform.position, transform.rotation) as Transform;
		t.parent = transform.parent;
	}
}

