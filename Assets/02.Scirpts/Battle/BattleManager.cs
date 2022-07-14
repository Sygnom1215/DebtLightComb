using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private BattleSO battleSO;
    [SerializeField]
    private PlayerSO playerSO;
    [SerializeField]
    private RectTransform cameraTransform;
    [SerializeField]
    private Button hitButton;
    private void Start()
    {
        hitButton.onClick.AddListener(() => { PlayerAttack(); });
    }
    private void PlayerAttack()
    {
        cameraTransform.DOKill();
        battleSO.hp -= playerSO.damage;
        Color color;
        ColorUtility.TryParseHtmlString("#FFBDBD", out color);
        cameraTransform.gameObject.GetComponent<Image>().color = color;
        cameraTransform.DOShakeAnchorPos(0.4f, 30f).OnComplete(() =>
        {
            cameraTransform.DOAnchorPos(Vector2.zero, 0.1f);
            cameraTransform.gameObject.GetComponent<Image>().color = Color.white;
        });
    }
}
