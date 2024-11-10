using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public event Action<float> OnMove;
    public event Action OnJump;

    public void Update()
    {
        float directionX = 0;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            directionX = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            directionX = 1;
        }
        else
        {
            directionX = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
        
        OnMove?.Invoke(directionX);
    }
}
