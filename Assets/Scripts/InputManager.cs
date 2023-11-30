using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public static Controls controls;

    //This method is called when the player starts, it enables the 
    public static void Init()
    {
        controls = new Controls();
        controls.Enable();
    }

    public static void Destroy()
    {
        controls.Dispose();
    }

    #region Modes
    //This method toggles on the game controls
    public static void GameMode()
    {
        controls.Game.Enable();
        controls.UI.Disable();
    }

    //This method toggles on the UI controls
    public static void UIMode()
    {
        controls.Game.Disable();
        controls.UI.Enable();
    }
    #endregion
}

