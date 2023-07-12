using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;
    private void OnTriggerEnter(Collider other)
    {
        // Did the player enter our trigger?
        if (other.CompareTag("Player"))
        {
            // If last level, load menu scene.
            if (lastLevel == true)
            {
                SceneManager.LoadScene(0);
            }
            // Otherwise load next scene.
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}