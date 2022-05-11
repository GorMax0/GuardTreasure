using System.Collections;
using UnityEngine;

public class Minigun : Weapon
{
    [SerializeField] private int _bulletsInMagazine = 100;

    private int _currentCountBullets;

    private void Start()
    {
        _currentCountBullets = _bulletsInMagazine;
    }

    public override void Shoot()
    {
        if (CurrentDelay <= 0)
        {
            if (_currentCountBullets != 0)
            {
                StartCoroutine(ShootInBursts());
            }
        }
    }

    private IEnumerator ShootInBursts()
    {
        WaitForSeconds delay = new WaitForSeconds(0.05f);

        while (Input.GetMouseButton(0) && _currentCountBullets != 0)
        {
            BulletPool.InvokeBullet(Bullet, ShootPoint, Quaternion.identity);
            ShootEffect.gameObject.SetActive(true);
            _currentCountBullets--;

            yield return delay;
        }

        if (_currentCountBullets == 0)
        {
            CurrentDelay = ShotDelay;
            NeedReload = true;
            _currentCountBullets = _bulletsInMagazine;
        }
    }
}
