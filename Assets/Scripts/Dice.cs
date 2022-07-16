using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
	private int firstDiceSides;
	private int secondDiceSides;

	public static Action<int> OnRolledFirstDice;
	public static Action<int> OnRolledSecondDice;

	public void SelectFirstDice(int sides)
	{
		firstDiceSides = sides;
	}

	public void SelectSecondDice(int dices)
	{
		secondDiceSides = dices;
	}
	
	public void RollFirstDice()
	{
		var result = Random.Range(1, firstDiceSides);
		Debug.Log("First Dice " + result);
		OnRolledFirstDice?.Invoke(result);
	}

	public void RollSecondDice()
	{
		var result = Random.Range(1, secondDiceSides);
		Debug.Log("Second Dice " + result);
		OnRolledSecondDice?.Invoke(result);
	}
}