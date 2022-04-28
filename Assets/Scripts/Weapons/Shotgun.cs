using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField, Range(0, 5)] private int _multiplyAccuracy;
    [SerializeField, Range(6, 12)] private int _numbersOfBullets;

    public override void Shoot()
    {
        if (CurrentDelay <= 0)
        {
            for (int currentBullet = 0; currentBullet < _numbersOfBullets; currentBullet++)
            {
                bool isEvenNumber = currentBullet % 2 == 0;
                int bulletScatter = isEvenNumber ? currentBullet * _multiplyAccuracy : -currentBullet * _multiplyAccuracy;
                Quaternion bulletRotation = Quaternion.Euler(0, 0, bulletScatter);

                Instantiate(Bullet, ShotPoint.transform.position, bulletRotation);
                CurrentDelay = ShotDelay;
            }
        }
    }
}
