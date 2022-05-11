using System.Collections;
using UnityEngine;

public class AssaultRifle : Weapon
{
    [SerializeField] private int _numberBulletsInQueue;

    public override void Shoot()
    {
        if (CurrentDelay <= 0)
        {
            StartCoroutine(ShootInBursts());
        }
    }

    private IEnumerator ShootInBursts()
    {

        WaitForSeconds delay = new WaitForSeconds(0.2f);

        for (int currentBullet = 1; currentBullet <= _numberBulletsInQueue; currentBullet++)
        {
            BulletPool.InvokeBullet(Bullet, ShootPoint, Quaternion.identity);
            ShootEffect.gameObject.SetActive(true);

            if (currentBullet == _numberBulletsInQueue)
            {
                CurrentDelay = ShotDelay;
                NeedReload = true;
            }

            yield return delay;
        }
    }
}
