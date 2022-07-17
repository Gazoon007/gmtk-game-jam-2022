using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Slider healthSlider;

    private UI_Manager UI_Manager;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Game Over");

            UI_Manager.YouLost();
        }
        healthSlider.value = currentHealth;
    }

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;

        UI_Manager = GameObject.Find("New UI").GetComponent<UI_Manager>();
    }
}
