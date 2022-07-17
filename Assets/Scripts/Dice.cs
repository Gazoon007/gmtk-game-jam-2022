using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    private int totalRoll;

    private int firstDiceSides;
    private int secondDiceSides;

    public List<int> diceList;
    public List<Sprite> diceSpriteList;

    public static Action<int> OnRolledFirstDice;
    public static Action<int> OnRolledSecondDice;

    public void SelectFirstDice(int diceNumber)
    {
        firstDiceSides = diceList[diceNumber];
    }

    public void SelectSecondDice(int diceNumber)
    {
        secondDiceSides = diceList[diceNumber];
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

    public Sprite GetSprite(int diceNumber)
    {
        return diceSpriteList[diceNumber];
    }
}

