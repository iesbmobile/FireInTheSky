using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
	public Vector3 endPosition;

	public Vector3 GetEndPosition ()
	{
		return transform.TransformPoint(endPosition);
	}
}
