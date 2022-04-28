using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    [SerializeField] protected float ShotDelay;
    [SerializeField] protected ShootPoint ShotPoint;
    [SerializeField] protected Bullet Bullet;

    protected float CurrentDelay;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;

    private void Update()
    {
        if (CurrentDelay > 0)
        {
            CurrentDelay -= Time.deltaTime;
        }
    }

    public abstract void Shoot();

    public void Buy()
    {
        _isBuyed = true;
    }
}