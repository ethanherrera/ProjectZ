using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponSO", order = 1)]
public class WeaponSO : ScriptableObject
{
        public Sprite sprite;
        public GameObject bulletPrefab;
        public float bulletForce = 20f;
        public int damage;
        public float reloadTime;
        public int magazineSize;
        public float timeBetweenShooting, timeBetweenShots, spread;
        public bool allowButtonHold;
}
