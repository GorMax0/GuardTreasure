using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField, TextArea] private string _description;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    [SerializeField] protected float ShotDelay;
    [SerializeField] protected ShootPoint ShootPoint;
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected BulletPool BulletPool;
    [SerializeField] protected ParticleSystem ShootEffect;

    public float CurrentDelay { get; protected set; }
    public float ReloadDelay => ShotDelay;
    public string Label => _label;
    public string Description => _description;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public bool NeedReload;

    private void Update()
    {
        if (NeedReload == true && CurrentDelay != ShotDelay)
            NeedReload = false;

        if (CurrentDelay > 0)
            CurrentDelay -= Time.deltaTime;
    }

    public abstract void Shoot();

    public void Buy()
    {
        _isBuyed = true;
    }
}