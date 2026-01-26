using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Raycast _raycast;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Exploader _exploader;
    private int _scaleMultiplier = 2;
    private int _minCount = 2;
    private int _maxCount = 6;
    private int _minSpawnValue = 0;
    private int _maxSpawnValue = 100;
    private int _spawnScaler = 2;

    private void OnEnable()
    {
        _raycast.OnCubeHit += Spawn;
    }

    private void OnDisable()
    {
        _raycast.OnCubeHit += Spawn;
    }

    private void Spawn(Cube cube)
    {
        int needToSpawnValue = Random.Range(_minSpawnValue, _maxSpawnValue + 1);

        if (needToSpawnValue <= cube.SpawnChance)
        {
            int spawnValue = Random.Range(_minCount, _maxCount + 1);

            for (int i = 0; i < spawnValue; i++)
            {
                Cube newCube = Instantiate(cube);
                newCube.Initialize(cube.transform.position, cube.transform.localScale / _scaleMultiplier, _colorChanger.GetRandomColor(), cube.SpawnChance / _spawnScaler);
                _exploader.DoBlast(newCube.GetComponent<Rigidbody>(), newCube.transform.position);
            }

            Debug.Log($"Создано {spawnValue} кубов с шансом последующийх спавнов {cube.SpawnChance / _spawnScaler} %!");
        }
        else
        {
            Debug.Log("Не заспавнило!");
        }
    }
}
