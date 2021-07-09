using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject Player;
    public TMP_Text healthText;
    public GameObject[] hideOnDie;
    public GameObject[] showOnDie;

    private void Start()
    {
        foreach (GameObject item in showOnDie)
        {
            item.SetActive(false);
        }
    }

    public void UpdateText()
    {
        healthText.text = gameObject.GetComponent<HealthManager>().health + "";
    }

    public void ShowDeathScreen()
    {
        foreach (GameObject item in hideOnDie)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in showOnDie)
        {
            item.SetActive(true);
        }
        Destroy(Player.GetComponent<FPSController>());
        Destroy(Player.GetComponent<ClickManager>());
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.01f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
