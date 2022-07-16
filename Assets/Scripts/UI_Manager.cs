using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
	private Transform activeMenu;
	private Transform mainMenu;
	private Transform creditsMenu;
	private Transform levelSelectMenu;
	private Transform gameOverlay;

	void Start()
	{
		Transform UI = GameObject.Find("UI").transform.GetChild(0);
		mainMenu = UI.GetChild(1);
		creditsMenu = UI.GetChild(2);
		levelSelectMenu = UI.GetChild(3);
		gameOverlay = UI.GetChild(4);

		activeMenu = mainMenu;
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

		activeMenu = gameOverlay;
		gameOverlay.gameObject.SetActive(true);

		Debug.Log("Level " + level + " started");
	}
}
