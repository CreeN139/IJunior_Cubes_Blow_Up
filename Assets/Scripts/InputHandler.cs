using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const int Button = 0;
    public event Action IsClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(Button))
        {
            IsClicked?.Invoke();
        }
    }
}
