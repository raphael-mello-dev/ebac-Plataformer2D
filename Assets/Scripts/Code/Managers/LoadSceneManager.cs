using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager
{
    #region Scenes enum

    public enum GameScenes
    {
        MENU = 0,
        GAMEPLAY = 1
    }

    #endregion

    #region Load Scene function

    public static void LoadScene(GameScenes scene)
    {
        SceneManager.LoadScene((int) scene);
    }

    #endregion
}