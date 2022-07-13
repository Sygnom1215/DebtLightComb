using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAppear : MonoBehaviour
{

    [SerializeField]
    private GameObject catBox;
    [SerializeField]
    private GameObject bubble;
    [SerializeField]
    private Text bubbleText;

    private Image image;

    IEnumerator Start()
    {

        //catBox.SetActive(false);
        catBox.GetComponent<Image>().DOFade(0, 0f);
        bubble.GetComponent<Image>().DOFade(0, 0f);
        bubbleText.DOFade(0, 0f);
        yield return new WaitForSeconds(Random.Range(3.0f, 7.0f)); // ±â´Ù·Á
        StartCoroutine(Appear());
    }
    private IEnumerator Appear()
    {
        while (true)
        {
            catBox.GetComponent<Image>().DOFade(1, 0.3f);
            bubble.GetComponent<Image>().DOFade(1, 0.7f);
            bubbleText.DOFade(1, 0.7f);
            yield return new WaitForSeconds(Random.Range(5.0f, 7.0f));


            catBox.GetComponent<Image>().DOFade(0, 0.3f);
            bubble.GetComponent<Image>().DOFade(0, 0.7f);
            bubbleText.DOFade(0, 0.7f);
            yield return new WaitForSeconds(Random.Range(30f, 40f));
        }
    }
}