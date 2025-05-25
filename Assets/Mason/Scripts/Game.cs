using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static AudioClip IngameMusic { get; private set; }
    public static AudioClip LoseMusic { get; private set; }
    public static AudioClip TitleMusic { get; private set; }

    private bool _isIngame;
    private bool _isPaused;
    private AudioSource _musicAudioSource;
    private Object _sadRoll;

    public Transform Player;
    public Object CurrentRoot;
    public AudioClip CurrentMusic;

    public static void CacheResources()
    {
        IngameMusic = Resources.Load<AudioClip>("Mason/Audio/woo");
        LoseMusic = Resources.Load<AudioClip>("Mason/Audio/sad");
        TitleMusic = Resources.Load<AudioClip>("Mason/Audio/title");
    }

    public void Awake()
    {
        CacheResources();
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        _musicAudioSource = GetComponent<AudioSource>();
        // DoTitle();
        StartCoroutine("DoGameOver");
    }

    public void Update()
    {
        if (_isIngame)
        {
            var keyboard = Keyboard.current;

            if (keyboard.escapeKey.wasPressedThisFrame)
            {
                _isPaused = !_isPaused;
            }

            Time.timeScale = 1;

            if (_isPaused)
            {
                Time.timeScale = 0;
            }
        }
    }

    private void DoTitle()
    {
        _isIngame = false;

        _musicAudioSource.clip = TitleMusic;
        _musicAudioSource.Play();

        var titleObj = Resources.Load("Mason/Prefabs/Title");

        CurrentRoot = Instantiate(titleObj);

        Title title = CurrentRoot.GetComponent<Title>();

        title.PressedStart.AddListener(() =>
        {
            DoGame();
            Destroy(CurrentRoot);
        });

        title.PressedQuit.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void DoGame()
    {
        _isIngame = true;
        _musicAudioSource.clip = IngameMusic;
        _musicAudioSource.Play();
        SceneManager.LoadScene("Lucas/Scenes/CarScene");
    }

    private IEnumerator DoGameOver()
    {
        var creditsObj = Resources.Load("Mason/Prefabs/LoseRoll");

        _sadRoll = Instantiate(creditsObj);

        yield return new WaitForSeconds(1);

        _musicAudioSource.clip = LoseMusic;
        _musicAudioSource.Play();

        yield return new WaitForSeconds(15);

        Destroy(_sadRoll);
        DoTitle();
    }
}
