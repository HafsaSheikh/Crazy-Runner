using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmotion : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 1)]
    public float value;
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = value;
    }
}
