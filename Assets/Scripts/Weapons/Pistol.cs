using UnityEngine;
using UnityEngine.Events;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        if (CurrentDelay <= 0)
        {
            BulletPool.InvokeBullet(Bullet, ShootPoint, Quaternion.identity);
            ShootEffect.gameObject.SetActive(true);
            CurrentDelay = ShotDelay;
            NeedReload = true;
        }
    }
}
