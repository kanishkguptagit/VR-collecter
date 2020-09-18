using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballGrab : MonoBehaviour
{
    public GameObject ball;
    public GameObject myHand;
    public GameObject trophy;

    public int force = 1;
    int hitCount;
        
    private bool inHand;
    private bool coll;
    Rigidbody rb;
    Collider ballcollider;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {        
        inHand = false;        
        coll = false;
        rb = GetComponent<Rigidbody>();
        ballcollider = GetComponent<SphereCollider>();
        hitCount = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        if (inHand && Input.GetKeyDown(KeyCode.Space))
        {
            ball.transform.SetParent(null);
            rb.velocity = Camera.main.transform.rotation *Vector3.forward* force;
            inHand = false;
            coll = false;
            rb.useGravity = true;
            ballcollider.isTrigger = false;
        }
        if(inHand)
        {
            ball.transform.position = myHand.transform.position;
        }
        if(hitCount==5)
        {
            trophy.SetActive(true);
            hitCount = 0;
            text.gameObject.SetActive(true);
        }
    }
    public void OnInteractionSphere()
    {
        if(coll == true)
        {
            ball.transform.SetParent(myHand.transform);
            ball.transform.position = myHand.transform.position;
            inHand = true;
            ballcollider.isTrigger = true;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hands"))
        {
            coll = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("hit"))
        {
            collision.gameObject.SetActive(false);
            hitCount++;
        }
    }
}
