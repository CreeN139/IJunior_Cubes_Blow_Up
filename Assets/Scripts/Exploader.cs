using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _upwardsModifier;
    private LayerMask _cubeLayer = 1 << 6;

    public void DoSuccessSpawnBlast(Cube cube)
    {
        cube.Rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius, _upwardsModifier, ForceMode.Force);
    }

    public void DoFailureSpawnBlast(Cube cube)
    {
        Collider[] nearCubes = Physics.OverlapSphere(cube.transform.position, cube.ExplosionRadius, _cubeLayer);

        Debug.Log("Прошел фейл, прокинулась сфера");

        for (int i = 0; i < nearCubes.Length; i++)
        {
            Rigidbody rigidbody = nearCubes[i].attachedRigidbody;

            if (rigidbody != null)
            {
                float sqrDistance = (nearCubes[i].transform.position - cube.transform.position).sqrMagnitude;
                float sqrRadius = cube.ExplosionRadius * cube.ExplosionRadius;
                float fadingForce = (1 - sqrDistance / sqrRadius) * cube.ExplosionForce;

                if (fadingForce < 0)
                {
                    return;
                }

                rigidbody.AddExplosionForce(fadingForce, cube.transform.position, cube.ExplosionRadius);
            }
        }
    }
}
