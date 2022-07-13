using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narrative : MonoBehaviour
{
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text narrateText;

    private List<string> dialogs = new List<string>();

    private IEnumerator Start()
    {
        titleText.DOText("õ������ �� 1�� \n", 5f);
        yield return new WaitForSeconds(1f);
        StartTalk();
    }

    private void StartTalk()
    {

        narrateText.DOText("���ʿ� â������ õ���� â���Ͻô϶�.\n\n���� ȥ���ϰ� �����ϸ� ����� ���� ���� �ְ�,\n\nâ������ ���� ���� ���� �����Ͻô�,\n\n" +
            "â������ �̸��õ� ���� ������ �Ͻô� ���� �־���,\n\nâ������ �̸��õ� ���� ������ �Ͻô� ���� �־���,\n\nâ������ �̸��õ� ���� ������ �Ͻô� ���� " +
            "�־���\n\n����?\n\n��ž �� ������, �� �����簡 ���� ���.\n\n���ϡ�..���� ��¼�� �̷��� �Ȱ���������.��\n\n\n\n���� �ְ��� ������,\n\n154�� ����� ���� ���� " +
            "��ž�� �������� ������.\n\n���� ���� �����顦���ٽ� ��ž�ְ� �� �� �־\n\n��ž�� �ֻ���, ��ž���� �ڸ��� ���� ������\n\n���� �Ⱦ� ���� ���� ���� ��ã��.", 35f);
        
    }
}
