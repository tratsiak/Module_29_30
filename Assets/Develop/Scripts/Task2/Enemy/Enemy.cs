using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private int _health;
    private int _damage;

    public virtual void Initialize(EnemySettings settings)
    {
        _health = settings.Health;
        _damage = settings.Damage;
    }

    public virtual string GetInfo() => $"Health: {_health}, Damage: {_damage}";
}
