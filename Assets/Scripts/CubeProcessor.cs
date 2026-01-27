using UnityEngine;

public class CubeProcessor : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploader _exploader;
    [SerializeField] private Raycast _raycast;

    private void OnEnable()
    {
        _raycast.DetectedCube += Work;
    }

    private void OnDisable()
    {
        _raycast.DetectedCube -= Work;
    }

    private void Work(Cube cube)
    {
        DoBlowUp(_spawner.Spawn(cube));
        _spawner.Delete(cube);
    }

    private void DoBlowUp(Cube[] cubes)
    {
        if (cubes == null)
        {
            return;
        }

        foreach (Cube cube in cubes)
        {
            Rigidbody rigidbody = cube.Rigidbody;
            _exploader.DoBlast(rigidbody, cube.transform.position);
        }
    }
}
