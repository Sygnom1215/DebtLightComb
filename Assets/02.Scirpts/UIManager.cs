using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    private bool isOpenMenu;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
        menuPanel.SetActive(false);

    }

    public void OpenMenu()
    {
        if (isOpenMenu == false)
        {
            menuPanel.SetActive(true);
            isOpenMenu = true;
            Time.timeScale = 0;
        }
        else if (isOpenMenu == true)
        {
            menuPanel.SetActive(false);
            isOpenMenu = false;
            Time.timeScale = 1;
        }
    }
}
