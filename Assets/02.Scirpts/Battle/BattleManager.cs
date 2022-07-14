using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private BattleSO battleSO;
    [SerializeField]
    private PlayerSO playerSO;
    [SerializeField]
    private Transform cameraTransform;
    private void PlayerAttack()
    {
        battleSO.hp -= playerSO.damage;
        cameraTransform.DOShakePosition(0.3f, 0.1f);
    }
}
