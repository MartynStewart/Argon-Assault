using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ScoreValue = 2000;
    public GameObject PREFAB_DeathFX;
    private bool isDead = false;
    private ScoreBoard scoreBoard;

    public int maxHits = 3;

    void Start() {

        scoreBoard = FindObjectOfType<ScoreBoard>();
        CreateParts();

    }

    private void CreateParts() {
        Collider newCollider = gameObject.AddComponent<BoxCollider>();
        newCollider.isTrigger = false;
        
    }

    void Update() {
        
    }

    private void OnParticleCollision(GameObject other) {
        if (!isDead) {
            maxHits--;
            Debug.Log("I've been hit, remaining hits: " + maxHits);
            if(maxHits<=0) EnemyKilled();
        }
    }

    private void EnemyKilled() {
        isDead = true;
        scoreBoard.IncrementScore(ScoreValue);
        GameObject deathFX = (GameObject)Instantiate(PREFAB_DeathFX, transform.position, Quaternion.identity);
        deathFX.transform.parent = GameObject.Find("SpawnedAtRunTime").transform;
        deathFX.SetActive(true);
        Destroy(gameObject, 1f);            //Destroy Enemy
    }
}
