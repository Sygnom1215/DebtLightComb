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

    private int condition; // 0~10    0~3 : GOOD    4~8 : BAD   9~10 : MAD 
    private float randomDelay;

    private void Start()
    {
        StartCoroutine(Condition());

    }

    private IEnumerator Condition()
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


        if (condition >= 0 || condition <= 3)
            image.sprite = sprite[0];
        else if (condition >= 4 || condition <= 8)
            image.sprite = sprite[1];
        else if (condition >= 9 || condition <= 10)
            image.sprite = sprite[2];

        yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));

    }
}
