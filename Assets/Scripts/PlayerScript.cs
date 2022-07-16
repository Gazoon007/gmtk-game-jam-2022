using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon.Modes;

public class PlayerScript : MonoBehaviour
{
    public bool canAttack;
    private static PlayerScript instance;
    
    private WeaponUnit _weaponUnit;
    private int firstDicePoint;
    private int secondDicePoint;
    
    public static PlayerScript GetInstance()
    {
        return instance;
    }
    
    private void OnEnable()
    {
        Dice.OnRolledFirstDice += OnRolledFirstDice;
        Dice.OnRolledSecondDice += OnRolledSecondDice;
    }

    private void OnRolledFirstDice(int point)
    {
        // Temporary only for range, cannot alter yet (trade to attack)
        firstDicePoint = point;
    }

    private void OnRolledSecondDice(int point)
    {
        // Temporary only for attack, cannot alter yet (trade to range)
        secondDicePoint = point;
    }

    private void OnDisable()
    {
        Dice.OnRolledFirstDice -= OnRolledFirstDice;
        Dice.OnRolledSecondDice -= OnRolledSecondDice;
    }

    public int TryAttack()
    {
        if (canAttack)
        {
            var damage = firstDicePoint;
            canAttack = false;
            LeanTween.delayedCall(1f, () =>
            {
                GameManager.GetInstance().EndTurnButton();
                canAttack = true;
            });
            return damage;
        }
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
