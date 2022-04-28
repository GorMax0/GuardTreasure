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
            Instantiate(Bullet, ShotPoint.transform.position, Quaternion.identity);
            _currentCountBullets--;

            yield return delay;
        }

        if (_currentCountBullets == 0)
        {
            CurrentDelay = ShotDelay;
            _currentCountBullets = _bulletsInMagazine;
        }
    }
}
