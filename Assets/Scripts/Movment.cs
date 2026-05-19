using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public float yValue;
    public float zValue;
    public AudioClip burst;
    AudioSource audioSource;
    Rigidbody body;
    public ParticleSystem engineParticles, rightJetParticles, leftJetParticles;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Flying();
        Rotating();
    }

    //-----------------------------------------------------------------------------
    void Flying()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Fly();
        }
        else
        {
            StopFlying();
        }
    }

    void Fly()
    {
        body.AddRelativeForce(0, yValue * Time.deltaTime, 0);
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(burst);
        Particlescontroller(engineParticles);
    }
    
    void StopFlying()
    {
        audioSource.Stop();
        engineParticles.Stop();
    }
    //-----------------------------------------------------------------------------
    
    //-----------------------------------------------------------------------------
    void Rotating()
    {
        
        if(Input.GetKey(KeyCode.A))
        {
            RotatingLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotatingRight();
        }
        else
        {
            StopRotating();
        }
    }
    
    void RotatingLeft()
    {
        Rotative(zValue);
        Particlescontroller(rightJetParticles);
    }

    void RotatingRight()
    {
        Rotative(-zValue);
        Particlescontroller(leftJetParticles);
    }

    void StopRotating()
    {
        rightJetParticles.Stop();
        leftJetParticles.Stop();
    }
    
    void Rotative(float r)
    {
        body.freezeRotation = true;
        transform.Rotate(Vector3.forward * r * Time.deltaTime);
        body.freezeRotation = false;
    } 
    
    void Particlescontroller(ParticleSystem particles)
    {
        if(!particles.isPlaying)
            particles.Play();
    }
    //-----------------------------------------------------------------------------
}
