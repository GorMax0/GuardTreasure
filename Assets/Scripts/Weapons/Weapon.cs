using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed;

    [SerializeField] protected float ShotDelay;
    [SerializeField] protected ShootPoint ShotPoint;
    [SerializeField] protected Bullet Bullet;

    protected float CurrentDelay;

    private void Update()
    {
        if (CurrentDelay > 0)
        {
            CurrentDelay -= Time.deltaTime;
        }
    }

    public abstract void Shoot();
}