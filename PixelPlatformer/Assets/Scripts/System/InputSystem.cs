using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public event Action<float> OnMove;
    public event Action OnJump;

    public void Update()
    {
        
    }
}
