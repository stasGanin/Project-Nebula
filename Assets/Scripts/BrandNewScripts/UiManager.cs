using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public PlayerShipsManager playerShipsManager;
    public EnemyManager enemyManager;
    public GameManager gameManager;
    public Image PlayerHealthBar;
    public Image EnemyHealthBar;
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI enemyHP;
    public TextMeshProUGUI playerMoney;
    public TextMeshProUGUI playerDamage;
    public GameObject upgradeMenuCanvas;
    public GameObject shopMenuCanvas;
    public GameObject scoutMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {

            ToggleUppgradeMenu();


        }
        UpdatePlayerDamage();
        UpdatePlayerMoney();
        UpdatePlayerHpGUI();
        UpdateEnemyHpGUI();
        UpdateHealthBar(PlayerHealthBar, playerShipsManager.CalculatePlayerCurrentHp(), playerShipsManager.CalculatePlayerTotalHp());
        UpdateHealthBar(EnemyHealthBar, enemyManager.EnemyHP, enemyManager.CalculateEnemyHp());
    }

    public void UpdateHealthBar(Image HealthBar, float currentHealth, float maxHealth)
    {
        HealthBar.fillAmount = currentHealth / maxHealth;
    }

    public void UpdatePlayerHpGUI()
    {
        if (playerHP != null)
        {
            playerHP.text = $"{playerShipsManager.CalculatePlayerCurrentHp()} / {playerShipsManager.CalculatePlayerTotalHp()}";
        }
    }

    public void UpdateEnemyHpGUI()
    {
        if (enemyHP != null)
        {
            enemyHP.text = $"{enemyManager.EnemyHP} / {enemyManager.CalculateEnemyHp()}";
        }
    }

    public void UpdatePlayerMoney()
    {
        if (playerMoney != null)
        {
            playerMoney.text = $"{gameManager.PlayerMoney}";
        }
    }

    public void UpdatePlayerDamage()
    {
        if (playerDamage != null)
        {
            playerDamage.text = $"{playerShipsManager.CalculateOverallPlayerDamage()}";
        }
    }


    public void ToggleUppgradeMenu()
    {
        if (!upgradeMenuCanvas.activeSelf)
        {
            upgradeMenuCanvas.SetActive(true);
        } else if (upgradeMenuCanvas.activeSelf)
        {
            upgradeMenuCanvas.SetActive(false);
        }
        
    }

    public void ToggleShopMenu()
    {
        if (!shopMenuCanvas.activeSelf)
        {
            shopMenuCanvas.SetActive(true);
        }
        else if (shopMenuCanvas.activeSelf)
        {
            shopMenuCanvas.SetActive(false);
        }
    }

    public void ToggleScoutMenuMenu()
    {
        if (!scoutMenuCanvas.activeSelf)
        {
            scoutMenuCanvas.SetActive(true);
        }
        else if (scoutMenuCanvas.activeSelf)
        {
            scoutMenuCanvas.SetActive(false);
        }
    }
}