using UnityEngine;
using System.Collections;

public class MusicPlayerScript : MonoBehaviour
{
    [System.Serializable]
    public class MusicTrack
    {
        public string name;
        public AudioClip clip;
    }

    public MusicTrack[] musicTracks;
    public AudioSource audioSource;

    [Header("Fade Settings")]
    public float fadeOutDuration = 1.5f;
    public float fadeInDuration = 1.5f;

    private int currentTrack = 0;
    private Coroutine fadeCoroutine;
    private float targetVolume = 1f;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.loop = true; // Looppaa nykyinen kappale
        targetVolume = audioSource.volume;

        if (musicTracks.Length > 0)
        {
            PlayTrackImmediate(0);
        }
    }

    // Soita kappale heti ilman fadea
    public void PlayTrackImmediate(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            currentTrack = trackIndex;
            audioSource.clip = musicTracks[trackIndex].clip;
            audioSource.volume = targetVolume;
            audioSource.Play();
        }
    }

    // Soita kappale fadella
    public void PlayTrackWithFade(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }
            fadeCoroutine = StartCoroutine(FadeToTrack(trackIndex));
        }
    }

    // Soita kappale nimen perusteella
    public void PlayTrackByName(string trackName)
    {
        for (int i = 0; i < musicTracks.Length; i++)
        {
            if (musicTracks[i].name == trackName)
            {
                PlayTrackWithFade(i);
                return;
            }
        }
        Debug.LogWarning($"Kappaletta nimellä '{trackName}' ei löytynyt!");
    }

    // Fade nykyisestä kappaleesta uuteen
    private IEnumerator FadeToTrack(int newTrackIndex)
    {
        // Fade out
        float startVolume = audioSource.volume;
        float elapsed = 0f;

        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / fadeOutDuration);
            yield return null;
        }

        audioSource.volume = 0f;

        // Vaihda kappale
        currentTrack = newTrackIndex;
        audioSource.clip = musicTracks[newTrackIndex].clip;
        audioSource.Play();

        // Fade in
        elapsed = 0f;
        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, targetVolume, elapsed / fadeInDuration);
            yield return null;
        }

        audioSource.volume = targetVolume;
        fadeCoroutine = null;
    }

    public void SetVolume(float volume)
    {
        targetVolume = Mathf.Clamp01(volume);
        if (fadeCoroutine == null) // Älä muuta äänenvoimakkuutta faden aikana
        {
            audioSource.volume = targetVolume;
        }
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void Resume()
    {
        audioSource.UnPause();
    }
}