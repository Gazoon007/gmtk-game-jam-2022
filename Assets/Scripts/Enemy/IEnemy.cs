namespace Enemy
{
	public interface IEnemy
	{
		public interface IWeapon
		{
			void Attack();
			void Dodge();
			void Move();
		}
	}
}