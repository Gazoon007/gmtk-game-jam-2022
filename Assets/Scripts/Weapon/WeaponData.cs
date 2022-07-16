using UnityEngine;

namespace Weapon
{
	public abstract class WeaponData : ScriptableObject, IWeapon
	{
		public int maxRangeValue;

		public abstract void Fire();
	}
}