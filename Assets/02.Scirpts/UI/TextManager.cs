using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private Text dialogText;

    public string dialog;

    private void Start()
    {
        StartTalk();
    }

    public void StartTalk()
    {
        dialogText.DOText(dialog, dialog.Length * 0.1f);
    }
}
