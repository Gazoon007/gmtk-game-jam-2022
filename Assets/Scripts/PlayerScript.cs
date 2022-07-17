using System;
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
    WeaponData selectedWeapon;

    public List<Sprite> weaponSprites;

    private int _firstDicePoint;
    private int _secondDicePoint;

    public GameObject atkAndRngTradeOff;
    public GameObject highlight;
    public GameObject projectile;
    
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

        selectedWeapon = WeaponManager.GetInstance().selectedWeapon;
        if (selectedWeapon.maxRangeValue < _firstDicePoint + _secondDicePoint)
        {
            Debug.Log("Reach MAX Limit, PENALTY!");
            canAttack = false;
            atkAndRngTradeOff.SetActive(false);
            highlight.gameObject.GetComponent<Collider2D>().enabled = true;
            highlight.SetActive(false);
            highlight.transform.position = new Vector3(0f, highlight.transform.position.y, highlight.transform.position.z);
            
            LeanTween.delayedCall(2f, () =>
            {
                GameManager.GetInstance().EndTurnButton();
            });
            LeanTween.delayedCall(3f, () =>
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

    public void LaunchProjectile()
    {
        var projectileIns = Instantiate(projectile, gameObject.transform);
        projectileIns.transform.localPosition = new Vector3(0, 0, 0);

        if(selectedWeapon.name=="Crossbow")
        {
            projectileIns.GetComponent<SpriteRenderer>().sprite = weaponSprites[0];
        }
        else if (selectedWeapon.name == "Spear")
        {
            projectileIns.GetComponent<SpriteRenderer>().sprite = weaponSprites[1];
        }
        else if (selectedWeapon.name == "Throwing Axe")
        {
            projectileIns.GetComponent<SpriteRenderer>().sprite = weaponSprites[2];
        }

        LeanTween.move(projectileIns, highlight.gameObject.transform.position, 1f);
        LeanTween.delayedCall(1f, () =>
        {
            Destroy(projectileIns);
        });
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
            LeanTween.delayedCall(2f, () =>
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
