using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObject/Player/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    //���� �������� money + paidBackMoney
    public long money = -15400000000;
    public long paidBackMoney = 0;
    public sbyte tower = -50;
}