using UnityEngine;

public class BuffEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _effects;

    private int _index;

    public void StartEffect(ParticleSystem buffEffect)
    {
        SetIndex(buffEffect);

        if (_effects[_index].isPlaying)
            _effects[_index].Stop();

        _effects[_index].gameObject.SetActive(true);
        _effects[_index].Play();
    }

    public void StopEffect(ParticleSystem buffEffect)
    {
        SetIndex(buffEffect);

        if (_effects[_index].isStopped)
            return;

        _effects[_index].Stop();
        _effects[_index].gameObject.SetActive(false);
    }

    private void SetIndex(ParticleSystem buffEffect)
    {
        for (int i = 0; i < _effects.Length; i++)
        {
            if (_effects[i].name == buffEffect.name)
            {
                _index = i;
                return;
            }
        }
    }
}
