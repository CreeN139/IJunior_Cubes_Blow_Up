using System;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private float _rayLength = 1000f;
    public event Action<Cube> DetectedCube;

    private void OnEnable()
    {
        _inputHandler.IsClicked += CheckHit;
    }

    private void OnDisable()
    {
        _inputHandler.IsClicked -= CheckHit;
    }

    private void CheckHit()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayLength))
        {
            if (hit.transform.gameObject.TryGetComponent(out Cube resourse))
            {
                DetectedCube?.Invoke(resourse);
            }
        }
    }
}
