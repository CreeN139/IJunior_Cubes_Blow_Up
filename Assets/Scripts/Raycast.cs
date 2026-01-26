using System;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    public event Action<Cube> OnCubeHit;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.TryGetComponent<Cube>(out Cube cube))
                {
                    OnCubeHit?.Invoke(cube);
                }
            }
        }
    }
}
