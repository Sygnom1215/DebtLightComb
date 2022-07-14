using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Type;

public class DebtPayEventManager : MonoBehaviour
{
    [SerializeField]
    private PlayerSO playerSO;
    [SerializeField]
    private Sound sound;
    private void Start()
    {
        StartCoroutine(DebtCome());
    }
    public IEnumerator DebtCome()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 20f));
            Debug.Log("Debt collecter is comming");
            sound.PlayEff(EffType.Knok);
            playerSO.isComeDebtCollecter = true;
        }
    }
}
