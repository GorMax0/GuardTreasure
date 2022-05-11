using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private Bullet _freeBullet;
    private List<Bullet> _bullets = new List<Bullet>();

    public void InvokeBullet(Bullet bulletPrefab, ShootPoint shootPosition, Quaternion rotation)
    {
        if (HasFreeBullet(bulletPrefab))
        {
            _freeBullet.transform.position = shootPosition.transform.position;
            _freeBullet.transform.rotation = rotation;
            _freeBullet.gameObject.SetActive(true);
        }
        else
        {
            CreateBullet(bulletPrefab, shootPosition, rotation);
        }
    }

    private bool HasFreeBullet(Bullet bulletPrefab)
    {
        foreach (var bullet in _bullets)
        {
            if (bullet.Type == bulletPrefab.Type && bullet.gameObject.activeSelf == false)
            {
                _freeBullet = bullet;
                return true;
            }
        }

      return false;
    }

    private void CreateBullet(Bullet bulletPrefab, ShootPoint shootPosition, Quaternion rotation)
    {
         _freeBullet = Instantiate(bulletPrefab, shootPosition.transform.position, rotation, transform);

        _bullets.Add(_freeBullet);
    }
}
