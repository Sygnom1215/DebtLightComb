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
    [SerializeField]
    private Slider playerHpSlider;
    [SerializeField]
    private Slider enemyHpSlider;
    [SerializeField]
    private GameObject BloodScreen;
    [SerializeField]
    private TextManager textManager;
    [SerializeField]
    private ButtonManager buttonManager;
    private int initPlayerHP;
    private int initEnemyHP;
    private bool isAttackCoolTime = false;
    private void Start()
    {
        BloodScreen.SetActive(false);
        enemyHpSlider.maxValue = battleSO.hp;
        playerHpSlider.maxValue = playerSO.hp;
        initPlayerHP = playerSO.hp;
        initEnemyHP = battleSO.hp;
        SetHpUI();
        hitButton.onClick.AddListener(() => { PlayerAttack(); });
    }
    private void JudgeWinAndLoose()
    {
        if (battleSO.hp > 0 && playerSO.hp > 0) return;
        var lastTalkButton = buttonManager.ActiveButtons[4].GetComponent<Button>();
        lastTalkButton.onClick.RemoveAllListeners();
        var talk = buttonManager.ActivePenels[(int)UI.Type.EventType.ActivePenelType.DebtTalkPenel];
        List<string> dialog = new List<string>();
        buttonManager.UndoFunction();
        buttonManager.UndoFunction();
        talk.SetActive(true);
        talk.GetComponent<Image>().DOFade(1, 0.5f);
        textManager.textCount = 0;
        talk.SetActive(true);
        if (battleSO.hp <= 0)
        {
            dialog.Add("크윽! 이 비겁한 녀석!");
            playerSO.hp = initPlayerHP;
            battleSO.hp = initEnemyHP;
        }
        if (playerSO.hp <= 0)
        {
            dialog.Add("날 무시한 대가다!");
            battleSO.hp = (int)(initEnemyHP *1.2f);
            battleSO.damage = (int)(battleSO.damage *1.7f);
            playerSO.hp = initPlayerHP;
        }
        textManager.InitDialog(dialog);
        lastTalkButton.onClick.AddListener(() =>
        {
            buttonManager.UndoFunction();
        });
        playerSO.isComeDebtCollecter = false;
    }
    private void PlayerAttack()
    {
        if (isAttackCoolTime) return;
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
        SetHpUI();
        JudgeWinAndLoose();
        StartCoroutine(AttackCoolTime());
    }
    private IEnumerator AttackCoolTime()
    {
        isAttackCoolTime = true;
        yield return new WaitForSeconds(2f);
        isAttackCoolTime = false;
    }
    public void EnemyAttack()
    {
        playerSO.hp -= battleSO.damage;
        SetHpUI();
        JudgeWinAndLoose();
    }

    private void SetHpUI()
    {
        enemyHpSlider.value = battleSO.hp;
        playerHpSlider.value = playerSO.hp;
        if (playerSO.hp <= 5)
        {
            BloodScreen.SetActive(true);
        }
    }
}
