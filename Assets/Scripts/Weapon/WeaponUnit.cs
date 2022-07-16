using System.Runtime.CompilerServices;
using UnityEngine;

namespace Weapon.Modes
{
	[CreateAssetMenu(menuName = "CustomData/Weapon")]
	public class WeaponUnit : WeaponData
	{
		public override void Fire()
		{
			Debug.Log("Player Fire " + damageValue);
			Debug.Log("With Range " + rangeValue);
		}
	}
}