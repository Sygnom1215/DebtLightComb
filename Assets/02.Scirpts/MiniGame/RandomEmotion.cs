using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEmotion : MonoBehaviour
{
    [SerializeField]
    private Image image = null;
    [SerializeField]
    private Sprite[] sprite = null;
    [SerializeField]
    private BattleSO battleSO;
    [SerializeField]
    private BattleManager battleManager;
    private int condition; // 0~10    0~5 : GOOD    6~8 : BAD   10 : MAD 
    private float randomDelay;

    [SerializeField]
    private bool isFight = false;
    private void Start()
    {
        image.sprite = sprite[2];
        StartCoroutine(Condition());
    }

    private IEnumerator Condition()
    {
        while (true)
        {
            int changeNum = 0;
            if (isFight)
                changeNum = Random.Range(-5, 5);
            else
                changeNum = Random.Range(-5, 5);
            if (changeNum == 0)
                changeNum = 1;

            condition += changeNum;

            if (condition < 0)
                condition = 0;
            else if (condition > 10)
                condition = 10;


            if (condition == 10)
            {
                image.sprite = sprite[0];
                if (isFight)
                    randomDelay = Random.Range(0.2f, 0.3f);
            }
            else if (condition >= 6)
            {
                image.sprite = sprite[1];
                if (isFight)
                    randomDelay = Random.Range(0.4f, 0.6f);
            }
            else if (condition >= 0)
            {
                image.sprite = sprite[2];
                if (isFight)
                    randomDelay = Random.Range(0.3f, 0.6f);
            }
            if (!isFight)
                randomDelay = Random.Range(0.1f, 0.7f);

            yield return new WaitForSeconds(randomDelay);
            if (condition == 10 && isFight)
            {
                if (battleSO.isParrig)
                {
                    Time.timeScale = 0.8f;
                    //È¿°úÀ½
                    battleSO.hp -= 6;
                    yield return new WaitForSeconds(0.1f);
                    Time.timeScale = 1f;
                }
                else
                {
                    battleManager.EnemyAttack();
                }
                yield return new WaitForSeconds(0.1f);
            }
        }


    }
}
