using System;
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
	private bool isColided;
	private UI_Manager UI_Manager;

	private int enemyCount;

	public int EnemyCount
	{
		get => enemyCount;
		set => enemyCount = value;
	}

	public float CurrentHealth
	{
		get => _currentHealth;
		set => _currentHealth = value;
	}

	public GameObject dodgedText;
	public Slider healthSlider;
	[SerializeField] EnemyData enemyData;
	private void Start()
	{
		_maxHealth = enemyData.health;
		GameManager.GetInstance().EndTurn += EnemyMovement_EndTurn;

		gameObject.GetComponent<Animator>().enabled = false;

		healthSlider.maxValue = _maxHealth;
		_currentHealth = _maxHealth;
		healthSlider.value = _currentHealth;
		
		CheckEnemies();
		
		UI_Manager = GameObject.Find("New UI").GetComponent<UI_Manager>();
	}

	private void OnEnable()
	{
		GameManager.OnTradedValue += OnChangedAtkRngValue;
	}

	private void OnChangedAtkRngValue(int arg1, int arg2)
	{
		isColided = false;
	}

	private void OnDisable()
	{
		GameManager.OnTradedValue -= OnChangedAtkRngValue;
	}

	private void OnMouseExit()
	{
		if (isColided)
			transform.localScale = new Vector3(1, 1, 1);
	}
	
	private void OnMouseEnter()
	{
		if (isColided)
		{
			transform.localScale = new Vector3(1.2f, 1.2f, 1);
		}
	}

	private void OnMouseDown()
	{
		if (isColided)
		{
			PlayerScript.GetInstance().LaunchProjectile();
			var damage = PlayerScript.GetInstance().TryAttack();
			enemyData.Hit(damage, this);
			isColided = false;
		}
	}

	public void EnemyMovement_EndTurn(object sender, System.EventArgs e)
	{
		gameObject.GetComponent<Animator>().enabled = true;
		LeanTween.moveX(gameObject, gameObject.transform.position.x - 10f, 1f);
		LeanTween.delayedCall(1f, () =>
		{
			gameObject.GetComponent<Animator>().enabled = false;
		});
		PlayerScript.GetInstance().EmptyTheQuantumPoint();
	}

	public void CheckEnemies()
	{
		var arrayOfEnemyScript = FindObjectsOfType<EnemyScript>();
		enemyCount = arrayOfEnemyScript.Length;
		Debug.Log(enemyCount);

		if (enemyCount == 0)
		{
			UI_Manager.YouWon();
			Debug.Log("You WON!");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "highlight")
		{
			isColided = true;
			collision.gameObject.GetComponent<Collider2D>().enabled = false;
		}
		
		if (collision.tag == "Tower")
		{
			GameManager.GetInstance().EndTurn -= EnemyMovement_EndTurn;
			collision.GetComponent<TowerScript>().TakeDamage(10f);
			Destroy(gameObject);
			Debug.Log("Damaging Tower");
		}
	}
}