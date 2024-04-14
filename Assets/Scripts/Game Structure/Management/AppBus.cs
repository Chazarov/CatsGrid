using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppBus : MonoBehaviour
{
    [SerializeField] GameObject _startMenuCanvas;
    [SerializeField] GameObject _gridCanvas;
    [SerializeField] IntInput _gridSizeInput;

    [SerializeField] Initializer _initializer;

    private void OnEnable()
    {
        Buttons.StartButtonPush += GoGridItem;
        Buttons.ReloadButtonPush += ReloadApp;
    }
    void Start()
    {
        goStartMenuItem();
    }
    private void GoGridItem()
    {
        goGridItem();
    }
    
    private void ReloadApp()
    {
        SceneManager.LoadScene(0);  
    }
    private void OnDisable()
    {
        Buttons.StartButtonPush -= GoGridItem;
        Buttons.ReloadButtonPush -= ReloadApp;
    }

    private void goStartMenuItem()
    {
        _startMenuCanvas.SetActive(true);
        _gridCanvas.SetActive(false);
    }

    private void goGridItem()
    {
        _startMenuCanvas.SetActive(false);

        _initializer.CreateGrid(_gridSizeInput.value);

        _gridCanvas.SetActive(true);

    }


}
