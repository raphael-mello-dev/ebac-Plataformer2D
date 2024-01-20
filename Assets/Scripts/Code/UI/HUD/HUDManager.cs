using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    #region Coin text reference

    [SerializeField] private TextMeshProUGUI _coinsTextDisplay;

    #endregion

    #region Number of coins gathered

    [SerializeField] private int _coinsAmount;

    #endregion

    #region HUD Display Setup

    private void Start()
    {
        _coinsAmount = 0;
        _coinsTextDisplay.text = "X 00";
    }

    #endregion

    #region Function to display gathered coins

    public void CoinCollectedDisplay(Component sender, object data)
    {
        if (data is int)
        {
            _coinsAmount += (int)data;
        }
        else
        {
            Debug.LogError("Data needs to be a int");
            return;
        }

        if (_coinsAmount < 10)
            _coinsTextDisplay.text = $"X 0{_coinsAmount}";
        else
            _coinsTextDisplay.text = $"X {_coinsAmount}";
    }

    #endregion
}