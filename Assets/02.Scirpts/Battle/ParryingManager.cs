using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ParryingManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private BattleSO battleSO;
    [SerializeField]
    private Image coolImage;
    [SerializeField]
    private Button parringButton;
    [SerializeField]
    private Image durationImage;
    [SerializeField]
    private GameObject blockObj;
    //private float initTimer = 0f;
    //private float timer = 0f;
    private void Update()
    {
        if (battleSO.isParrig)
        {
            ParryingUiSet();
        }
        if (battleSO.isParryingCool)
        {
            ParryingCoolUiSet();
        }

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("´©¸§");
        //if (battleSO.isParryingCool) return;
        coolImage.fillAmount = 0f;
        battleSO.isParrig = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("¶À");
        battleSO.isParrig = false;
        //durationImage.fillAmount = 1f;
    }

    private void ParryingCoolUiSet()
    {
        //if (coolImage.fillAmount == 1) return;
        if (coolImage.fillAmount >= 1)
        {
            blockObj.SetActive(false);
            coolImage.fillAmount = 1f;
            battleSO.isParryingCool = false;
            durationImage.fillAmount = 1f;
            return;
        }
            blockObj.SetActive(true);
            durationImage.fillAmount = 0f;
        coolImage.fillAmount += 0.0065f;
    }
    private void ParryingUiSet()
    {
        //if (battleSO.isParryingCool) return;
        if (durationImage.fillAmount <= 0)
        {
            battleSO.isParryingCool = true;
            battleSO.isParrig = false;
        }
        durationImage.fillAmount -= 0.02f;
    }
}
