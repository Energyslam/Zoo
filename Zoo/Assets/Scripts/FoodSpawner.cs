using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoo;

public class FoodSpawner : MonoBehaviour
{
    public GameObject meat;

    void Start()
    {
        StartCoroutine(meatSpawner());
    }

    IEnumerator meatSpawner()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(meat, transform).GetComponent<Meat>();
        StartCoroutine(meatSpawner());
    }
}