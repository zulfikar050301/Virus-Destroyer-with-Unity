using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //reference ke  game objects
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner; //reference ke enemy spawner
    public GameObject GameOverGO;  //reference  ke game over
    public GameObject scoreUITextGO; //reference ke score text ui game object
    public GameObject TimeCounterGO; //reference ke time  counter object
    public GameObject GameTitleGO; //reference ke judul game
    public GameObject LogoBiospin; //reference ke logo biospin 
    public GameObject exitButton; //reference ke tombol exit
    public GameObject materiButton; //referenece ke tombolmateri 
    public GameObject BgMainMenu; //reference kle bg mainmenu
    public GameObject BgGameplay; //reference ke bg gamplay

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                //display bg main menu
                BgMainMenu.SetActive(true);
                //hide bggampley
                BgGameplay.SetActive(false);
                //display exit button
                exitButton.SetActive(true);
                //display materi button
                materiButton.SetActive(true);
                //display logo biospin
                LogoBiospin.SetActive(true);
                //display game title
                GameTitleGO.SetActive(true);
                //Hide Game over
                GameOverGO.SetActive(false);
                //Set play button visible (active)
                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:
                //display bg main menu
                BgMainMenu.SetActive(false);
                //hide bggampley
                BgGameplay.SetActive(true);
                //hide exit button
                exitButton.SetActive(false);
                //hide materi button
                materiButton.SetActive(false);
                //Reset score
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                //hide title
                GameTitleGO.SetActive(false);
                //hide logo
                LogoBiospin.SetActive(false);
                //menyembunyikan tombol play ketika dimainkan
                playButton.SetActive(false);
                //men set visible player dan init nyawa player
                playerShip.GetComponent<PlayerControl>().Init();

                //mulai manggil musuh
                enemySpawner.GetComponent<EnemySpawnerGO>().ScheduleEnemySpawner();
                //mulai time encounter
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();

                break;
            case GameManagerState.GameOver:
                //stop  timeencounter
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();

                //Stop memanggil musuh ketika mati
                enemySpawner.GetComponent<EnemySpawnerGO>().UnScheduleEnemySpawner();
                //Display Game Over
                GameOverGO.SetActive(true);
                //Merubah Game Manager State ke Opening State setelah 7 detik
                Invoke("ChangeToOpeningState", 7f);

                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //Tombol Play Button akan memanggil  fungsi ini ketika user mengklik tombol play
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState ();
    }

    //fungsi untukmerubah ke opening
    public void ChangeToOpeningState(){
        SetGameManagerState (GameManagerState.Opening);
    }
}


