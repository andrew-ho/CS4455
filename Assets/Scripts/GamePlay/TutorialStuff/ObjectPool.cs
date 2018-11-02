using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDic;
	// Use this for initialization
	void Start () {
        poolDic = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDic.Add(pool.tag, objectPool);
        }
	}
	
    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rotation)
    {
        if (!poolDic.ContainsKey(tag))
        {
            Debug.Log("Doesnt exist");
            return null;
        }
        GameObject objectToSpawn = poolDic[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rotation;
        poolDic[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

	// Update is called once per frame
	void FixedUpdate () {
        SpawnFromPool("Cube", transform.position, Quaternion.identity);
	}
}
