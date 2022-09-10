using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum Scenes
    {
        menu = 0,
        level01 = 1,
    }

    public void Start() {

    }

    public void Load(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Load(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Load(Scenes scene) {
        SceneManager.LoadScene((int)scene);
    }
}
