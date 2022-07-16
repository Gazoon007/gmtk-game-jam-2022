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

	private int numberOfLeftWeaponSwaps;

	void Start()
	{
		Transform UI = GameObject.Find("UI").transform.GetChild(0);
		menuBackgroundImage = UI.GetChild(0);
		mainMenu = UI.GetChild(1);
		creditsMenu = UI.GetChild(2);
		levelSelectMenu = UI.GetChild(3);
		gameOverlay = UI.GetChild(4);

		activeMenu = mainMenu;

		numberOfLeftWeaponSwaps = 2;
		SwapWeapon(false);
		ChangeEnemyCount(3);
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

	public void StartLevel(int level)
	{
		activeMenu.gameObject.SetActive(false);
		menuBackgroundImage.gameObject.SetActive(false);

		activeMenu = gameOverlay;
		gameOverlay.gameObject.SetActive(true);

		Debug.Log("Level " + level + " started");
	}

	// Call this to update the number in the top left corner
	public void SwapWeapon(bool subtractOne)
	{
		if (subtractOne)
		{
			numberOfLeftWeaponSwaps--;
		}
		gameOverlay.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = numberOfLeftWeaponSwaps.ToString();
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

	//Call this to change the number in the top right corner
	public void ChangeEnemyCount(int numberOfEnemys)
	{
		gameOverlay.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = numberOfEnemys.ToString();
	}
}
