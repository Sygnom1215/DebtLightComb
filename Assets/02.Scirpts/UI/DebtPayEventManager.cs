using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebtPayEventManager : MonoBehaviour
{
    [SerializeField]
    private PlayerSO playerSO;
    private void Start()
    {
        StartCoroutine(DebtCome());
    }
    public IEnumerator DebtCome()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(60f, 120f));
            Debug.Log("Debt collecter is comming");
            playerSO.isComeDebtCollecter = true;
        }
    }
}
