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

        string[] responses = { "test", "test2", "test3" };

        foreach (string response in responses)
{
            string tallResponse = response.ToUpper();

            foreach (char a in tallResponse) {
                //DoSomethingWith a
            }
        }
    }

    void LoadFirstScene() {
        Debug.Log("Loading Scene");
        SceneManager.LoadScene(1);

    }

}
