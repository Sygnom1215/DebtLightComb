using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatEmotion : MonoBehaviour
{
    [SerializeField]
    private GameObject cat;
    [SerializeField]
    private Image image = null;
    [SerializeField]
    private Sprite[] sprite = null;

    private int condition; // 0~10    0~5 : GOOD    6~8 : BAD   10 : MAD 
    private float randomDelay;

    private void Start()
    {
        StartCoroutine(Condition());

    }

    private IEnumerator Condition()
    {
        while (true)
        {
            int changeNum = 0;
            changeNum = Random.Range(-5, 5);

            if (changeNum == 0)
                changeNum = 1;

            condition += changeNum;

            if (condition < 0)
                condition = 0;
            else if (condition > 10)
                condition = 10;


            if (condition == 10)
                image.sprite = sprite[0];
            else if (condition >= 6)
                image.sprite = sprite[1];
            else if (condition >= 0)
                image.sprite = sprite[2];

            yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
        }


    }
}
