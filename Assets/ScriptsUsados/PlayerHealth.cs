﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerHealth : MonoBehaviour {



    public int startingHealth = 100;
    public int currentHealth;
    //public Slider healthSlider;
    //public Image damageImage;
    //public AudioClip deathClip;
    //public float flashSpeed = 5f;
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    //public AudioClip hurtSound;

    ThirdPersonController controller;
    ThirdPersonControl control;
    Animator anim;
    AudioSource playerAudio;
    PlayerShooting playerShooting;
    PlayerStabing playerStabing;
    bool isDead;
    bool damaged;



	void Awake () {
        anim = GetComponent<Animator>();
        // playerAudio = GetComponent<AudioSource>();
        control = GetComponent<ThirdPersonControl>();
        controller = GetComponent<ThirdPersonController>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        playerStabing = GetComponentInChildren<PlayerStabing>();
        currentHealth = startingHealth;	
	}
	
	// Update is called once per frame
	void Update () {
        //En el caso de tomar alguna potion
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        else
        {
            if ( damaged )
            {
                //damageImage.color = flashColour;
            }
            else
            {
               // damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            damaged = false;
        }


        if ( currentHealth <= 0 && !isDead) {
            Death();
        }

       
	} 

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;

       // healthSlider.value = currentHealth;
       // playerAudio.clip = hurtSound;
       // playerAudio.Play();
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects();
        //playerStabing.DisableEffectsSkill();
        controller.enabled = false;
        control.enabled = false;
        anim.SetTrigger("Death");

       // playerAudio.clip = deathClip;
       // playerAudio.Play();

       
        playerShooting.enabled = false;
        playerStabing.enabled = false;

    }





}