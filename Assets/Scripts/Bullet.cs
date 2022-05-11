using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private TypeBullet _type;

    private bool _isHit;
    private float _currentDistance;

    public TypeBullet Type => _type;

    private void OnEnable()
    {
        _currentDistance = _distance;
        _isHit = false;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
        _currentDistance -= _speed * Time.deltaTime;

        if (_currentDistance <= 0)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isHit == false && collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            _isHit = true;
            gameObject.SetActive(false);
        }
    }
}

public enum TypeBullet
{
    Common,
    Upgraded,
    Shotgun,
    AssaultRifle, 
    Minigun
}