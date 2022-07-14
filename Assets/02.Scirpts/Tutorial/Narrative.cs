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

        titleText.DOText("천지복음 제 1장 \n", 5f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(StartTalk());
    }

    private IEnumerator StartTalk()
    {

        narrateText.DOText("태초에 창조신이 천지를 창조하시니라.\n\n땅이 혼돈하고 공허하며 흑암이 깊음 위에 있고,\n\n창조신의 영은 수면 위에 운행하시니,\n\n" +
            "창조신이 이르시되 빗이 있으라 하시니 빗이 있었고,\n\n창조신이 이르시되 빛이 있으라 하시니 빛이 있었고,\n\n창조신이 이르시되 빚이 있으라 하시니 빚이 " +
            "있었고\n\n…어?\n\n마탑 내 최하층, 한 마법사가 눈을 뜬다.\n\n“하…..내가 어쩌다 이렇게 된건지……….”\n\n\n\n세계 최고의 마법사,\n\n154억 골드의 빚을 지고 " +
            "마탑의 최하층에 갇혔다.\n\n“이 빗만 있으면……다시 마탑주가 될 수 있어”\n\n마탑의 최상층, 마탑주의 자리에 오를 때까지\n\n빗을 팔아 빚을 갚고 빛을 되찾자.", 10f).OnComplete(() =>
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
