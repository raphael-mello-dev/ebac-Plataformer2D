using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected PlayerInputManager _inputManagerInstance;

    private void Awake()
    {
        _inputManagerInstance = new PlayerInputManager();
    }
}
