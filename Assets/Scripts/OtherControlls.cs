using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherControlls : MonoBehaviour
{
    int currentLevel;
    bool ok;
    BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        NextLevel();
        StopCollision();
    }
//----------------------------------------------------------------
    void NextLevel()
    { 
        if(Input.GetKeyDown(KeyCode.L))
        {
            if(currentLevel + 1 == SceneManager.sceneCountInBuildSettings)
            {
                currentLevel = 0;
                SceneManager.LoadScene(currentLevel);
            }
            else
                SceneManager.LoadScene(++currentLevel);
        }
    }
//----------------------------------------------------------------
    void StopCollision()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(!ok)
            {
                collider.enabled = false;
                 ok = !ok;
            }
            else
            {
                collider.enabled = true;
                ok = !ok; 
            }
                
        }
    }
//----------------------------------------------------------------
}
