using UnityEngine;

public class CubeProcessor : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploader _exploader;
    [SerializeField] private Raycast _raycast;

    private int _minSpawnValue = 0;
    private int _maxSpawnValue = 100;

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
        int needToSpawnValue = Random.Range(_minSpawnValue, _maxSpawnValue + 1);

        if (needToSpawnValue <= cube.SpawnChance)
        {
            DoBlowUp(_spawner.Spawn(cube), cube);
            _spawner.Delete(cube);
        }
        else
        {
            DoBlowUp(null, cube);
            _spawner.Delete(cube);
        }
    }

    private void DoBlowUp(Cube[] cubes, Cube oldCube)
    {
        if (cubes == null)
        {
            _exploader.DoFailureSpawnBlast(oldCube);
        }
        else
        {
            foreach (Cube cube in cubes)
            {
                _exploader.DoSuccessSpawnBlast(cube);
            }
        }
    }
}
