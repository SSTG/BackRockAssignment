using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [SerializeField]LayerMask wallLayer;
    [SerializeField]float speed=10f;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=transform.forward*speed;
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(Physics.RayCast(transform.position,-transform.right,wallLayer))
            //Turn Left
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(Physics.RayCast(transform.position,transform.right,wallLayer))
            //Turn Right
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Pellet")){
        ScoreManager.Instance.score+=1;
        other.gameObject.SetActive(false);
    }
}}
