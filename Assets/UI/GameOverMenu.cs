using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public GameObject MenuUI;
    public Text score;

    public bool menuEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        MenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Helper.gameOver && !menuEnabled){
            EnableMenu();
        }
    }


    void EnableMenu(){
        menuEnabled = true;
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        score.text = Helper.score.ToString();
    }

    void DisableMenu(){
        Helper.gameOver = false;
        Helper.score = 0;
        Helper.super = false;
        Time.timeScale = 1f;
        menuEnabled = false;
        MenuUI.SetActive(false);
    }

    public void Retry(){      
        DisableMenu();
        StartCoroutine(goToScene("Game"));
    }
 
    public void MainMenu(){
        DisableMenu();
        StartCoroutine(goToScene("Menu"));       
    }

    IEnumerator goToScene(string scene){
        yield return new WaitForSeconds(0f);
        SceneManager.LoadSceneAsync(scene);
    }
}
