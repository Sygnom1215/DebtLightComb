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
    [SerializeField]
    private List<AbstractButton> activeButtons = new List<AbstractButton>();
    [SerializeField]
    private TextManager textManager;
    [SerializeField]
    private PlayerSO playerSO;
    [SerializeField]
    private TMP_InputField payInputField;
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
    private void RemoveAllPenel()
    {
        while (activePanelStack.Count != 0)
        {
            UndoFunction();
        }
    }
    #region ��ư �Լ���
    private void UndoFunction()
    {
        activePenels[(int)activePanelStack.Peek()].SetActive(false);
        activePanelStack.Pop();
    }
    private void ActiveFunction(AbstractButton button)
    {
        var buttonCom = button.GetComponent<ActiveButton>();
        activePenels[(int)buttonCom.activePenelType].SetActive(true);
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
    private void TalkDebtCollectorFunction()
    {
        StartCoroutine(Talk());
    }
    private IEnumerator Talk()
    {
        var talk = activePenels[(int)UI.Type.EventType.ActivePenelType.DebtTalkPenel];
        talk.SetActive(true);
        List<string> dialog = new List<string>();
        dialog.Add("�� ������ �Դ�");
        dialog.Add("�׻� ������ �ƴϰ���?");
        dialog.Add("���� �������� �����ڰ�");
        textManager.InitDialog(dialog);
        yield return new WaitForSeconds(5f);
        activePenels[(int)UI.Type.EventType.ActivePenelType.ChooseFight].SetActive(true);

    }
    private void VerifiNumFunction()
    {
        int pay = int.Parse(payInputField.text);
        if (pay <= playerSO.money * -1 || pay > 0)
        {
            playerSO.money += pay;
            RemoveAllPenel();
        }
        else if (pay == 0)
        {
            List<string> dialog = new List<string>();
            dialog.Add("���� ���� �峭�ϴ°ž�?");
            dialog.Add("�� ���� ���߿� �״�� ���ƾ� �ҰŴ�!");
            textManager.InitDialog(dialog);
            playerSO.money -= 150000;
            RemoveAllPenel();
        }
        else
        {
            payInputField.text = "";
        }
    }
    #endregion
}
