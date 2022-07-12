using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject speechBubble;
    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private List<string> dialogs = new List<string>();

    private int textCount = 0;

    public void StartTalk()
    {
        //StartCoroutine(Talk());
        if (dialogs.Count <= textCount)
        {
            Debug.Log("�����");
            speechBubble.SetActive(false);
        }
        dialogText.DOText(dialogs[textCount], 0.1f);
        textCount++;

    }


}
