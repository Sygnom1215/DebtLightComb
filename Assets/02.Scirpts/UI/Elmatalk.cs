using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elmatalk : MonoBehaviour
{
    [SerializeField]
    private Image bubble;
    [SerializeField]
    private Text talk;
    [SerializeField]
    private List<string> dialogs = new List<string>();

    private int dialogCount = 0;

    private void Start()
    {
        bubble.DOFade(0, 0f);
        talk.DOText(" ", 0f);
    }
    public void ElmaTalk()
    {
        StartCoroutine(ElmaTalking());
    }

    private IEnumerator ElmaTalking()
    {


        bubble.DOFade(1, 1f);
        talk.DOText(dialogs[Random.Range(0, dialogs.Count)], 1f);

        yield return new WaitForSeconds(2f);
        bubble.DOFade(0, 1f);
        talk.DOText(" ", 1f);

    }
}
