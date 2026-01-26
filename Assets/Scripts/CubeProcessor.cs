using UnityEngine;

public class CubeProcessor : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploader _exploader;
    [SerializeField] private Raycast _raycast;

    private void OnEnable()
    {
        _raycast.IsCubeHit += BeginSpawn;
        _spawner.IsSpawned += DoBlowUp;
        _raycast.IsCubeHit += BeginDelete;
    }

    private void OnDisable()
    {
        _raycast.IsCubeHit -= BeginSpawn;
        _spawner.IsSpawned -= DoBlowUp;
        _raycast.IsCubeHit -= BeginDelete;
    }

    private void DoBlowUp(Cube[] cubes)
    {
        foreach (Cube cube in cubes)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();
            _exploader.DoBlast(rigidbody, cube.transform.position);
        }
    }

    private void BeginSpawn(Cube cube)
    {
        _spawner.Spawn(cube);
    }

    private void BeginDelete(Cube cube)
    {
        _spawner.Delete(cube);
    }
}
