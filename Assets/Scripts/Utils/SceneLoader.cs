using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum Scenes
    {
        menu,
        level01
    }

    public Dictionary<Scenes, int> scenesDictionary;

    public void Start() {

    }

    public void Load(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Load(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
