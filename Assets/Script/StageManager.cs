using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
	public static StageManager Instance = null;
	public static Transform currentBlock;

	public Transform[] blockPrefabs;
	public Texture2D[] blockGroundTextures;

	public int numberOfBlocks = 5;

	bool instantiated = false;
	public int blockSize = 16;

	static Vector3 _stageStartPoint = Vector3.zero;
	public static Vector3 stageStartPoint
	{
		set
		{
			_stageStartPoint.x = value.x;
			_stageStartPoint.y = value.y;
		}
	}

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	void Start()
	{
		CreateBlock(Vector3.zero);
	}

	void Update()
	{
		if (StillHasBlocks())
		{
			//transform.Translate(Vector3.forward * 2 * Time.deltaTime, Space.World);
		}
		if (Mathf.Floor(transform.position.z) % blockSize == 0)
		{
			if (!instantiated)
			{
				Vector3 newPoint = new Vector3(0, 0, transform.position.z + 28);
				CreateBlock(newPoint);
				instantiated = true;
			}
		}
		else
		{
			instantiated = false;
		}
	}

	public static void CreateBlock(Vector3 point)
	{
		if (StillHasBlocks())
		{
			int randomBlock = Random.Range(0, Instance.blockPrefabs.Length);
			currentBlock = Instantiate(Instance.blockPrefabs[randomBlock], point, Quaternion.identity) as Transform;
			foreach (Transform t in currentBlock)
			{
				BuildingRandomizer br = t.GetComponent<BuildingRandomizer>();
				if (br)
					br.Randomize();
			}
		}
		Instance.numberOfBlocks--;
	}

	public static bool StillHasBlocks()
	{
		return Instance.numberOfBlocks > 0;
	}
}
