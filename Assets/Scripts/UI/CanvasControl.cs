using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    [SerializeField] Spawner _spawner;
    [SerializeField] private Button _paremetersButton;
    [SerializeField] private Button _shopButton;

    private void OnEnable()
    {
        _spawner.AllEnemyDead += EnableButton;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void EnableButton()
    {
        _paremetersButton.interactable = true;
        _shopButton.interactable = true;
    }
}
