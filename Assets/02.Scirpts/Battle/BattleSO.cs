using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleSO", menuName = "ScriptableObject/Battle/BattleSO")]
public class BattleSO : ScriptableObject
{
    public bool isParryingCool = false;
    public bool isParrig = false;
    public int hp = 20;
    public int damage = 5;
}
