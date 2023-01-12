using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float FireRate;
    private float LastFireTime;

    public void Init()
    {
        LastFireTime = Time.time;
    }

    void Update()
    {
        if (tag == "Player" && Input.GetAxisRaw("Fire1") > 0.0f)
        {
            TryFire();
        }
    }

    void Fire()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 2000);
    }

    public void TryFire()
    {
        if (Time.time < LastFireTime + FireRate)
        {
            return;
        }

        LastFireTime = Time.time;

        Fire();
    }

    public void TryFireTarget(RobotGuardAIController robotguardaicontroller)
    {
        Vector3 direction = robotguardaicontroller.player.position - this.transform.position;
        transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.LookRotation(direction),
            robotguardaicontroller.rotSpeed * Time.deltaTime);
        TryFire();
    }
}
