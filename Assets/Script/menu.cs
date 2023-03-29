using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    private void Start()
    {
        DebugUIBuilder.instance.AddButton("Start!", StartButtonPressed);

        DebugUIBuilder.instance.Show();
    }
    public void StartButtonPressed()
    {
        Debug.Log("Start Button Pressed");
        SceneManager.LoadScene("loading01");
    }
}
