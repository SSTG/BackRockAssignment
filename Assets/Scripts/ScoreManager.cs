using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score=0;
    public Text text;
    public static ScoreManager _Instance=null;
    public static ScoreManager Instance{
    get{
        if(_Instance==null)
        _Instance=FindObjectOfType<ScoreManager>();
        return _Instance;
    }
    }

    // Update is called once per frame
    void Update()
    {
        text.text=score.ToString();
    }
}
