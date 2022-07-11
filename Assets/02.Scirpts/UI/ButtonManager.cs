using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> activePenels = new List<GameObject>();
    [SerializeField]
    private List<ActiveButton> activeButtons = new List<ActiveButton>();
    private Stack<UI.Type.EventType.ActivePenelType> activePanelStack = new Stack<UI.Type.EventType.ActivePenelType>();

    private void Awake()
    {
        SetActiveButtons();
    }
    private void SetActiveButtons()
    {
        foreach (ActiveButton button in activeButtons)
        {
            var obj = button.GetComponent<Button>();
            obj.onClick.AddListener(() =>
            {
                if (button.EventType == UI.Type.EventType.ButtonEventType.Active)
                {
                    activePenels[(int)button.activePenelType].SetActive(true);
                    activePenels[(int)button.activePenelType].gameObject.transform.DOShakeScale(0.2f,0.1f);
                    
                    activePanelStack.Push(button.activePenelType);
                }
                else
                {
                    activePenels[(int)activePanelStack.Peek()].SetActive(false);
                    activePanelStack.Pop();
                }
            });

        }
    }
}
