using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
                        private     GameObject      deathFX;                //Holds particle gameObject created when player dies
                        private     MeshRenderer    playerMesh;             //Meshrendered so we can adjust player colour
                        private     ScoreBoard      scoreBoard;
                        private     Material        myMat;                  //Ref point for setting player colour
                        private     Color           baseColour;             //The initial colour as set by artists to reset back to

    [SerializeField]    private     float           levelLoadDelay = 1f;
                        private     int             lives = 3;              //TODO: Allow difficulty to set lives
                        private     bool            isKillable = true;
                        private     float           rekillTime;             //Stores when player will be killable again
                        private     float           zOffset;                //Player position relative to camera
                        

                        public      GameObject      PREFAB_DeathFX;         //Prefab holding particle effects for death
    [Range(0.5f, 10)]   public      float           invunTime = 2f;         //How long after respawn player remains invulnerable
    [Range(0, 10)]      public      float           flashRate = 4f;         //Rate of flashing per second
                        public      Color           invunColour;

    void Start() {
        playerMesh = GetComponent<MeshRenderer>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        myMat = GetComponent<MeshRenderer>().materials[0];
        baseColour = myMat.color;
        scoreBoard.ChangeLives(lives);
        zOffset = transform.localPosition.z;
        invunColour = invunColour * 255;
    }

    void Update(){
        if (!isKillable) CheckKillableState();
    }

    private void OnTriggerEnter(Collider other) {
        if (isKillable) {
            if (lives > 0) {
                lives--;
                scoreBoard.ChangeLives(lives);
                ResetPlayer();
            } else {
                PlayerDeath();
            }
        }
    }

    private void ResetPlayer() {
        transform.localPosition = new Vector3 (0,0,zOffset);
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        isKillable = false;
        rekillTime = Time.time + invunTime;
    }

    private void CheckKillableState() {
        if(Time.time >= rekillTime) {
            isKillable = true;
            myMat.color = baseColour;
        } else {
            int timeLeft = Mathf.FloorToInt((rekillTime - Time.time) / (1/flashRate)) % 2;
            myMat.color = timeLeft != 0 ? invunColour : baseColour;
        }
    }

    private void PlayerDeath() {
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
