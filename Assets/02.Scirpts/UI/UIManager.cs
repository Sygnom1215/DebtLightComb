using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private PlayerSO playerSO;
    [SerializeField]
    private TMP_Text haveMoneyText; // ºú
    [SerializeField]
    private TMP_Text giveMoneyText; // °±Àº µ·


    private void Update()
    {
        TextSet();
    }
    private void TextSet()
    {
        haveMoneyText.text = $"ÇöÀç ¼ÒÁö±Ý {playerSO.money}°ñµå";
        giveMoneyText.text = $"°ªÀº ºú {playerSO.paidBackMoney}°ñµå";
    }
}
