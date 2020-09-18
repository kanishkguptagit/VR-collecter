using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    bool statusOn;
    bool coll;
    public Image gvrImage;
    float timer=0;
    public float totalTime = 2;    
    
    // Start is called before the first frame update
    void Start()
    {
        statusOn = false;
        coll = false;
        gvrImage.fillAmount = 0;
    }
    // Update is called once per frame
    
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            transform.position = transform.position + (Camera.main.transform.forward * speed);
        }
        if (statusOn == true && coll == true)
        {
            timer += Time.fixedDeltaTime;
            gvrImage.fillAmount = timer / totalTime;
            if (gvrImage.fillAmount == 1)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
            coll = true;
    }
    public void GvrOn()
    {
        statusOn = true;
    }
    public void GvrOff()
    {
        statusOn = false;
        timer = 0;
    }
}
