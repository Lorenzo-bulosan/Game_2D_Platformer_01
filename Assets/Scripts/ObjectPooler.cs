using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }

    public List<GameObject> pooledObjects;

    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private int poolAmount;

    public bool shouldExpand = true;

    private void Awake()
    {
        // Create public instance
        Instance = this;
    }

    private void Start()
    {
        // Create pooled list on start
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolAmount; i++)
        {
            CreatePooledObject();
        }
    }

    /// <summary>
    /// Return a pooled object
    /// </summary>
    /// <returns>GameObject Prefab</returns>
    public GameObject GetPooledObject()
    {
        // Loop through all the gameobjects
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // Return inactive pooled object
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // Increase size of list if allowed
        if (shouldExpand)
        {
            GameObject obj = CreatePooledObject();
            return obj;
        }
        else
        {
            return null;
        }
    }

    // Instantiate object to be pooled and deactivate it
    private GameObject CreatePooledObject()
    {
        GameObject obj = Instantiate(objectPrefab, transform, true);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
