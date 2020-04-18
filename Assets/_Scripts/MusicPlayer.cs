using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioPlayer;
    public AudioClip SceneMusic;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 1f);


    }

    private void Awake() {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        Debug.Log("Music Player on: " + gameObject.name);
        if (numMusicPlayer > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }

        audioPlayer = FindObjectOfType<AudioSource>();
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        audioPlayer.PlayOneShot(SceneMusic);

     }

    void LoadFirstScene() {
        //audioPlayer.Stop();
        //SceneManager.LoadScene(1);

    }

}
