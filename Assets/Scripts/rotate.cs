using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
	float selectScale = .3f;
    void Start()
    {
        this.transform.localScale += new Vector3(selectScale,selectScale,selectScale);
    }

    void Update()
    {
        if(this.name=="Red"||this.name=="Blue"){
            this.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);
        }
        else
        {
            this.transform.Rotate(Vector3.up, -45 * Time.deltaTime, Space.Self);
        }
    }
}
