using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppear : MonoBehaviour
{

    [SerializeField]
    private GameObject catBox;

    private bool isAppear;

    void Start()
    {
        catBox.SetActive(false);
        isAppear = false;
    }
    void Update()
    {
        //StartCoroutine(Appear());
        if (isAppear == false)
            Invoke("AppearCat", Random.Range(5.0f, 17.0f));


    }

    //private IEnumerator Appear()
    //{
    //    catBox.SetActive(true);
    //    yield return new WaitForSeconds(Random.Range(5.0f, 17.0f));
    //    catBox.SetActive(false);
    //}

    private void AppearCat()
    {
        catBox.SetActive(true);
        isAppear = true;
    }
}