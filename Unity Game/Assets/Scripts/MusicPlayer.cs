using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] _songs;
    [Range(0f, 1f)]
    public float _volume = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_songs.Length > 0 && !_audioSource.isPlaying)
        {
            ChangeSong(Random.Range(0, _songs.Length));
        }
    }

    private void Update()
    {
        _audioSource.volume = _volume;

        if (_songs.Length > 0 && !_audioSource.isPlaying)
        {
            ChangeSong(Random.Range(0, _songs.Length));
        }
    }

    public void ChangeSong(int songPicked)
    {
        _audioSource.clip = _songs[songPicked];
        _audioSource.Play();
    }
}
