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
            Instantiate(Bullet, ShotPoint.transform.position, Quaternion.identity);

            if (currentBullet == _numberBulletsInQueue)
            {
                CurrentDelay = ShotDelay;
            }

            yield return delay;
        }
    }
}
