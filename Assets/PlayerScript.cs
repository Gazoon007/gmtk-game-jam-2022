using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public bool canAttack;
    private static PlayerScript instance;

    public static PlayerScript GetInstance()
    {
        return instance;
    }


    public float TryAttack()
    {
        if (canAttack)
        {

            float damage = 10f;
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
