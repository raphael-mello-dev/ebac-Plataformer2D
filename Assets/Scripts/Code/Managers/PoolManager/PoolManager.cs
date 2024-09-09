using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<GameObject> _objectPool;
    [SerializeField] private int _poolCapacity;

    private void Awake()
    {
        PoolStart();
    }

    private void PoolStart()
    {
        _objectPool = new List<GameObject>();

        for(int i = 0; i < _poolCapacity; i++)
        {
            var obj = Instantiate(_prefab);
            obj.SetActive(false);
            _objectPool.Add(obj);
        }
    }

    public GameObject GetPooledObjects()
    {
        for (int i = 0 ; i < _poolCapacity; i++)
        {
            if (!_objectPool[i].activeInHierarchy)
                return _objectPool[i];
        }

        return null;
    }
}
