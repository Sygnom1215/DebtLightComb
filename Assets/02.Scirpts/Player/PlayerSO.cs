using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObject/Player/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    //실제 소지금은 money + paidBackMoney
    public long money = -15400000000;
    public long paidBackMoney = 0;
    public sbyte tower = -50;
    public bool isComeDebtCollecter = false;
    public int hp = 15;
    public int damage = 4;
}
