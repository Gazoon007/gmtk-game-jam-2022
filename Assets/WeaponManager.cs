using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Weapon;
using Random = UnityEngine.Random;

public class WeaponManager : MonoBehaviour
{
    private float _maxRange;
    private static WeaponManager instance;

    public WeaponData selectedWeapon;

    public TextMeshProUGUI weaponText;

    private int swapsAllowed;

    [SerializeField] WeaponData[] weaponData;

    public static WeaponManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        instance = this;
    }

    public void SelectWeapon(int weaponNumber)
    {
        selectedWeapon = weaponData[weaponNumber];
        _maxRange = selectedWeapon.maxRangeValue;
        Debug.Log("selected weapon " + selectedWeapon.name);
        weaponText.text = "Current Weapon: " + selectedWeapon.name;
    }

    public void RollWeaponDice()
    {
        var result = Random.Range(0, weaponData.Length);
        SelectWeapon(result);
    }
}
