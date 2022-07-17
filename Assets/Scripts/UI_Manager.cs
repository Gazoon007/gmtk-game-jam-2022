using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
	private Transform activeMenu;
	private Transform menuBackgroundImage;
	private Transform mainMenu;
	private Transform creditsMenu;
	private Transform levelSelectMenu;
	private Transform gameOverlay;
	private Transform weaponSelection;
	private Transform wonMenu;
	private Transform lostMenu;
	public Transform cantRerollText;


	public int numberOfLeftWeaponSwaps;

	public bool hasRerolledWeapon;
	public bool isFirstWeaponReroll = true;

	void Start()
	{
		Transform UI = GameObject.Find("New UI").transform.GetChild(0);
		menuBackgroundImage = UI.GetChild(0);
		mainMenu = UI.GetChild(1);
		creditsMenu = UI.GetChild(2);
		levelSelectMenu = UI.GetChild(3);
		gameOverlay = UI.GetChild(4);
		weaponSelection = UI.GetChild(5);
		wonMenu = UI.GetChild(6);
		lostMenu = UI.GetChild(7);
		cantRerollText = weaponSelection.GetChild(0);

		activeMenu = mainMenu;

		numberOfLeftWeaponSwaps = 2;
		SwapWeapon(false);
		ChangeEnemyCount(3);
		isFirstWeaponReroll = true;
	}

	public void Credits()
	{
		activeMenu.gameObject.SetActive(false);

		activeMenu = creditsMenu;
		creditsMenu.gameObject.SetActive(true);
	}

	public void MainMenu()
	{
		activeMenu.gameObject.SetActive(false);

		activeMenu = mainMenu;
		mainMenu.gameObject.SetActive(true);
	}

	public void LevelSelectMenu()
	{
		activeMenu.gameObject.SetActive(false);

		activeMenu = levelSelectMenu;
		levelSelectMenu.gameObject.SetActive(true);
	}

	public void LoadLevel()
	{
		if (isFirstWeaponReroll)
		{
			return;
		}

		activeMenu.gameObject.SetActive(false);
		menuBackgroundImage.gameObject.SetActive(false);

		activeMenu = gameOverlay;
		gameOverlay.gameObject.SetActive(true);
	}

	public void StartLevel(int level)
	{
		Debug.Log("Level " + level + " started");

		SelectWeapon();
	}

	// Call this to update the number in the top left corner
	public void SwapWeapon(bool subtractOne)
	{
		if (subtractOne && !isFirstWeaponReroll)
		{
			numberOfLeftWeaponSwaps--;
		}
		gameOverlay.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = numberOfLeftWeaponSwaps.ToString();

		isFirstWeaponReroll = false;
	}

	// Call this to change the text at the top
	public void ChangeMoveState(bool itIsNowThePlayersTurn)
	{
		if (itIsNowThePlayersTurn)
		{
			gameOverlay.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Your Move";
		}
		else
		{
			gameOverlay.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Enemy's Move";
		}
	}

	// Call this to change the number in the top right corner
	public void ChangeEnemyCount(int numberOfEnemys)
	{
		gameOverlay.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = numberOfEnemys.ToString();
	}

	public void SelectWeapon()
	{
		hasRerolledWeapon = false;
		cantRerollText.gameObject.SetActive(false);

		activeMenu.gameObject.SetActive(false);
		menuBackgroundImage.gameObject.SetActive(true);

		activeMenu = weaponSelection;
		weaponSelection.gameObject.SetActive(true);
	}

	public void ExitGame()
	{
		Application.Quit();

		Debug.Log("Application was exited");
	}

	public void ResetLevel()
	{
		Debug.Log("Level Reset");
	}

	public void YouWon()
	{
		activeMenu.gameObject.SetActive(false);
		menuBackgroundImage.gameObject.SetActive(true);

		activeMenu = wonMenu;
		wonMenu.gameObject.SetActive(true);
	}

	public void YouLost()
	{
		activeMenu.gameObject.SetActive(false);
		menuBackgroundImage.gameObject.SetActive(true);

		activeMenu = lostMenu;
		lostMenu.gameObject.SetActive(true);
	}
}
