using System.Collections.Generic;
using UnityEngine;

public class ObjectPool {

    private List<GameObject> pool = new List<GameObject>();
    private int index = 0;
    private int active = 0;

    public ObjectPool(GameObject prefab) : this(prefab, 10) { }

    public ObjectPool(GameObject prefab, int number) {
        GameObject instance;
        for (var i = 0; i < number; i++) {
            instance = Object.Instantiate(prefab, Vector2.zero, Quaternion.identity);
            instance.SetActive(false);
            pool.Add(instance);
        }
    }

    public GameObject RetrieveNext() {
        var go = pool[index];
        go.SetActive(true);
        active++;
        index++;
        if (index > pool.Count - 1) {
            index = 0;
        }
        return go;
    }

    public void ReturnToPool(GameObject go) {
        go.SetActive(false);
        active--;
    }
}
