using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tcube : MonoBehaviour{
	float selectScale = .3f;
    void Start()
    {   
    }
    void Update()
    {   
		
    }
    public void OnMouseEnter() {
		this.transform.localScale += new Vector3(selectScale,selectScale,selectScale);
	}
	public void OnMouseExit() {
		this.transform.localScale -= new Vector3(selectScale,selectScale,selectScale);
        this.transform.rotation= Quaternion.Euler(0,0,0);
	}
	public void OnMouseOver() {
		
		this.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);
	}
}
