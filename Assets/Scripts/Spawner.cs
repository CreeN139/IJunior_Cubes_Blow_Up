using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _scaleMultiplier = 2;
    private int _minCount = 2;
    private int _maxCount = 6;
    private int _minSpawnValue = 0;
    private int _maxSpawnValue = 100;
    private int _spawnScaler = 2;
    private float _explosionScaler = 1.5f;

    public Cube[] Spawn(Cube cube)
    {
        int needToSpawnValue = UnityEngine.Random.Range(_minSpawnValue, _maxSpawnValue + 1);

        if (needToSpawnValue <= cube.SpawnChance)
        {
            int spawnValue = UnityEngine.Random.Range(_minCount, _maxCount + 1);
            Cube[] blowCubes = new Cube[spawnValue];

            for (int i = 0; i < spawnValue; i++)
            {
                Cube newCube = Instantiate(cube);
                newCube.Initialize(cube.transform.position, cube.transform.localScale / _scaleMultiplier, UnityEngine.Random.ColorHSV(), cube.SpawnChance / _spawnScaler, cube.ExplosionForce * _explosionScaler, cube.ExplosionRadius * _explosionScaler);
                blowCubes[i] = newCube;
            }

            Debug.Log($"Создано {spawnValue} кубов с шансом последующийх спавнов {cube.SpawnChance / _spawnScaler}%!");
            return blowCubes;
        }
        else
        {
            Debug.Log("Не заспавнило!");
            return null;
        }
    }

    public void Delete(Cube cube) =>
        Destroy(cube.gameObject);
}
