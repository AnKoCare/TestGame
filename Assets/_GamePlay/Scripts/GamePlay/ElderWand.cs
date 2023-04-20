using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElderWand : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            ChangeToScene();
        }    
    }

    public void ChangeToScene()
    {
        SceneManager.LoadScene("LoseGame");
    }
}
