using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadSceneAsync("Main");
    }
}
