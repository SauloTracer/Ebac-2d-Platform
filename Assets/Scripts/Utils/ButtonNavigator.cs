using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNavigator : MonoBehaviour
{

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.instance;      
    }

    public void Menu() {
        _gameManager.stateMachine.Menu();
    }

    public void Play() {
        _gameManager.stateMachine.Play();
    }

}
