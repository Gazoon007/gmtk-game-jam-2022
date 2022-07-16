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

		public override void Move()
		{
			Debug.Log("Enemy Move " + moveSpeed);
		}

		public override void Dodge()
		{
			var randVal = Random.Range(0, 100);
			if (randVal <= dodgeChance)
				Debug.Log("Enemy Dodge");
		}
	}
}