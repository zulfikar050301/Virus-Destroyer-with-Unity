using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    Text timeUI; //reference untuk time counter text
    float startTime; //waktu jalan ketika  user nge play
    float ellapsedTime;//ellpase time setelah klik play
    bool startCounter; //flag to start the counter

    int minutes;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        startCounter = false;

        //get tect ui component dari gameobject
        timeUI = GetComponent<Text> ();
    }

    //fungsi buat mulai  time encounter
    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }

    public void StopTimeCounter()
    {
        startCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startCounter)
        {
            //komputasikan ellapsed time
            ellapsedTime = Time.time - startTime;

            minutes = (int)ellapsedTime / 60; //untuk menit
            seconds = (int)ellapsedTime % 60; //untuk detik

            //menguodate time counter di ui text
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
