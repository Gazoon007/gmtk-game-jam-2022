﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;
using Weapon.Modes;

public class PlayerScript : MonoBehaviour
{
    public bool canAttack;
    private static PlayerScript instance;
    
    private WeaponUnit _weaponUnit;

    private int _firstDicePoint;
    private int _secondDicePoint;

    public GameObject atkAndRngTradeOff;
    public GameObject highlight;
    
    public int FirstDicePoint
    {
        get => _firstDicePoint;
        set => _firstDicePoint = value;
    }

    public int SecondDicePoint
    {
        get => _secondDicePoint;
        set => _secondDicePoint = value;
    }

    public static PlayerScript GetInstance()
    {
        return instance;
    }
    
    private void OnEnable()
    {
        Dice.OnRolledFirstDice += OnRolledFirstDice;
        Dice.OnRolledSecondDice += OnRolledSecondDice;
        GameManager.OnTradedValue += OnTradedValue;
    }

    private void OnRolledFirstDice(int point)
    {
        _firstDicePoint = point;
    }

    private void OnRolledSecondDice(int point)
    {
        _secondDicePoint = point;
        highlight.SetActive(true);
        highlight.transform.position = new Vector3(point * 10f, highlight.transform.position.y, highlight.transform.position.z);
        atkAndRngTradeOff.SetActive(true);

        var selectedWeapon = WeaponManager.GetInstance().selectedWeapon;
        if (selectedWeapon.maxRangeValue < _firstDicePoint + _secondDicePoint)
        {
            Debug.Log("Reach MAX Limit, PENALTY!");
            canAttack = false;
            atkAndRngTradeOff.SetActive(false);
            highlight.gameObject.GetComponent<Collider2D>().enabled = true;
            highlight.SetActive(false);
            highlight.transform.position = new Vector3(0f, highlight.transform.position.y, highlight.transform.position.z);
            
            LeanTween.delayedCall(1f, () =>
            {
                GameManager.GetInstance().EndTurnButton();
            });
            LeanTween.delayedCall(2f, () =>
            {
                GameManager.GetInstance().EndTurnButton();
                canAttack = true;
            });
        }
    }

    private void OnDisable()
    {
        Dice.OnRolledFirstDice -= OnRolledFirstDice;
        Dice.OnRolledSecondDice -= OnRolledSecondDice;
        GameManager.OnTradedValue -= OnTradedValue;
    }

    private void OnTradedValue(int first, int second)
    {
        OnRolledFirstDice(first);
        OnRolledSecondDice(second);
        highlight.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    public int TryAttack()
    {
        if (canAttack)
        {
            var damage = _firstDicePoint;
            canAttack = false;
            atkAndRngTradeOff.SetActive(false);
            
            highlight.gameObject.GetComponent<Collider2D>().enabled = true;
            highlight.SetActive(false);
            highlight.transform.position = new Vector3(0f, highlight.transform.position.y, highlight.transform.position.z);
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
