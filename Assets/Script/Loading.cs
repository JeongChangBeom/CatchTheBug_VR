using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] float setTime = 4.0f;
    [SerializeField] Text Timetext;
    [SerializeField] GameObject Starttext;
    
    void Start()
    {
        Timetext.text = setTime.ToString();
        Starttext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        setTime -= Time.deltaTime;
        if (setTime < 4 && setTime >= 1)
        {
            Timetext.text = (int)setTime + "";
        }
        if (setTime < 1 && setTime > 0)
        {
            Destroy(Timetext);
            Starttext.SetActive(true);
        }
        if (setTime <= 0)
        {
            Invoke("nextScene", 0);
        }
    }

    void nextScene()
    {
        Scene scene = SceneManager.GetActiveScene();

        int curscene = scene.buildIndex;

        int nextScene = curscene + 1;

        SceneManager.LoadScene(nextScene);
    }
}
