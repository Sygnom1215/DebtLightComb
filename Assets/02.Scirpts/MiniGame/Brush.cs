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
    private float dragTime = 0f;

    private void JudgeDrag()
    {
        if (dragTime >= maxDragTime)
        {

        }
        else if (dragTime <= minDragTime)
        {


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
        
        if (results.Count==1)
            miniGameSO.isComb = true;
        if (miniGameSO.isComb)
        {
            dragTime+= 0.1f;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(dragTime);
        JudgeDrag();
        miniGameSO.isComb = false;
        dragTime = 0;
        RectTransform rec = GetComponent<RectTransform>();
        rec.DOScale(1, 0.5f).SetEase(Ease.InOutBack);
        rec.DOAnchorPos(backTransform.position,0.5f);
    }
}
