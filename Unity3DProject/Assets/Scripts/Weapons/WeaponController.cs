using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform weaponhHold;
    Gun equippedGun;
    public Gun startingGun;

    public GameObject bulletPrefab;
    //public Transform bulletSpawn;

    public float msBetweenShots = 50;
    float nextShotTime;

    void Start()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    public void EquipGun(Gun GunToEquip)
    {
        if(equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(GunToEquip, weaponhHold.position, weaponhHold.rotation) as Gun;
        equippedGun.transform.parent = weaponhHold;
    }

    public void Shoot()
    {
        if (equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }

    void Fire()
    {
        /*
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 16;

        Destroy(bullet, 2.0f);

        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 800;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * nextShotTime;

            Destroy(bullet, 1.5f);
        }*/
    }
}
