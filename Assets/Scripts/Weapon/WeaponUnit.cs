using System.Runtime.CompilerServices;
using UnityEngine;

namespace Weapon.Modes
{
	[CreateAssetMenu(menuName = "CustomData/Weapon")]
	public class WeaponUnit : WeaponData
	{
		public override void Fire()
		{
			Debug.Log("Fired With Max Range " + maxRangeValue);
		}
	}
}