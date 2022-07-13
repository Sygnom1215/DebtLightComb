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
    private List<string> dialogs = new List<string>();

    private int textCount = 0;
    private void Awake()
    {
        //speechBubble.GetComponent<Button>().onClick.AddListener(() => { StartTalk(); });
    }
    public void InitDialog(List<string> dialog)
    {
        dialogs.Clear();
        dialogs = dialog;
        StartTalk();
    }
    private void StartTalk()
    {
        if (dialogs.Count <= textCount)
        {
            Debug.Log("¾ø¾î¿ä");
            speechBubble.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() =>
            {
                speechBubble.SetActive(false);
                return;
            });
        }

        dialogText.DOText(dialogs[textCount], 0.1f);
        textCount++;
    }
}

