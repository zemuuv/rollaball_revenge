using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    public float PocisionMinima = -30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < PocisionMinima){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }        
    }
}
