using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePellet : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pellet"))
        other.gameObject.SetActive(false);
    }
}
