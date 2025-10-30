using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool paused = false;

    public GameObject pauseMenu;

    public AudioSource pauseAudio;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pauseAudio = GameObject.Find("PauseAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Button to toggle pause boolean
        if (Input.GetButtonDown("Cancel"))
        {
            if (paused == true)
            {
                pauseAudio.Play();
                pauseMenu.SetActive(false);
                paused = false;
            }

            else if (paused == false)
            {
                pauseAudio.Play();
                pauseMenu.SetActive(true);
                paused = true;
            }
        }
        // Pauses the game and opens the menu
        if (paused)
        {
            //pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (!paused)
        {
            //pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
