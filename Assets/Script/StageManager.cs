using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour
{
	public static StageManager Instance = null;

	public List<Block> allBlocks = new List<Block>();

	public Transform[] blockPrefabs;
	public Texture2D[] blockGroundTextures;

	public Block currentBlock;

	public int blockSize = 64;
	public int numberOfBlocks = 5;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		CreateBlock(Vector3.zero);
	}

	Vector3 viewportUpperRay = new Vector3(0.5f, 1f, 0);
	Vector3 viewportDownRay = new Vector3(0.5f, 0, 0);

	void Update()
	{
		
		Ray cameraUpperRaycast = Camera.main.ViewportPointToRay(viewportUpperRay);
		Ray cameraDownRaycast = Camera.main.ViewportPointToRay(viewportDownRay);

		Debug.DrawLine(cameraUpperRaycast.origin, cameraUpperRaycast.origin + cameraUpperRaycast.direction * 99f);
		Debug.DrawLine(cameraUpperRaycast.origin, cameraDownRaycast.origin + cameraDownRaycast.direction * 99f);

		if (!Physics.Raycast(cameraUpperRaycast))
		{
			CreateBlock(currentBlock.GetEndPosition());
		}

		for (int i = 0; i < allBlocks.Count; i++)
		{
			Vector3 pointOnForwardLine = cameraDownRaycast.GetPoint(Camera.main.transform.position.y);
			Debug.DrawLine(pointOnForwardLine, pointOnForwardLine + Vector3.up * 99f);

			if (allBlocks[i].GetEndPosition().z < pointOnForwardLine.z)
			{
				Block block = allBlocks[i];
				allBlocks.Remove(block);
				Destroy(block.gameObject);
				i--;
			}
		}
	}

	public void CreateBlock(Vector3 point)
	{
		if (StillHasBlocks())
		{
			int randomBlock = Random.Range(0, blockPrefabs.Length);
			Transform newBlock = Instantiate(blockPrefabs[randomBlock], point, Quaternion.identity) as Transform;
			currentBlock = newBlock.GetComponent<Block>();
			allBlocks.Add(currentBlock);
			foreach (Transform t in newBlock)
			{
				BuildingRandomizer br = t.GetComponent<BuildingRandomizer>();
				if (br)
					br.Randomize();
			}
		}
		else
		{
			Movement.Instance.move = false;
		}
		numberOfBlocks--;
	}

	public bool StillHasBlocks()
	{
		return numberOfBlocks > 0;
	}
}
