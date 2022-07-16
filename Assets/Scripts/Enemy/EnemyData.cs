using UnityEngine;

namespace Enemy
{
	public abstract class EnemyData : ScriptableObject, IEnemy
	{
		public float dodgeChance;
		public int attackValue;
		public int moveSpeed;
		public int health;

		public abstract void Attack();
		public abstract void Hit(int damage, EnemyScript enemy);
		public abstract void Move();
		public abstract void Dodge();
	}
}