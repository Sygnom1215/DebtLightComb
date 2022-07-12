using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MiniGameManager : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    [SerializeField]
    private MiniGameSO miniGameSO;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        miniGameSO.isComb = true;
        throw new System.NotImplementedException();
    }
    
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        miniGameSO.isComb = false;
        throw new System.NotImplementedException();
    }
}
