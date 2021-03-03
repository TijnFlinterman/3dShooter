using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    float damage = 1f;
    public float range = 100f;
    public float impactForce = 30f;
    public Camera fpsCam;
    public GameObject impact;
    public ParticleSystem muzzleFlash;
    public AudioSource shoot;
    public AudioSource rLoad;
    bool canShoot = true;
    public float fireSpeed;
    bool empty = false;

    int ammo;
    int maxAmmo = 30;
    float reloadspeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canShoot = true;
        ammo = maxAmmo;
    }

    void Update()
    {
        if (canShoot == true && Input.GetButton("Fire1") && empty == false)
        {
            ammo -= 1;
            StartCoroutine(Shooting());
        }
        if (empty == true && Input.GetKeyDown(KeyCode.R))
        {
            ammo = 30;
            canShoot = true;
            return;
        }
        if (ammo <= 0)
        {
            empty = true;
        }
        else
        {
            empty = false;
        }
        if (canShoot == true && empty == false && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(tacReload());
        }
        if (empty == true && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
        }
    }

    IEnumerator tacReload()
    {
        rLoad.Play();
        yield return new WaitForSeconds(0.8f);
        ammo = 31;
        canShoot = true;
    }
    IEnumerator reload()
    {
        rLoad.Play();
        yield return new WaitForSeconds(0.8f);
        ammo = 30;
        canShoot = true;
    }

    IEnumerator Shooting()
    {
         canShoot = false;
         shoot.Play();
         muzzleFlash.Play();
         RaycastHit hit;
         if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
         {
            Target Enemy = hit.transform.GetComponent<Target>();
            hit.transform.GetComponent<Target>();

            if (Enemy != null)
            {
                 Enemy.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                 hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
         }
            yield return new WaitForSeconds(fireSpeed);
            canShoot = true;
    }
}
