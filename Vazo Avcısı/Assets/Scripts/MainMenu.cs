using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip sound;
    public GameObject ınfoBtn;
    private bool isOn = true;

    public void PlayGameToButton(){
        StartCoroutine(PlayGame());
    }
    IEnumerator PlayGame(){
        GetComponent<AudioSource>().PlayOneShot(sound);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame(){
        GetComponent<AudioSource>().PlayOneShot(sound);
        Debug.Log("Oyundan Çıktık!");
        Application.Quit();
    }

    public void ButtonClicked()
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
        if (isOn)
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
            ınfoBtn.SetActive(true);
            isOn = false;
            
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
            ınfoBtn.SetActive(false);
            isOn = true;
            

        }

    }
}
