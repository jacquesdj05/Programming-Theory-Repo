using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    //private TextMeshProUGUI playButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
