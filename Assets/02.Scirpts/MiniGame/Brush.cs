using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class Brush : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    [SerializeField]
    private float maxDragTime = 0;
    [SerializeField]
    private float minDragTime = 0;
    [SerializeField]
    private MiniGameSO miniGameSO;
    [SerializeField]
    private Transform backTransform;
    [SerializeField]
    private Sound sound;
    [SerializeField]
    private PlayerSO playerSO;
    private float dragTime = 0f;
    private float totalTime = 0f;

    [SerializeField]
    private GameObject stisPanel;

    private void Start()
    {
        stisPanel.SetActive(false);
        sound.PlayBgm(UI.Type.BgmType.CutPadol);
    }
    private void Update()
    {
        JudgeDrag();
    }

    private void JudgeDrag()
    {
        //if (dragTime >= maxDragTime)
        //{

        //}
        //else if (dragTime <= minDragTime) // 한 번 드레그 할 때 걸린 시간
        //{


        //}
        if (totalTime >= 5f)
        {
            stisPanel.SetActive(true);
            sound.PlayBgm(UI.Type.BgmType.MainThema);
            playerSO.money += 50000;
            playerSO.tower++;
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        RectTransform rec = GetComponent<RectTransform>();
        rec.DOScale(0.6f, 1f).SetEase(Ease.OutExpo);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        GetComponent<GraphicRaycaster>().Raycast(eventData, results);

        if (results.Count == 1)
            miniGameSO.isComb = true;
        if (miniGameSO.isComb)
        {
            dragTime += 0.1f;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(dragTime);
        miniGameSO.isComb = false;
        totalTime += dragTime;
        JudgeDrag();
        dragTime = 0;
        RectTransform rec = GetComponent<RectTransform>();
        rec.DOScale(1, 0.5f).SetEase(Ease.InOutBack);
        rec.DOAnchorPos(backTransform.position, 0.5f);

    }
}
