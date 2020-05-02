using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("ChangeToScene", 2f);
    }


    void ChangeToScene()
    {
        SceneManager.LoadScene(1);
    }
}
