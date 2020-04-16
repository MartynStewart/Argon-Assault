using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 1f);

    }

    private void Awake() {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayer > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }

     }

    void LoadFirstScene() {
        Debug.Log("Loading Scene");
        SceneManager.LoadScene(1);

    }

}
