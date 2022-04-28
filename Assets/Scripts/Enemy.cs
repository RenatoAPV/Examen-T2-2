using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int cont1 = 0;
    private int cont2 = 0;
    private int cont3 = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        Debug.Log(tag);
        
        if (tag == "Bal1")
        {
            cont1++;
            if (cont1 == 5)
            {
                Destroy(this.gameObject);
            }
        }
        if (tag == "Bal2")
        {
            cont2++;
            if (cont2 == 3)
            {
                Destroy(this.gameObject);
            }
        }
        if (tag == "Bal3")
        {
            cont3++;
            if (cont3 == 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
