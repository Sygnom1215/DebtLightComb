using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppear : MonoBehaviour
{

    [SerializeField]
    private GameObject catBox;

    IEnumerator Start()
    {
        
        catBox.SetActive(false);
        yield return new WaitForSeconds(Random.Range(3.0f, 7.0f)); // ±â´Ù·Á
        StartCoroutine(Appear());
    }
    private IEnumerator Appear()
    {
        while(true)
        {
            catBox.SetActive(true);
            yield return new WaitForSeconds(Random.Range(5.0f, 7.0f));
            catBox.SetActive(false);
            yield return new WaitForSeconds(Random.Range(30f, 40f));
        }
    }
}