using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _parametersButton;
    [SerializeField] private Button _nextWaveButton;
    [SerializeField] private Image _blockedPanel;

    private Button _startGame;

    private void Awake()
    {
        _startGame = GetComponentInChildren<Button>();
    }

    private void OnEnable()
    {
        _startGame.onClick.AddListener(StartGame);    
    }

    private void OnDisable()
    {
        _startGame.onClick.RemoveListener(StartGame);
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void StartGame()
    {
        _shopButton.interactable = false;
        _parametersButton.interactable = false;
        _nextWaveButton.gameObject.SetActive(false);
        _blockedPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
