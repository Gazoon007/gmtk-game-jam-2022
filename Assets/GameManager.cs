using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public event EventHandler DiceRolled;
    public event EventHandler EndTurn;

    public float attackTime;

    private static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void RollDice()
    {
        if (DiceRolled != null) DiceRolled(this, EventArgs.Empty);

    }
    
    public void EndTurnButton()
    {
        if (EndTurn != null) EndTurn(this, EventArgs.Empty);

    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
