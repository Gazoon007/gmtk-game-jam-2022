using UnityEngine;

public class Dice
{
	[SerializeField] private const int Sides = 6;

	public int RollADice()
	{
		return Random.Range(1, Sides);
	}
}