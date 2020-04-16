using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject deathFX;
    public GameObject PREFAB_DeathFX;

    void Start() {
        
        CreateParts();

    }

    private void CreateParts() {
        Collider newCollider = gameObject.AddComponent<BoxCollider>();
        newCollider.isTrigger = false;
        
    }

    void Update() {
        
    }

    private void OnParticleCollision(GameObject other) {
        deathFX = (GameObject)Instantiate(PREFAB_DeathFX, transform.position, Quaternion.identity);
        deathFX.SetActive(true);
        Destroy(gameObject, 1f);            //Destroy Enemy
    }

}
