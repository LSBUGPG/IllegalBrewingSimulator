using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject itemPrefab;

    GameObject grapes;

    void Start()
    {
        Spawn();
    }

    public void Update()
    {
        if(grapes == null)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        grapes = Instantiate(itemPrefab, transform.position, transform.rotation);
    }
}
