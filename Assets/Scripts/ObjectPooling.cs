using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private List<GameObject> pelletPrefabs=new List<GameObject>();
    public LayerMask whatIsGround;
    private int pelletCount=25;
    public int pelletThreshold=2;
    private Transform player;
    [SerializeField]private Transform[] pelletSpawns;
    [SerializeField]GameObject pelletPrefab;
    public static ObjectPooling instance;
    Vector3 currentDir=new Vector3(0,0,0);
    public static ObjectPooling Instance{
        get{
            if(instance==null)
            instance=FindObjectOfType<ObjectPooling>();
    return instance;
        }
    }
    void Start()
    {
       

    
        for(int i=0;i<pelletCount;i++)
        {
            GameObject p=Instantiate(pelletPrefab,this.transform.position,Quaternion.identity);
            pelletPrefabs.Add(p);
            p.SetActive(false);
            

        }
    }
    void Update()
    {
        player=GameObject.FindWithTag("Player").transform;
        currentDir=player.GetComponent<PlayerController>().direction.normalized;
    }
         
    public IEnumerator ScatterPellets()
    {
       
        for(int i=0;i<pelletThreshold;i++)
        {
            
            if(!pelletPrefabs[i].activeInHierarchy){
            pelletPrefabs[i].SetActive(true);
            pelletPrefabs[i].transform.position=RandomPos();

            
             
            yield return new WaitForSeconds(2f);//time before next pellet spawn
            
        }
    }}
    public Vector3 RandomPos()
    {
        Vector3 randomPos=pelletSpawns[Random.Range(0,pelletSpawns.Length)].position+currentDir*Random.Range(5f,-5f);
        if(Physics.Raycast(randomPos,-Vector3.up,whatIsGround))
        return randomPos;
        else
        return RandomPos();
    }
  

}
