using UnityEngine;

namespace Weapon
{
	public abstract class WeaponData : ScriptableObject, IWeapon
	{
		public int rangeValue;
		public int damageValue;

		public abstract void Fire();
	}
}