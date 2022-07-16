namespace Enemy
{
	public interface IEnemy
	{
		public interface IWeapon
		{
			void Attack();
			void Hit(int damage, EnemyScript enemy);
			void Dodge();
			void Move();
		}
	}
}