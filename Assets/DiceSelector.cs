using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceSelector : MonoBehaviour
{
    List<bool> selectedDice;

    public Image dice1Sprite;
    int selectedDice1;
    int selectedDice2;
    public Image dice2Sprite;

    [SerializeField] Dice dice;

    private void Start()
    {
        
      
        dice1Sprite.sprite = dice.GetSprite(0);
        dice2Sprite.sprite = dice.GetSprite(1);

        selectedDice1 = 0;
        selectedDice2 = 1;
    }

    void NewTurn()
    {

    }

    public void RollDice()
    {
        dice.SelectFirstDice(selectedDice1);
        dice.SelectSecondDice(selectedDice2);

        dice.RollFirstDice();
        dice.RollSecondDice();
    }

    public void NextDice(bool isFirstDice)
    {
        if (isFirstDice)
        {
            if ((selectedDice1 + 1) % 3 == selectedDice2)
            {
                selectedDice1 = (selectedDice1 + 2) % 3;
            }
            else
                selectedDice1 = (selectedDice1 + 1) % 3;
            dice1Sprite.sprite = dice.GetSprite(selectedDice1);
        }
        else
        {
            if ((selectedDice2 + 1) % 3 == selectedDice1)
            {
                selectedDice2 = (selectedDice2 + 2) % 3;
            }
            else
                selectedDice2 = (selectedDice2 + 1) % 3;
            dice2Sprite.sprite = dice.GetSprite(selectedDice2);
        }
    }

    public void PreviousDice(bool isFirstDice)
    {

    }
}
