using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float maxHealth=10f;
     float currentHealth;

    public Slider healthSlider;


    private void Start()
    {
        GameManager.GetInstance().EndTurn += EnemyMovement_EndTurn;
        
        healthSlider.maxValue = maxHealth;
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1);    
    }

    private void OnMouseDown()
    {
        float damage=PlayerScript.GetInstance().TryAttack();
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GameManager.GetInstance().EndTurn -= EnemyMovement_EndTurn;
            currentHealth = 0;
            Destroy(gameObject);
        }
        healthSlider.value = currentHealth;
    }

    private void Awake()
    {
        
    }
    private void EnemyMovement_EndTurn(object sender, System.EventArgs e)
    {
        Vector3 currentpos = transform.position;
        currentpos.x -= 10f;
        transform.position = currentpos;
        //throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Tower")
        {
            GameManager.GetInstance().EndTurn -= EnemyMovement_EndTurn;
            collision.GetComponent<TowerScript>().TakeDamage(10f);
            Destroy(gameObject);
            Debug.Log("Damaging Tower");
        }
    }
}
