using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public event EventHandler EndTurn;
    private static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
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
