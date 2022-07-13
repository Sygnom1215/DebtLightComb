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
    //private float initTimer = 0f;
    //private float timer = 0f;
    private IEnumerator CoolTime()
    {
        battleSO.isParryingCool = true;
        yield return new WaitForSeconds(5f);
        battleSO.isParryingCool = false;
        durationImage.fillAmount = 1f;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("´©¸§");
        if (battleSO.isParryingCool) return;
        battleSO.isParrig = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("¶À");
        if (battleSO.isParryingCool) return;
        battleSO.isParrig = false;
    }

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
    private void ParryingCoolUiSet()
    {
        if (durationImage.fillAmount <= 0)
        {
            coolImage.fillAmount = 0f;
        }
        coolImage.fillAmount -= 0.00333333333f;
    }
    private void ParryingUiSet()
    {
        if (battleSO.isParryingCool) return;
        if (durationImage.fillAmount <= 0)
        {
            StartCoroutine(CoolTime());
        }
        durationImage.fillAmount -= 0.05f;

    }
}
