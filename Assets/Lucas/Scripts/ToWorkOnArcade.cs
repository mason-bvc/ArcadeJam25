using UnityEngine;
using UnityEngine.InputSystem;

public class ToWorkOnArcade : MonoBehaviour
{
    private float idleTime = 180f;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        idleTime -= Time.deltaTime;
        if (idleTime < 0)
        {
            Application.Quit();
        }
    }

    private void OnBl_1(InputValue input)
    {
        Debug.Log("Done");
        if (input.isPressed)
        {
            idleTime = 180f;
        }
    }

    private void OnExit_Button(InputValue input)
    {
        Debug.Log("Done");
        if (input.isPressed)
        {
            Application.Quit();
        }
    }

    private void OnBl_Stick(InputValue input)
    {
        idleTime = 180f;
    }

    private void OnRe_Stick(InputValue input)
    {
        idleTime = 180f;
    }
}
