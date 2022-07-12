using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEmotion : MonoBehaviour
{
    enum Emotion
    {
        basic,
        anger1,
        anger2
    };
    [SerializeField]
    private GameObject cat;

    private float conditionNum;

    private void Start()
    {
        StartCoroutine(Condition());

    }
    private void Update()
    {
        
    }
    private IEnumerator Condition()
    {
        yield return 0;
        yield return 1;
        yield return 2;
    }
}
