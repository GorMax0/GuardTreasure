using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButton;
    [SerializeField] private Button _paremetersButton;
    [SerializeField] private Button _shopButton;

    private void OnEnable()
    {
        _spawner.AllEnemyDead += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemyDead -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    public void OnAllEnemySpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    public void OnNextWaveButtonClick()
    {
        _spawner.NextWave();
        _nextWaveButton.gameObject.SetActive(false);
        _paremetersButton.interactable = false;
        _shopButton.interactable = false;
    }
}
