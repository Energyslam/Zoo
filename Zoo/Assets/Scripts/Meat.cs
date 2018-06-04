using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    int left = 0;
    int right = 550;
    int bottom = 0;
    int top = 550;


    void Start()
    {
        transform.position = new Vector3(Random.Range(left, right), Random.Range(bottom, top), 0);
        StartCoroutine(DestroySelf());
    }

    public void DestroyOnClick()
    {
        Destroy(this.gameObject);
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);

    }
}
