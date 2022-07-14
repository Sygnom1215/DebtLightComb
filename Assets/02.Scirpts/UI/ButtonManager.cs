using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> activePenels = new List<GameObject>();
    public List<GameObject>ActivePenels{ get { return activePenels; } set { value = activePenels; } }
    [SerializeField]
    private List<AbstractButton> activeButtons = new List<AbstractButton>();
    public List<AbstractButton>ActiveButtons { get { return activeButtons; } set { value = activeButtons; } }
    [SerializeField]
    private TextManager textManager;
    [SerializeField]
    private PlayerSO playerSO;
    [SerializeField]
    private TMP_InputField payInputField;
    [SerializeField]
    private TMP_Text description;
    [SerializeField]
    private Text bubble;
    [SerializeField]
    private GameObject nicePanel;
    private Stack<UI.Type.EventType.ActivePenelType> activePanelStack = new Stack<UI.Type.EventType.ActivePenelType>();
    private void Awake()
    {
        InitButtons();
    }
    private void InitButtons()
    {
        foreach (AbstractButton button in activeButtons)
        {
            var obj = button.GetComponent<Button>();
            obj.onClick.AddListener(() =>
            {
                switch (button.EventType)
                {
                    case UI.Type.EventType.ButtonEventType.Undo:
                        UndoFunction();
                        break;
                    case UI.Type.EventType.ButtonEventType.Active:
                        ActiveFunction(button);
                        break;
                    case UI.Type.EventType.ButtonEventType.Exit:
                        ExitFunction();
                        break;
                    case UI.Type.EventType.ButtonEventType.EnterBrush:
                        EnterBrushFunction(button);
                        break;
                    case UI.Type.EventType.ButtonEventType.ComeDebt:
                        ComeDebtFunction(button);
                        break;
                    case UI.Type.EventType.ButtonEventType.TalkDebtCollector:
                        TalkDebtCollectorFunction();
                        break;
                    case UI.Type.EventType.ButtonEventType.VerifiNum:
                        VerifiNumFunction();
                        break;
                    default:
                        Debug.LogWarning("Didn't find Event type");
                        break;
                }
            });
        }
    }
    #region 버튼 함수들
    public void UndoFunction()
    {
        activePenels[(int)activePanelStack.Peek()].SetActive(false);
        activePanelStack.Pop();
    }
    private void ActiveFunction(AbstractButton button)
    {
        var buttonCom = button.GetComponent<ActiveButton>();
        activePenels[(int)buttonCom.activePenelType].SetActive(true);
        nicePanel.SetActive(false);
        activePenels[(int)buttonCom.activePenelType].gameObject.transform.DOShakeScale(0.2f, 0.1f);

        activePanelStack.Push(buttonCom.activePenelType);
    }
    private void ExitFunction()
    {
        Debug.Log("GameFin");
        Application.Quit();
    }
    private void EnterBrushFunction(AbstractButton button)
    {
        button.DOKill();
        var buttonRect = button.GetComponent<RectTransform>();
        buttonRect.DOAnchorPosY(-1690f, 0.5f).SetEase(Ease.OutBounce).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            ActiveFunction(button);
            button.DOKill();
        });
    }
    private void ComeDebtFunction(AbstractButton button)
    {
        if (playerSO.isComeDebtCollecter)
        {
            var lastTalkButton = activeButtons[4].GetComponent<Button>();
            lastTalkButton.onClick.RemoveAllListeners();
            lastTalkButton.onClick.AddListener(() =>
            {
                TalkDebtCollectorFunction();
            });
            ActiveFunction(button);
        }
    }
    private void TalkDebtCollectorFunction()
    {
        StartCoroutine(Talk());
    }
    private IEnumerator Talk()
    {
        var talk = activePenels[(int)UI.Type.EventType.ActivePenelType.DebtTalkPenel];
        bubble.text = "";
        talk.SetActive(true);
        List<string> dialog = new List<string>();
        dialog.Add("돈 받으러 왔다.");
        dialog.Add("벌써 잊진\n않았겠지?");
        dialog.Add("서로 좋게좋게 가자고.");
        textManager.InitDialog(dialog);
        yield return new WaitForSeconds(5f);
        description.text = $"현재 빚\n({playerSO.money * -1}골드)에서\n\n\n골드 만큼의 원금을\n상환합니다.";
        activePenels[(int)UI.Type.EventType.ActivePenelType.ChooseFight].SetActive(true);
        activePanelStack.Push(UI.Type.EventType.ActivePenelType.ChooseFight);
    }
    private void VerifiNumFunction()
    {
        long pay = long.Parse(payInputField.text);
        var lastTalkButton = activeButtons[4].GetComponent<Button>();
        lastTalkButton.onClick.RemoveAllListeners();
        var talk = activePenels[(int)UI.Type.EventType.ActivePenelType.DebtTalkPenel];
        List<string> dialog = new List<string>();
        if (pay == 0)
        {
            UndoFunction();
            UndoFunction();
            talk.SetActive(true);
            talk.GetComponent<Image>().DOFade(1, 0.5f);
            dialog.Add("나중에 배로 갚아야 할거다!");
            textManager.textCount = 0;
            textManager.InitDialog(dialog);
            playerSO.money -= 150000;
            lastTalkButton.onClick.AddListener(() =>
            {
                UndoFunction();
            });
            playerSO.isComeDebtCollecter = false;
        }
        else if (pay <= (15400000000 + playerSO.money + playerSO.paidBackMoney) && pay > 0)
        {
            playerSO.money -= pay;
            playerSO.paidBackMoney += pay;
            UndoFunction();
            UndoFunction();
            talk.SetActive(true);
            talk.GetComponent<Image>().DOFade(1, 0.5f);
            dialog.Add("좋았어! 다음에 보도록 하지.");
            textManager.textCount = 0;
            textManager.InitDialog(dialog);
            lastTalkButton.onClick.AddListener(() =>
            {
                UndoFunction();
            });
            playerSO.isComeDebtCollecter = false;
        }
        else
        {
            payInputField.text = "";
        }
    }
    #endregion

}
