using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    #region Exit Button Setup

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickExit);
    }

    #endregion

    #region Exit function

    private void OnClickExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }

    #endregion
}