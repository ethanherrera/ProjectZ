using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMechanics : MonoBehaviour
{
        public Transform firePoint;
        public GameObject bulletPrefab;
        public float bulletForce = 20f;
        public int damage;
        public float reloadTime;
        public int magazineSize, bulletsLeft, totalBulletsLeft;
        public float timeBetweenShooting, timeBetweenShots, spread;
        public bool allowButtonHold;
        private int bulletsPerTap, bulletsShot;
        private bool shooting, readyToShoot, reloading;



        private void Awake()
        {
                readyToShoot = true;
        }
        private void Update()
        {
                MyInput();
        }
        private void MyInput()
        {
                if (allowButtonHold)
                        shooting = Input.GetKey(KeyCode.Mouse0);
                else
                        shooting = Input.GetKeyDown(KeyCode.Mouse0);

                if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && totalBulletsLeft > 0 && !reloading)
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
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                bulletsLeft--;
                bulletsShot--;
                Invoke("ResetShot", timeBetweenShooting);
                if (bulletsShot > 0 && bulletsLeft > 0)
                        Invoke("Shoot", timeBetweenShots);
        }

        private void ResetShot()
        {
                readyToShoot = true;
        }

        private void Reload()
        {
                reloading = true;
                Invoke("ReloadFinished", reloadTime);
        }

        private void ReloadFinished()
        {
                if (totalBulletsLeft - magazineSize + bulletsLeft < 0)
                {
                        bulletsLeft = totalBulletsLeft;
                        totalBulletsLeft = 0;
                }
                else
                {
                        totalBulletsLeft = totalBulletsLeft - magazineSize + bulletsLeft;
                        bulletsLeft = magazineSize;
                }
                reloading = false;
        }
}
