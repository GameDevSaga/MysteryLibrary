using UnityEngine;

public class MusicControllerScript : MonoBehaviour
{
    public GameManager myGM;


    void Start()
    {
        myGM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {

    }

    public void Book1()
    {
        myGM.inFirstBook = true;
    }

}