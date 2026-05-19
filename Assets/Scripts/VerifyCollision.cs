using UnityEngine;
using UnityEngine.SceneManagement;

public class VerifyCollision : MonoBehaviour
{
//----------------------------------------------------------------
    int levelIndex;
    public float delay;
    AudioSource source;
    public AudioClip explosion, victory;
    public ParticleSystem explosionParticles, victoryParticles;
    public ParticleSystem engineParticles, rightJetParticles, leftJetParticles;
    Movment movment;
    bool  ok;
//----------------------------------------------------------------
    void Start()
    {
        explosionParticles.Stop();
        victoryParticles.Stop();
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        movment = GetComponent<Movment>();
        source = GetComponent<AudioSource>();
    }
//----------------------------------------------------------------
    void OnCollisionEnter(Collision other)
    {
        if(ok == true) { return; }

            switch(other.gameObject.tag)
            {
                case "Untagged":
                   YouDie();
                   break;
                case "Finish":
                   YouWin();
                   break;
                default:
                   ok = false;
                   break; 
            }    
    }
//----------------------------------------------------------------
    void YouDie()
    {
        StopParticlesAndAudio();
        ParticleController(explosionParticles);
        AudioController(explosion);
        movment.enabled = false;
        Invoke("ReloadLevel", delay);
    }

    void YouWin()
    {
        StopParticlesAndAudio();
        ParticleController(victoryParticles);
        AudioController(victory); 
        movment.enabled = false;
        Invoke("NextLevel", delay);
    }

    void StopParticlesAndAudio()
    {
        engineParticles.Stop();
        rightJetParticles.Stop();
        leftJetParticles.Stop(); 
        source.Stop();
    }
//----------------------------------------------------------------
   void NextLevel()
   { 
       if(levelIndex + 1 == SceneManager.sceneCountInBuildSettings)
       {
           levelIndex = 0;
           SceneManager.LoadScene(levelIndex);
       }
       else
           SceneManager.LoadScene(++levelIndex);
   }

   void ReloadLevel()
   {
       SceneManager.LoadScene(levelIndex);
   }

   void AudioController(AudioClip clip)
   {
        ok = true;
        source.Stop();
        source.PlayOneShot(clip);
   }

   void ParticleController(ParticleSystem particles)
   {
       particles.Play();
   }
//----------------------------------------------------------------
}
