using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PauseScript pause;
    public Animator fadeScreen;
    public float transitionTime;
    public float fadeTime;
    public MusicPlayerScript musicPlayer;
    public GameObject effects;
    public GameObject smoke1;
    public GameObject smoke2;
    public GameObject smoke3;
    public GameObject smoke4;

    public GameObject currentButton;
    public GameObject currentImage;

    public DialogueTrigger gameStartdiag;

    public GameObject bookShelf;
    public DialogueTrigger bookShelfdiag;
    public GameObject bookShelf1Button;
    public GameObject bookShelf2Button;
    public GameObject bookShelf3Button;
    public GameObject bookShelf4Button;

    public GameObject book1;
    public DialogueTrigger book1diag;
    public GameObject book1Button;

    public GameObject book2;
    public DialogueTrigger book2diag;
    public GameObject book2Button;

    public GameObject book3;
    public DialogueTrigger book3diag;
    public GameObject book3Button;

    public GameObject book4;
    public DialogueTrigger book4diag;
    public GameObject book4Button;

    public bool inFirstBook = false;
    public bool inSecondBook = false;
    public bool inThirdBook = false;
    public bool inFourthBook = false;

    public bool wasInFirstBook = false;
    private bool wasInSecondBook = false;
    private bool wasInThirdBook = false;
    private bool wasInFourthBook = false;

 

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        musicPlayer = GameObject.Find("MusicPlayer").GetComponent<MusicPlayerScript>();
        currentButton = bookShelf1Button;
        currentImage = book1;
        gameStartdiag.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        // When opening the first book
        if (inFirstBook && !wasInFirstBook)
        {
            musicPlayer.PlayTrackWithFade(1); // Play track 1
            wasInFirstBook = true;
        }
        // When Book 1 is closed
        else if (!inFirstBook && wasInFirstBook)
        {
            musicPlayer.PlayTrackWithFade(0); // Back to normal music
            wasInFirstBook = false;
            effects.SetActive(true);
        }

        // Same for Book 2
        if (inSecondBook && !wasInSecondBook)
        {
            musicPlayer.PlayTrackWithFade(2);
            wasInSecondBook = true;
        }
        else if (!inSecondBook && wasInSecondBook)
        {
            musicPlayer.PlayTrackWithFade(0);
            wasInSecondBook = false;
            effects.SetActive(true);
        }

        // Same for Book 3
        if (inThirdBook && !wasInThirdBook)
        {
            musicPlayer.PlayTrackWithFade(3);
            wasInThirdBook = true;
        }
        else if (!inThirdBook && wasInThirdBook)
        {
            musicPlayer.PlayTrackWithFade(0);
            wasInThirdBook = false;
            effects.SetActive(true);
        }

        // Same for Book 4
        if (inFourthBook && !wasInFourthBook)
        {
            musicPlayer.PlayTrackWithFade(4);
            wasInFourthBook = true;
        }
        else if (!inFourthBook && wasInFourthBook)
        {
            musicPlayer.PlayTrackWithFade(0);
            wasInFourthBook = false;
            effects.SetActive(true);
        }
    }

    public void BookShelf()
    {
        StartCoroutine(FirstShelf());
    }
    public IEnumerator FirstShelf()
    {
        smoke1.SetActive(false);
        effects.SetActive(false);
        fadeScreen.SetTrigger("TransitionFade");
        yield return new WaitForSeconds(transitionTime);
        bookShelf.SetActive(true);
        bookShelfdiag.TriggerDialogue();
        bookShelf1Button.SetActive(false);
        currentButton = book1Button;
    }
    public void Book1()
    {
        StartCoroutine(FirstBook());
    }

    public IEnumerator FirstBook()
    {
        inFirstBook = true;
        fadeScreen.SetTrigger("TransitionFade");
        yield return new WaitForSeconds(transitionTime);
        book1.SetActive(true);
        bookShelf.SetActive(false);
        book1diag.TriggerDialogue();
        book1Button.SetActive(false);
        currentButton = bookShelf2Button;
    }

    public void BookShelf2()
    {
        StartCoroutine(SecondShelf());
    }
    public IEnumerator SecondShelf()
    {
        smoke2.SetActive(false);
        effects.SetActive(false);
        fadeScreen.SetTrigger("TransitionFade");
        yield return new WaitForSeconds(transitionTime);
        bookShelf.SetActive(true);
        bookShelfdiag.TriggerDialogue();
        bookShelf2Button.SetActive(false);
        currentButton = book2Button;
        currentImage = book2;
    }

    public void Book2()
    {
        StartCoroutine(SecondBook());
    }

    public IEnumerator SecondBook()
    {
        inSecondBook = true;
        fadeScreen.SetTrigger("TransitionFade");
        yield return new WaitForSeconds(transitionTime);
        book2.SetActive(true);
        bookShelf.SetActive(false);
        book2diag.TriggerDialogue();
        book2Button.SetActive(false);
        currentButton = bookShelf3Button;
    }

    public void BookShelf3()
    {
        StartCoroutine(ThirdShelf());
    }
    public IEnumerator ThirdShelf()
    {
        smoke3.SetActive(false);
        effects.SetActive(false);
        fadeScreen.SetTrigger("TransitionFade");
        yield return new WaitForSeconds(transitionTime);
        bookShelf.SetActive(true);
        bookShelfdiag.TriggerDialogue();
        bookShelf3Button.SetActive(false);
        currentButton = book3Button;
        currentImage = book3;
    }

    public void Book3()
    {
        StartCoroutine(ThirdBook());
    }

    public IEnumerator ThirdBook()
    {
        inThirdBook = true;
        fadeScreen.SetTrigger("TransitionFade");
        yield return new WaitForSeconds(transitionTime);
        book3.SetActive(true);
        bookShelf.SetActive(false);
        book3diag.TriggerDialogue();
        book3Button.SetActive(false);
        currentButton = bookShelf4Button;
    }

    public void BookShelf4()
    {
        StartCoroutine(FourthShelf());
    }
    public IEnumerator FourthShelf()
    {
        smoke4.SetActive(false);
        effects.SetActive(false);
        fadeScreen.SetTrigger("TransitionFade");
        yield return new WaitForSeconds(transitionTime);
        bookShelf.SetActive(true);
        bookShelfdiag.TriggerDialogue();
        bookShelf4Button.SetActive(false);
        currentButton = book4Button;
        currentImage = book4;
    }
    public void Book4()
    {
        StartCoroutine(FourthBook());
    }

    public IEnumerator FourthBook()
    {
        inFourthBook = true;
        fadeScreen.SetTrigger("TransitionFade");
        yield return new WaitForSeconds(transitionTime);
        book4.SetActive(true);
        bookShelf.SetActive(false);
        book4diag.TriggerDialogue();
        book4Button.SetActive(false);
    }

    public void MenuLevel()
    {
        StartCoroutine(LoadLevel(0));
        //opens menu scene
    }

    public void UnPause()
    {
        pause.paused = false;
        //tells the pause script to unpause the game
        pause.pauseMenu.SetActive(false);
    }

    public void FirstLevel()
    {
        StartCoroutine(LoadLevel(1));
        //opens level 1
    }

    public void WinLevel()
    {
        StartCoroutine(LoadLevel(2));
        //opens win screen
    }

    public void QuitGame()
    {
        Application.Quit(); //shuts down the game
    }

    public IEnumerator LoadLevel(int levelToLoad)
    {
        pause.paused = false;
        fadeScreen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(levelToLoad);
    }

}
