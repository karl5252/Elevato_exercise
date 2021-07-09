using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InterfaceLayout : MonoBehaviour
{
    /// <summary>
    /// ekran z trzema przyciskami
    /// 1. otwiera popup z tekstem oraz guzikiem do zamkniecia
    /// 2. pokazuje tekst na 3 sek
    /// 3. odtwarza dzwiek
    /// 
    /// Do umieszcenia na obiekcie Main Camera
    /// </summary>
    
    public GameObject musicEmitter; //trzeba dodac pusty
    private AudioSource audioSource;
    //AudioClip musicTrack;

    public bool popUpBoxAppear = false;
    public bool popUpText = false;
    public bool playMusic = false;

    private void Awake()
    {

        audioSource = musicEmitter.GetComponent<AudioSource>();
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width /2-60,80,200,100), "Elevato Test Exercise");
        
        if (GUI.Button(new Rect(Screen.width / 2 - 40, 35, 100, 25), "Open popUp"))
        {
            popUpBoxAppear = true; 

        }
        if (GUI.Button(new Rect(Screen.width / 2 - 40, 70, 150, 25), "Please don`t touch"))
        {
            popUpText = true;
            StartCoroutine(HideTextCoroutine());
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 40, 105, 100, 25), "Play music"))
        {
            playMusic = true;

        }

        if (popUpBoxAppear == true)
        {
            GUI.Box(new Rect(Screen.width / 2 + 65, 30, 200, 75), "Hello I am your popUp box!");
            if (GUI.Button(new Rect(Screen.width / 2 + 65, 70, 100, 25), "Close popUp"))
            {
                popUpBoxAppear = false;

            }
        }

        if (popUpText == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 40, 0, 350, 50), "CONTENT CURRENTLY UNAVAILABLE!");

        }
        IEnumerator HideTextCoroutine() 
        {
            yield return new WaitForSeconds(3.0f);
            popUpText = false;

        }

        if (playMusic == true)
        {
            audioSource.Play();
        }
    }

}
