using UnityEngine;

namespace Enemy
{
	public abstract class EnemyData : ScriptableObject, IEnemy
	{
		public float dodgeChance;
		public int attackValue;
		public int moveSpeed;

		public abstract void Attack();
		public abstract void Move();
		public abstract void Dodge();
	}
}