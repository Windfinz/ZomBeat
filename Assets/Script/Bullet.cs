using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public GameObject bullet;

    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magSize, bulletPerTap;
    public bool allowButtonHold;

    int bulletLeft, bulletShot;
    bool shooting, readyToShoot, reloading;

    public Camera Camera;
    public Transform attackPoint;

    public bool allowInvoke = true;

    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI amunitionDisplay;
    public TextMeshProUGUI reloadingDisplay;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        bulletLeft = magSize;
        readyToShoot = true;

        reloadingDisplay.enabled = false;
    }

    

    private void Update()
    {
        MyInput();

        if(amunitionDisplay != null)
        {
            amunitionDisplay.SetText(bulletLeft / bulletPerTap + " / " + magSize /  bulletPerTap);
        }
    }


    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if(Input.GetKeyDown(KeyCode.R) && bulletLeft < magSize && !reloading)
        {
            Reload();
        }

        if(readyToShoot && shooting && !reloading && bulletLeft <= 0)
        {
            Reload();
        }

        if(readyToShoot && shooting && !reloading && bulletLeft > 0)
        {
            bulletShot = 0;

            Shoot();
        }

    }

    private void Shoot()
    {
        muzzleFlash.Play();
        readyToShoot = false;

        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75) ;
        }

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread); 

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity) ;

        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(Camera.transform.up * upwardForce, ForceMode.Impulse);

        //if (muzzleFlash != null)
        //{
        //    Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        //}

        bulletLeft--;
        bulletShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if(bulletShot < bulletPerTap && bulletLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;

    }

    private void Reload()
    {
        reloadingDisplay.enabled = true;
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        reloadingDisplay.enabled = false;
        bulletLeft = magSize;
        reloading = false;
    }


}
