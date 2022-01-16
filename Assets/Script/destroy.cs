using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x>39.98 && gameObject.CompareTag("Obstacle")&& gameObject.CompareTag("Coin"))
        {
            Destroy(gameObject);
        }
    }
}
