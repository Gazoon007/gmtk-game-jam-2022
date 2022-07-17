using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
	private void OnMouseDown()
	{
		PlayerScript.GetInstance().LaunchProjectile();
		
		LeanTween.delayedCall(2f, () =>
		{
			GameManager.GetInstance().EndTurnButton();
			gameObject.transform.position = new Vector3(0f, gameObject.transform.position.y, gameObject.transform.position.z);
			gameObject.SetActive(false);
		});
	}
}
