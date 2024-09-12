using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;
    
    // Singleton instance to ensure only one AudioManager exists
    private static GameAudioManager instance;

    [SerializeField] private string sceneToDestroy = "MainMenu"; 

    private void Awake()
    {
        // Check if an instance of AudioManager already exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Make this object persistent across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy any duplicate AudioManager that gets created
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        musicSource.clip = background;
        musicSource.Play();
    }

    // Callback that is triggered when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneToDestroy)
        {
            Destroy(gameObject);  // Destroy AudioManager when the specified scene is loaded
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Unsubscribe from the event to avoid memory leaks
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
