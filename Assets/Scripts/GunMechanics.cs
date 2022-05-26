using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMechanics : MonoBehaviour
{
        public Transform firePoint;
        public WeaponSO weapon;
        public int bulletsLeft, totalBulletsLeft, bulletsPerTap;
        private int bulletsShot;
        private bool shooting, readyToShoot, reloading;



        private void Awake()
        {
                readyToShoot = true;
        }
        private void Update()
        {
                if (transform.parent.name == "EquippedWeapon")
                        MyInput();
        }
        private void MyInput()
        {
                if (weapon.allowButtonHold)
                        shooting = Input.GetKey(KeyCode.Mouse0);
                else
                        shooting = Input.GetKeyDown(KeyCode.Mouse0);

                if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < weapon.magazineSize && totalBulletsLeft > 0 && !reloading)
                        Reload();

                if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
                {
                        Shoot();
                        bulletsShot = bulletsPerTap;
                }
        }

        private void Shoot()
        {
                readyToShoot = false;
                GameObject bullet = Instantiate(weapon.bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(firePoint.up * weapon.bulletForce, ForceMode2D.Impulse);
                bulletsLeft--;
                bulletsShot--;
                Invoke("ResetShot", weapon.timeBetweenShooting);
                if (bulletsShot > 0 && bulletsLeft > 0)
                        Invoke("Shoot", weapon.timeBetweenShots);
        }

        private void ResetShot()
        {
                readyToShoot = true;
        }

        private void Reload()
        {
                reloading = true;
                Invoke("ReloadFinished", weapon.reloadTime);
        }

        private void ReloadFinished()
        {
                if (totalBulletsLeft - weapon.magazineSize + bulletsLeft < 0)
                {
                        bulletsLeft = totalBulletsLeft;
                        totalBulletsLeft = 0;
                }
                else
                {
                        totalBulletsLeft = totalBulletsLeft - weapon.magazineSize + bulletsLeft;
                        bulletsLeft = weapon.magazineSize;
                }
                reloading = false;
        }
}
