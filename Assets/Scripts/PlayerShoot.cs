using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed, shootTimer;

    private bool isShooting;

    public Transform shootPos1, shootPos2;
    public GameObject bullet;

    
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }


    IEnumerator Shoot()
    {
        isShooting = true;
        if(PlayerPrefs.GetInt("Pos") == 1)
        {
            GameObject newBullet = Instantiate(bullet, shootPos1.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);
        }

        if (PlayerPrefs.GetInt("Pos") == 0)
        {
            GameObject newBullet = Instantiate(bullet, shootPos2.position, Quaternion.Euler(new Vector3(0f,-180f, 0f)));
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed * Time.fixedDeltaTime, 0f);
        }
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
