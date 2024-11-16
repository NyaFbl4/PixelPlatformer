using PixelPlatformer;
using UnityEngine;

public class HealthPointComponent : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _health;

    public void TakeDamage()
    {
        Debug.Log("TakeDamage");
    }
}
