using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;

    public int SpawnChance { get; private set; } = 100;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(Vector3 position, Vector3 scale, Color color, int spawnChance)
    {
        transform.position = position;
        transform.localScale = scale;
        _renderer.material.color = color;
        SpawnChance = spawnChance;
    }
}
