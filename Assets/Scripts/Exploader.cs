using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _upwardsModifier;

    public void DoSuccessSpawnBlast(Rigidbody rigidbody, Vector3 position)
    {
        rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius, _upwardsModifier, ForceMode.Force);
    }

    public void DoFailureSpawnBlast(Cube resource)
    {
        Collider[] nearCubes = Physics.OverlapSphere(resource.transform.position, resource.ExplosionRadius);

        for (int i = 0; i < nearCubes.Length; i++)
        {
            Rigidbody rigidbody = nearCubes[i].attachedRigidbody;

            if (rigidbody != null)
            {
                float fadingForce = (1 - Vector3.Distance(nearCubes[i].transform.position, resource.transform.position) / resource.ExplosionRadius) * resource.ExplosionForce;
                rigidbody.AddExplosionForce(fadingForce, resource.transform.position, resource.ExplosionRadius);
            }
        }

        Debug.Log($"Произошел взрыв радиусом {resource.ExplosionRadius} юнитов и силой {resource.ExplosionForce} единиц!");
    }
}
