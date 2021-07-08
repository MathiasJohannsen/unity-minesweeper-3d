using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage()
    {
        health--;
        if (health > 0)
        {
            gameObject.GetComponent<UIManager>().UpdateText();
        }
        else Die();
    }

    void Die()
    {
        gameObject.GetComponent<UIManager>().ShowDeathScreen();
    }
}
