using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoot : MonoBehaviour {

    private RedBullet bullet;

    void Start()
    {
        bullet = Resources.Load<RedBullet>("RedBullet");
    }


    void Update()
    {
        if (Random.Range(0,15)==0) Shoot();
    }

    private void Shoot()
    {
        RedBullet newBullet = Instantiate(bullet, this.transform.position+new Vector3(1.0f,0,0), bullet.transform.rotation);
        newBullet.parent = gameObject;
        newBullet.Fire();
    }
}
