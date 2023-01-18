using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    public GameObject fullView;
    public GameObject background;
    public Material colored;

    SpriteRenderer bgRender;
    GameObject mainCam;

    private void Awake() 
    {
        bgRender = background.GetComponent<SpriteRenderer>();
        mainCam = GameObject.FindWithTag("MainCamera");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            fullView.SetActive(true);
            //background.GetComponent<SpriteRenderer>().material = colored;
            bgRender.material = colored;
            //GameObject.FindWithTag("MainCamera").SetActive(false);
            mainCam.SetActive(false);
        }
    }
}
