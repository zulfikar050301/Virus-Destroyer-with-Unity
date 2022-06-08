using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject GameManagerGO; //reference menuju game manager
    public GameObject PlayerBulletGO; //Player's bullet prefabs
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;
    public GameObject ExplosionGO; //ledakan player
    public Text LivesUIText; //untuk lives ui text
    const int MaxLives = 3; //nyawa max player
    int lives;
    public float speed;

    public void Init()
    {
        lives = MaxLives;

        //update the lives UI  text
        LivesUIText.text = lives.ToString();

        //Reset the Player Position to  the center of the screen
        transform.position = new Vector2 (0, 0);

        //mengatur player game object menjadi aktif
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tombol nembak dengan mencet space
        if(Input.GetKeyDown("space"))
        {
            //play the laser sound effect
            GetComponent<AudioSource>().Play();
            //instantiate pluru pertama
            GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO);
            bullet01.transform.position = bulletPosition01.transform.position; //merubah posisi peluru

            //peluru kedua
            GameObject bullet02 = (GameObject)Instantiate (PlayerBulletGO);
            bullet02.transform.position = bulletPosition02.transform.position; //merubah posisi peluru

        }
        //untuk mengatur control bisa diset di berbagai platform
        //input dari accelerometer
        float x = Input.GetAxisRaw ("Horizontal");
        float y = Input.GetAxisRaw ("Vertical");

        //bikin vektor make input  accelerometer
        Vector2 direction = new Vector2 (x, y).normalized;

        
        Move(direction);
    }

    void Move(Vector2 direction)
    {
        //batas gerakan layar untuk player (kanan,kiri,atas,bawah sudut layar)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //kiri bawah
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //atas kanan

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        //posisi normal player
        Vector2 pos = transform.position;

        //menghitung posisi palyer yang baru
        pos += direction * speed * Time.deltaTime;

        //memastikan posisi tidak di luar layar
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.x);

        //update posisi  player
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //deteksi collision dari player dengan kapal musuh, atau peluru musuh
        if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTah"))
        {
            PlayExplosion();

            lives--;//subtract one live
            LivesUIText.text = lives.ToString(); //mengupdate lives  UI text

            if (lives == 0)//if our player is dead
            {
                //mengubah game state ke game over state
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                gameObject.SetActive(false);
            }
        }
    }

    //fungsi buat  manggil ledakan
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        //mengatur posisi ledakan
        explosion.transform.position = transform.position;
    }
}