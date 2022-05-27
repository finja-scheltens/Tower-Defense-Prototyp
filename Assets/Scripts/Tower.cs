using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    private Transform turretTransform;

    private float range = 10f;
    public GameObject bulletPrefab;
    public GameObject bulletEmitter;


    private float fireCoolDown = 0.5f;
    private float fireCoolDownLeft = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        turretTransform = transform.Find("Turret");
    }

    // Update is called once per frame
    void Update()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach(Enemy e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if (nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if (nearestEnemy == null)
        {
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        turretTransform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);

        fireCoolDownLeft -= Time.deltaTime;
        
        if (fireCoolDownLeft <= 0 && dir.magnitude <= range)
        {
            fireCoolDownLeft = fireCoolDown;
            ShootAtEnemy(nearestEnemy);
        }
    }

    void ShootAtEnemy(Enemy e)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletEmitter.transform.position, bulletEmitter.transform.rotation);
        Bullet b = bullet.GetComponent<Bullet>();
        b.target = e.transform;
    }
}
