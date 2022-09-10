using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StateMachine stateMachine;
    public SceneLoader Loader;

    // public GameManager() {
    //     if (!instance) instance = this;
    //     return instance;
    // }

    public void Awake() {
        if (!instance) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Quit() {
        Application.Quit();
    }

    public void Play() {
        // Start the game (level 01)
        Loader.Load(SceneLoader.Scenes.level01);
    }

    public void Stop() {
        // Stop the game
    }

    public void Menu() {
        // Load menu scene
        Loader.Load(SceneLoader.Scenes.menu);
    }

}
