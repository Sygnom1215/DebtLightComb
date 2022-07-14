using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Narrative : MonoBehaviour
{
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text narrateText;
    [SerializeField]
    private GameObject magicCat;
    [SerializeField]
    private Image bubbleImage;
    [SerializeField]
    private Text bubbleText;
    [SerializeField]
    private List<string> dialogs = new List<string>();


    private Button startButton;
    private Image image;
    private int dialogCount = 0;

    private IEnumerator Start()
    {
        magicCat.GetComponent<Image>().DOFade(0, 0f);
        bubbleImage.DOFade(0, 0f);
        bubbleText.DOText(" ", 0f);

        titleText.DOText("õ������ �� 1�� \n", 5f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(StartTalk());
    }

    private IEnumerator StartTalk()
    {

        narrateText.DOText("���ʿ� â������ õ���� â���Ͻô϶�.\n\n���� ȥ���ϰ� �����ϸ� ����� ���� ���� �ְ�,\n\nâ������ ���� ���� ���� �����Ͻô�,\n\n" +
            "â������ �̸��õ� ���� ������ �Ͻô� ���� �־���,\n\nâ������ �̸��õ� ���� ������ �Ͻô� ���� �־���,\n\nâ������ �̸��õ� ���� ������ �Ͻô� ���� " +
            "�־���\n\n����?\n\n��ž �� ������, �� �����簡 ���� ���.\n\n���ϡ�..���� ��¼�� �̷��� �Ȱ���������.��\n\n\n\n���� �ְ��� ������,\n\n154�� ����� ���� ���� " +
            "��ž�� �������� ������.\n\n���� ���� �����顦���ٽ� ��ž�ְ� �� �� �־\n\n��ž�� �ֻ���, ��ž���� �ڸ��� ���� ������\n\n���� �Ⱦ� ���� ���� ���� ��ã��.", 10f).OnComplete(() =>
            {

                titleText.DOText("\n", 0f);
                narrateText.DOText("\n\n\n\n\n\n\n\n", 0f);

                magicCat.GetComponent<Image>().DOFade(1, 1f);
                bubbleImage.DOFade(1, 3f);

                StartChat();

            });// 25f

        yield return new WaitForSeconds(3f);


    }

    public void StartChat()
    {
        if (dialogs.Count <= dialogCount)
            SceneManager.LoadScene("PlayScene");

        bubbleText.DOText(" ", 0f);
        bubbleText.DOText(dialogs[dialogCount], 1f);
        dialogCount++;
    }
}
