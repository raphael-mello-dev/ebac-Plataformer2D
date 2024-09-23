using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public PlayerHealthData playerHealthData;

    [SerializeField] private TextMeshProUGUI _lifesTextDisplay;

    [SerializeField] private TextMeshProUGUI _coinsTextDisplay;

    [SerializeField] private int _coinsAmount;

    private void Start()
    {
        _coinsAmount = 0;
        _coinsTextDisplay.text = "X 00";

        if (playerHealthData.NumOfLifes < 10)
            _lifesTextDisplay.text = $"X 0{playerHealthData.NumOfLifes}";
        else
            _lifesTextDisplay.text = $"X {playerHealthData.NumOfLifes}";
    }
    
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

    public void LifeCollectedDisplay()
    {
        if (playerHealthData.NumOfLifes < 10)
            _lifesTextDisplay.text = $"X 0{playerHealthData.NumOfLifes}";
        else
            _lifesTextDisplay.text = $"X {playerHealthData.NumOfLifes}";
    }
}