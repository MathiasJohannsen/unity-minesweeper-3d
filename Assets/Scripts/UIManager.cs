using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text healthText;

    public void UpdateText()
    {
        healthText.text = gameObject.GetComponent<HealthManager>().health + "";
    }

    public void ShowDeathScreen()
    {
        healthText.text = "You're dead";
    }
}
