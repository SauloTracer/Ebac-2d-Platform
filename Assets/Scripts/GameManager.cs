using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;

public class GameManager : Singleton<GameManager>
{
    public StateMachine stateMachine;
    public SceneLoader Loader;

    public void Awake() {
        base.Awake();
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
