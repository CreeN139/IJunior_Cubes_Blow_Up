using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _upwardsModifier;

    public void DoBlast(Rigidbody rigidbody, Vector3 position)
    {
        rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius, _upwardsModifier, ForceMode.Force);
    }
}
