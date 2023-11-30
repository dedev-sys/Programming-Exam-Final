using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static GameControls _gameControls;

    public static void Init(BallController Ball)
    {
        _gameControls = new GameControls();

        _gameControls.PreGame.Enable();

        _gameControls.PreGame.Start.performed += ctx =>
        {
            Ball.Press();
        };
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
