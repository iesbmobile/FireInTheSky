using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Repository of commonly used prefabs.
/// </summary>
[AddComponentMenu("Gameplay/ObjectPool")]
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    #region member
    /// <summary>
    /// Member class for a prefab entered into the object pool
    /// </summary>
    [Serializable]
    public class ObjectPoolEntry 
	{
        /// <summary>
        /// the object to pre instantiate
        /// </summary>
        [SerializeField]
        public GameObject prefab;
 
        /// <summary>
        /// quantity of object to pre-instantiate
        /// </summary>
        [SerializeField]
        public int count;
    }
    #endregion
 
    /// <summary>
    /// The object prefabs which the pool can handle
    /// by The amount of objects of each type to buffer.
    /// </summary>
    public ObjectPoolEntry[] entries;
 
    /// <summary>
    /// The pooled objects currently available.
    /// Indexed by the index of the objectPrefabs
    /// </summary>
    //[HideInInspector]
    public Hashtable pool;
 
    /// <summary>
    /// The container object that we will keep unused pooled objects so we dont clog up the editor with objects.
    /// </summary>
    protected GameObject containerObject;
 
    void Awake ()
    {
        Instance = this;
    }
 
    // Use this for initialization
    void Start ()
    {
        containerObject = new GameObject("ObjectPool");
 
        //Loop through the object prefabs and make a new list for each one.
        //We do this because the pool can only support prefabs set to it in the editor,
        //so we can assume the lists of pooled objects are in the same order as object prefabs in the array
        pool = new Hashtable();
       
        for (int i = 0; i < entries.Length; i++)
        {
            var objectPrefab = entries[i];
       
            //create the repository
            pool.Add(objectPrefab.prefab.name, new List<GameObject>());
 
            //fill it
            for (int n = 0; n < objectPrefab.count; n++)
            {
 
                var newObj = Instantiate(objectPrefab.prefab) as GameObject;
 
                newObj.name = objectPrefab.prefab.name;
 
                PoolObject(newObj);
            }
        }
    }

	public GameObject GetObjectForType (string objectType, Vector3 position)
	{
		GameObject newGO = GetObjectForType(objectType, false);
		newGO.transform.position = position;
		newGO.SetActive(true);
		return newGO;
	}

	public GameObject GetObjectForType (string objectType)
	{
		return GetObjectForType(objectType, true);
	}
 
    /// <summary>
    /// Gets a new object for the name type provided.  If no object type exists or if onlypooled is true and there is no objects of that type in the pool
    /// then null will be returned.
    /// </summary>
    /// <returns>
    /// The object for type.
    /// </returns>
    /// <param name='objectType'>
    /// Object type.
    /// </param>
    /// <param name='onlyPooled'>
    /// If true, it will only return an object if there is one currently pooled.
    /// </param>
    public GameObject GetObjectForType(string objectType, bool activateNow)
    {
		if (pool.ContainsKey(objectType))
		{
			List<GameObject> objList = (List<GameObject>)pool[objectType];
			if (objList.Count > 0)
			{
				GameObject pooledObject = objList[0];
				objList.RemoveAt(0);
				pooledObject.SetActive(activateNow);
				return pooledObject;
			}
			GameObject newObj = Instantiate(Resources.Load(objectType)) as GameObject;
			newObj.SetActive(activateNow);
			return newObj;
		}
		//If we have gotten here either there was no object of the specified type or non were left in the pool with onlyPooled set to true
		throw new ArgumentException("Não foi encontrado objeto do tipo " + objectType + " na Pool.");
    }
 
    /// <summary>
    /// Pools the object specified.  Will not be pooled if there is no prefab of that type.
    /// </summary>
    /// <param name='obj'>
    /// Object to be pooled.
    /// </param>
    public void PoolObject(GameObject obj)
    {
		obj.name = obj.name.Replace("(Clone)", "");

		if (pool.ContainsKey(obj.name))
		{
			List<GameObject> objList = (List<GameObject>)pool[obj.name];
			obj.SetActive(false);
			obj.transform.parent = containerObject.transform;
			objList.Add(obj);
		}
		else
		{
			List<GameObject> newObjList = new List<GameObject>();
			obj.SetActive(false);
			obj.transform.parent = containerObject.transform;
			newObjList.Add(obj);
			pool.Add(obj.name, newObjList);
		}
    }
}