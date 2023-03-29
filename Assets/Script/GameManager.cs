using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance;

    private void Awake()
    {
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }


    public float setTime = 180f;
    [SerializeField] Text Timetext;
    [SerializeField] GameObject Gameovertext;
    [SerializeField] GameObject Restarttext;

    int min;
    float sec;

    

    void Start()
    {
        Timetext.text = setTime.ToString();

        Gameovertext.SetActive(false);
        Restarttext.SetActive(false);
    }

    void Update()
    {
        setTime -= Time.deltaTime;

        if (setTime >= 60f)
        {
            min = (int)setTime / 60;
            sec = setTime % 60;
            Timetext.text = "Time " + min + " : " + (int)sec;
        }

        if (setTime < 60f)
        {
            Timetext.text = "Time " + (int)setTime;
        }

        if (setTime <= 0)
        {
            setTime = 0;
            Timetext.text = "Time " + (int)setTime;
            Gameovertext.SetActive(true);
            Restarttext.SetActive(true);
            Time.timeScale = 0.0f;

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("menu");
            }
        }
    }

}
