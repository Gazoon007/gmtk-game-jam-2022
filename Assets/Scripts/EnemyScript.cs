using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using UnityEngine.UI;
using Weapon;

public class EnemyScript : MonoBehaviour
{
	private float _maxHealth;
	private float _currentHealth;

	public float CurrentHealth
	{
		get => _currentHealth;
		set => _currentHealth = value;
	}

	public Slider healthSlider;
	[SerializeField] EnemyData enemyData;

	private void Start()
	{
		_maxHealth = enemyData.health;
		GameManager.GetInstance().EndTurn += EnemyMovement_EndTurn;

		healthSlider.maxValue = _maxHealth;
		_currentHealth = _maxHealth;
		healthSlider.value = _currentHealth;
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
		var damage = PlayerScript.GetInstance().TryAttack();
		enemyData.Hit(damage, this);
	}

	public void EnemyMovement_EndTurn(object sender, System.EventArgs e)
	{
		Vector3 currentpos = transform.position;
		currentpos.x -= 10f * enemyData.moveSpeed;
		transform.position = currentpos;
		//throw new System.NotImplementedException();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Tower")
		{
			GameManager.GetInstance().EndTurn -= EnemyMovement_EndTurn;
			collision.GetComponent<TowerScript>().TakeDamage(10f);
			Destroy(gameObject);
			Debug.Log("Damaging Tower");
		}
	}
}