using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;

    public void DoBlast(Rigidbody rb, Vector3 position)
    {
        rb.AddExplosionForce(explosionForce, position, explosionRadius, 5f, ForceMode.Force);
    }
}
