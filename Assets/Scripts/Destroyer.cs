using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Raycast _raycast;

    private void OnEnable()
    {
        _raycast.OnCubeHit += Delete;
    }

    private void OnDisable()
    {
        _raycast.OnCubeHit -= Delete;
    }

    private void Delete(Cube cube) => Destroy(cube.gameObject);
}
