using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action OnSpacePressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }
    }
}