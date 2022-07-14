using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private PlayerSO playerSO;
    [SerializeField]
    private TMP_Text haveMoneyText; // ��
    [SerializeField]
    private TMP_Text giveMoneyText; // ���� ��


    private void Update()
    {
        TextSet();
    }
    private void TextSet()
    {
        haveMoneyText.text = $"���� ������ {playerSO.money}���";
        giveMoneyText.text = $"���� �� {playerSO.paidBackMoney}���";
    }
}
