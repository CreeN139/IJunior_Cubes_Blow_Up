using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _scaleMultiplier = 2;
    private int _minCount = 2;
    private int _maxCount = 6;
    private int _spawnScaler = 2;
    private float _explosionScaler = 1.5f;

    public Cube[] Spawn(Cube cube)
    {
        int spawnValue = Random.Range(_minCount, _maxCount + 1);
        Cube[] blowCubes = new Cube[spawnValue];

        for (int i = 0; i < spawnValue; i++)
        {
            Cube newCube = Instantiate(cube);
            newCube.Initialize(cube.transform.position, GetScaledSize(cube), Random.ColorHSV(), GetScaledSpawn(cube), GetScaledForce(cube), GetScaledRadius(cube));
            blowCubes[i] = newCube;
        }

        return blowCubes;
    }

    public void Delete(Cube cube) =>
        Destroy(cube.gameObject);

    private Vector3 GetScaledSize(Cube cube)
    {
        return cube.transform.localScale / _scaleMultiplier;
    }

    private int GetScaledSpawn(Cube cube)
    {
        return cube.SpawnChance / _spawnScaler;
    }

    private float GetScaledForce(Cube cube)
    {
        return cube.ExplosionForce * _explosionScaler;
    }

    private float GetScaledRadius(Cube cube)
    {
        return cube.ExplosionRadius * _explosionScaler;
    }
}
