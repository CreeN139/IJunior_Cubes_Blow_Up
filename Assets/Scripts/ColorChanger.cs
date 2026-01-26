using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, 1.0f);
    }
}
