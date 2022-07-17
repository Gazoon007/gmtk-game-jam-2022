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

    public UI_Manager UI_Manager;

    public TextMeshProUGUI weaponText;

    public Image currentWeaponSprite;
    public List<Sprite> weaponSprites;

    private int swapsAllowed;

    private int currentWeapon;

    [SerializeField] WeaponData[] weaponData;

    public static WeaponManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        instance = this;

        UI_Manager = GameObject.Find("New UI").GetComponent<UI_Manager>();
    }

    public void SelectWeapon(int weaponNumber)
    {
        selectedWeapon = weaponData[weaponNumber];
        _maxRange = selectedWeapon.maxRangeValue;
        Debug.Log("selected weapon " + selectedWeapon.name);
        weaponText.text = "Current Weapon: " + selectedWeapon.name;
        currentWeaponSprite.sprite = weaponSprites[weaponNumber];
    }

    public void RollWeaponDice()
    {
        if (UI_Manager.numberOfLeftWeaponSwaps == 0 || UI_Manager.hasRerolledWeapon)
		{
            UI_Manager.cantRerollText.gameObject.SetActive(true);
            return;
		}
        UI_Manager.hasRerolledWeapon = true;

        int result = currentWeapon;
        while (result == currentWeapon)
		{
            result = Random.Range(0, weaponData.Length);
        }
        SelectWeapon(result);
        currentWeapon = result;

        UI_Manager.SwapWeapon(true);
    }
}
