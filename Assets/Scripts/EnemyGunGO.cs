using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunGO : MonoBehaviour
{
    public GameObject EnemyBulletGO; //prefabs peluru milik musuh

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 1f); //nembak peluru setelah 1 detik
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {
        //get a  reference to player's ship
        GameObject playerShip = GameObject.Find("PlayerGO");

        if(playerShip != null) //klo player ga mati
        {
            //panggil peluru musuh
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

            //mengatue posisi peluru
            bullet.transform.position = transform.position;

            //menghitung arah peluru  ke player
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //mengatur arah peluru
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
