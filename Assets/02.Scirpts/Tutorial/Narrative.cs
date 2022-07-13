using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narrative : MonoBehaviour
{
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text narrateText;

    private List<string> dialogs = new List<string>();

    private IEnumerator Start()
    {
        titleText.DOText("천지복음 제 1장 \n", 5f);
        yield return new WaitForSeconds(1f);
        StartTalk();
    }

    private void StartTalk()
    {

        narrateText.DOText("태초에 창조신이 천지를 창조하시니라\n\n땅이 혼돈하고 공허하며 흑암이 깊음 위에 있고\n\n창조신의 영은 수면 위에 운행하시니 창조신이 이르시되\n\n빗이 있으라 하시니 빗이 있었고\n\n창조신이 이르시되 빛이 있으라 하시니 빛이 있었고\n\n창조신이 이르시되 빚이 있으라 하시니 빚이 있었고…어 ?\n\n마탑 내 최하층, 한 마법사가 눈을 뜬다\n\n“하…..내가 어쩌다 이렇게 된건지……….”\n\n세계 최고의 마법사,\n\n154억 골드의 빚을 지고 마탑의 최하층에 갇혔다.\n\n“이 빗만 있으면……다시 마탑주가 될 수 있어”\n\n마탑의 최상층, 마탑주의 자리에 오를 때까지\n\n빗을 팔아 빚을 갚고 빛을 되찾자", 40f);

    }
}
