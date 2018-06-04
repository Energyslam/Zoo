using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour {
    public delegate void MeatButtonEventHandler();
    public delegate void MeatObjectEventHandler();
    public delegate void LeafButtonEventHandler();
    public delegate void LeafObjectEventHandler();
    public delegate void TrickButtonEventHandler();
    public delegate void HelloButtonEventHandler();
    public delegate void ResetGameEventHandler();
    public delegate void GameOverEventHandler();

    public static event MeatObjectEventHandler MeatObjectPickedUp;
    public static event MeatButtonEventHandler MeatButtonPressed;
    public static event LeafButtonEventHandler LeafObjectPickedUp;
    public static event LeafObjectEventHandler LeafButtonPressed;
    public static event TrickButtonEventHandler TrickButtonPressed;
    public static event HelloButtonEventHandler HelloButtonPressed;
    public static event ResetGameEventHandler ResetGame;
    public static event GameOverEventHandler GameOver;

    public virtual void OnMeatButtonPressed()
    {
        if (MeatButtonPressed != null)
            MeatButtonPressed();
    }

    public virtual void OnMeatObjectPickedUp()
    {
        if (MeatObjectPickedUp != null)
            MeatObjectPickedUp();
    }

    public virtual void OnLeafButtonPressed()
    {
        if (LeafButtonPressed != null)
            LeafButtonPressed();
    }

    public virtual void OnLeafObjectPickedUp()
    {
        if (LeafObjectPickedUp != null)
            LeafObjectPickedUp();
    }

    public virtual void OnTrickButtonPressed()
    {
        if (TrickButtonPressed != null)
            TrickButtonPressed();
    }

    public virtual void OnHelloButtonPressed()
    {
        if (HelloButtonPressed != null)
            HelloButtonPressed();
    }

    public virtual void OnResetGame()
    {
        if (ResetGame != null)
            ResetGame();
    }

    public virtual void OnGameOver()
    {
        if (GameOver != null)
        {
            GameOver();
        }
    }

    public void OnDeath()
    {
        OnGameOver();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnGameOver();
        }
    }
}
