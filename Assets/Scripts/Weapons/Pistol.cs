using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        if (CurrentDelay <= 0)
        {
            Instantiate(Bullet, ShotPoint.transform.position, Quaternion.identity);
            CurrentDelay = ShotDelay;
        }
    }
}
