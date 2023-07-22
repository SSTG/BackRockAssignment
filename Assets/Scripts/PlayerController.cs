using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [SerializeField]LayerMask wallLayer;
    [SerializeField]float speed=10f;
    public Vector3 direction=Vector3.forward;
    
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=speed*direction;
        if(Input.GetKey(KeyCode.A))
        {
            if(!Physics.Raycast(this.transform.position,-Vector3.right,3f,wallLayer))
           direction=-Vector3.right;
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(!Physics.Raycast(this.transform.position,Vector3.right,3f,wallLayer))
            direction=Vector3.right;
        }
        if(Input.GetKey(KeyCode.W))
        {
            if(!Physics.Raycast(this.transform.position,Vector3.forward,3f,wallLayer))
            direction=Vector3.forward;
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(!Physics.Raycast(this.transform.position,-Vector3.forward,3f,wallLayer))
            direction=-Vector3.forward;
        }
    }private void OnTriggerEnter(Collider other) {
        

        if(other.gameObject.CompareTag("Pellet")){
        ScoreManager.Instance.score+=1;
        other.gameObject.SetActive(false);
        IEnumerator coroutine=ObjectPooling.Instance.ScatterPellets();
        StartCoroutine(coroutine);
    }
}}
