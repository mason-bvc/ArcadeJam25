using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Transform Player;
    public Object CurrentRoot;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        DoTitle();
    }

    private void DoTitle()
    {
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
        SceneManager.LoadScene("Lucas/Scenes/CarScene");
    }
}
