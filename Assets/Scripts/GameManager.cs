using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StateMachine stateMachine;

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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
    }

    public void Stop() {
        // Stop the game
    }

    public void Menu() {
        // Load menu scene
    }

}
