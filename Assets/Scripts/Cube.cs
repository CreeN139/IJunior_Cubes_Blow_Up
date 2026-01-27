using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;
    public int SpawnChance { get; private set; } = 100;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 position, Vector3 scale, Color color, int spawnChance)
    {
        transform.position = position;
        transform.localScale = scale;
        _renderer.material.color = color;
        SpawnChance = spawnChance;
    }
}
