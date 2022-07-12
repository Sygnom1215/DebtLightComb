using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppear : MonoBehaviour
{

    [SerializeField]
    private GameObject catBox;

    void Start()
    {
        catBox.SetActive(false);
    }
    void Update()
    {
        StartCoroutine(Appear());

    }
    private IEnumerator Appear()
    {
        catBox.SetActive(true);
        yield return new WaitForSeconds(Random.Range(5.0f, 17.0f));
        catBox.SetActive(false);

    }
}