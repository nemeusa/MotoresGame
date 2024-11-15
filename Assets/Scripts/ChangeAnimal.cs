using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimal : MonoBehaviour
{
    public GameObject Alien;
    public GameObject Rat;

    public AlienController AlienCode;
    public RatController RatCode;

    public ParticleSystem changeParticle;
    
    private void Update()
    {
        ChangePlayer();
        //changeParticle.Play();
    }

    private void ChangePlayer()
    {
        if(AlienCode.ChangeAlien)
        {
            changeParticle.Play();
            Alien.SetActive(false);
            Rat.SetActive(true);
            AlienCode.ChangeAlien = false;
        } 
        
        if(RatCode.ChangeRat)
        {
            changeParticle.Play();
            Alien.SetActive(true);
            Rat.SetActive(false);
            RatCode.ChangeRat = false;
        }
    }
}
