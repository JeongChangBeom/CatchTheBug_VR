using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RayUI : MonoBehaviour
{
    public int count = 5;
    [SerializeField] Text Counttext;
    [SerializeField] GameObject Cleartext;
    [SerializeField] GameObject Nexttext;
    [SerializeField] GameObject GameOverText;



    private LineRenderer layser;        
    private RaycastHit Collided_object; 
    private GameObject currentObject;   

    public float raycastDistance = 100f;

    public AudioClip audioCatch;

    void Start()
    {
        Counttext.text = "X " + count.ToString();
        Cleartext.SetActive(false);
        Nexttext.SetActive(false);

        layser = this.gameObject.AddComponent<LineRenderer>();

        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(0, 195, 255, 0.5f);
        layser.material = material;
        layser.positionCount = 2;
        layser.startWidth = 0.01f;
        layser.endWidth = 0.01f;
    }

    void Update()
    {
        layser.SetPosition(0, transform.position); 

        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance))
        {
            layser.SetPosition(1, Collided_object.point);

            if (Collided_object.collider.gameObject.CompareTag("Bug"))
            {
                if (OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger))
                {
                    Collided_object.transform.gameObject.SetActive(false);

                    count -= 1;

                    Counttext.text = "X " + count;

                    this.gameObject.GetComponent<AudioSource>().PlayOneShot(audioCatch);

                    if (count <= 0)
                    {
                        Destroy(GameOverText);
                        Cleartext.SetActive(true);
                        Nexttext.SetActive(true);
                        Invoke("nextScene", 3);
                    }
                }

                else
                {
                    currentObject = Collided_object.collider.gameObject;
                }
            }

            if (Collided_object.collider.gameObject.CompareTag("Item"))
            {
                if (OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger))
                {
                    Collided_object.transform.gameObject.SetActive(false);

                    IItem item = Collided_object.collider.gameObject.GetComponent<IItem>();
                    if(item != null)
                    {
                        item.Use();
                    }

                    this.gameObject.GetComponent<AudioSource>().PlayOneShot(audioCatch);
                }

                else
                {
                    currentObject = Collided_object.collider.gameObject;
                }
            }
        }

        else
        {
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));

        }

    }

    private void LateUpdate()
    {      
        if (OVRInput.GetDown(OVRInput.Touch.SecondaryIndexTrigger))
        {
            layser.material.color = new Color(255, 0, 0, 0.5f);
        }
         
        else if (OVRInput.GetUp(OVRInput.Touch.SecondaryIndexTrigger))
        {
            layser.material.color = new Color(0, 195, 255, 0.5f);
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