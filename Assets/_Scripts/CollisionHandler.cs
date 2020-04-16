using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    private GameObject deathFX;
    private MeshRenderer playerMesh;

    public GameObject PREFAB_DeathFX;

    // Start is called before the first frame update
    void Start() {
        
        playerMesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnTriggerEnter(Collider other) {
        SendMessage("OnPlayerDeath");
        playerMesh.enabled = false;
        deathFX = (GameObject)Instantiate(PREFAB_DeathFX, transform.position, Quaternion.identity);
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }
    private void ReloadScene() {
        SceneManager.LoadScene(1);
    }
}
