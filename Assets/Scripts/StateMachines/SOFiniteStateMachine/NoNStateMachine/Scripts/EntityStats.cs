using UnityEngine;

public class EntityStats : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    public float Health
    {
        get => health;
        set => health = value;
    }

    private void Update()
    {
        health -= 1 * Time.deltaTime;
    }

    public bool IsHealthy()
    {
        bool isHealthy = health > 80;
        return isHealthy;
    }
}
