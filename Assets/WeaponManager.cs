using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Weapon;

public class WeaponManager : MonoBehaviour
{
    private float _maxRange;

    private WeaponData selectedWeapon;

    public TextMeshProUGUI weaponText;

    private int swapsAllowed;

    [SerializeField] WeaponData[] weaponData;
    
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
        Debug.Log(result);
        SelectWeapon(result);
    }
}
