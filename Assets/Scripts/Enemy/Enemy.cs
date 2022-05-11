using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private int _experience;
    [SerializeField] private ParticleSystem _damageEffect;

    private Player _target;

    public int Reward => _reward;
    public int Experience => _experience;
    public Player Target => _target;

    public event UnityAction<Enemy> Died;

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _damageEffect.gameObject.SetActive(true);
        _damageEffect.Play();

        if (_health <= 0)
            Died?.Invoke(this);
    }
}
