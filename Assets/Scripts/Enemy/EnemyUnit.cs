using UnityEngine;
using Weapon;

namespace Enemy
{
	[CreateAssetMenu(menuName = "CustomData/Enemy")]
	public class EnemyUnit : EnemyData
	{
		public override void Attack()
		{
			Debug.Log("Enemy Attack " + attackValue);
		}

		public override void Hit(int damage, EnemyScript enemy)
		{
			Debug.Log("Enemy Hit " + damage);
			var randVal = Random.Range(1, 100);
			if (randVal <= dodgeChance)
			{
				if (enemy.dodgedText)
				{
					enemy.dodgedText.SetActive(true);
					LeanTween.delayedCall(3f, () =>
					{
						enemy.dodgedText.SetActive(false);
					});
				}
				Debug.Log("Enemy Dodge");
				return;
			}
			
			enemy.CurrentHealth -= damage;
			if (enemy.CurrentHealth <= 0)
			{
				GameManager.GetInstance().EndTurn -= enemy.EnemyMovement_EndTurn;
				enemy.CurrentHealth = 0;
				LeanTween.delayedCall(1f, () =>
				{
					Destroy(enemy.gameObject);
				});
			}
			else
			{
				LeanTween.delayedCall(1f, () =>
				{
					enemy.healthSlider.value = enemy.CurrentHealth;
					Debug.Log("Current Health " + health);
				});
			}

		}

		public override void Move()
		{
			Debug.Log("Enemy Move " + moveSpeed);
		}
	}
}