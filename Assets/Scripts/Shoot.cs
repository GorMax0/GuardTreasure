using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Player _player;

    public void OnPointerDown(PointerEventData eventData)
    {
        _player.Shoot();
    }
}
