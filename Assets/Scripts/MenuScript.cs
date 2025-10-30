using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator fadeScreen;
    public float transitionTime;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<Animator>();
    }

    public void FirstLevel()
    {
        StartCoroutine(LoadLevel(1));
        //opens level 1
    }

    public void QuitGame()
    {
        Application.Quit(); //shuts down the game
    }

    public IEnumerator LoadLevel(int levelToLoad)
    {
        fadeScreen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelToLoad);
    }

}