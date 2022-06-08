using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MateriButton : MonoBehaviour
{
    public void mainmenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void materi()
    {
        SceneManager.LoadScene("Materi");
    }

    public void materi2()
    {
        SceneManager.LoadScene("Materi_1");
    }

    public void materi3()
    {
        SceneManager.LoadScene("Materi_2");
    }


}
