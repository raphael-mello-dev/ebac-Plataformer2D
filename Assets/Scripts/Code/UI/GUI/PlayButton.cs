using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    #region Play Button Setup

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickPlay);
    }

    #endregion

    #region Play Game function

    private void OnClickPlay()
    {
        LoadSceneManager.LoadScene(LoadSceneManager.GameScenes.GAMEPLAY);
    }

    #endregion
}