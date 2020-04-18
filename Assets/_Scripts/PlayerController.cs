using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float speed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;

    [Header("Screen Position")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control Throw Based")]
    [SerializeField] float controlRollFactor = -10f;
    [SerializeField] float controlPitchFactor = -20f;

    private ParticleSystem[] guns;
    private ScoreBoard scoreBoard;

    float xThrow, yThrow;
    bool isControlEnabled = true;
    bool isFiring = false;
    private int missiles = 5;

    // Use this for initialization
    void Start() {
        guns = transform.GetComponentsInChildren<ParticleSystem>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        scoreBoard.ChangeMissiles(missiles);

    }

    // Update is called once per frame
    void Update() {
        if (isControlEnabled) {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessRotation() {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation() {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessFiring() {
        if (Input.GetButton("Fire1")) {
            EnableGuns();
        } else {
            DisableGuns();
        }

        if (Input.GetButtonDown("Fire2")) {
            AttemptMissileFire();
        }
    }

    private void EnableGuns() {
        isFiring = true;
        foreach (ParticleSystem gun in guns) {
            gun.gameObject.SetActive(true);
        }
    }

    private void DisableGuns() {
        isFiring = false;
        foreach (ParticleSystem gun in guns) {
            gun.gameObject.SetActive(false);
        }
    }

    private void AttemptMissileFire() {
        if (missiles < 0) return;   //If no missiles then don't fire

        //Spawn missile 
        //Update scoreboard
        missiles--;
        scoreBoard.ChangeMissiles(missiles);
    }

    private void OnPlayerDeath() {
        isControlEnabled = false;
        
    }

}