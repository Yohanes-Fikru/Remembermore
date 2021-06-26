using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerMulti : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] myArray = new GameObject[4]; 
    ///////////////////////////
     public GameObject yellow;
     public GameObject blue;
     public GameObject green;
     public GameObject red;
     
     float selectScale = .3f;

    ///////////////////////////
    public Text Player1;
    public Text Player2;
    //public Text color;
    List<string> past= new List<string>();
    int i=0;
    int p1_score=0;
    int p2_score=0;
    bool game_is_over=false;
    bool is_player_1=true;
    bool is_player_2=false;
    void Start()
    {
    	Player1.fontSize=20;
        Player2.fontSize=14;
    }

    // Update is called once per frame
    void Update()
    {
      if(!game_is_over)
      {
        if(Input.GetMouseButtonUp(0))
        {
          RaycastHit hit;
          if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))
          {
            if(i == past.Count)
            {
              past.Add(hit.collider.name);
              is_player_1 = !is_player_1;
              is_player_2 = !is_player_2;
              if(is_player_1){
                Player1.fontSize=20;
                Player2.fontSize=14;}
              else{
                Player2.fontSize=20;
                Player1.fontSize=14;}
              i=0;
              if( is_player_2){
                AiPlayer();
              }     
            }
            else
            {
              if(hit.collider.name != past[i])
              {
                Debug.Log("BOOM Wrong");
                if(is_player_1)
                  p2_score++;
                else
                  p1_score++;
                Debug.Log("Player1: "+p1_score+"Player2: "+p2_score);
                is_player_1 = true;
                is_player_2 = false;
                i=0;
                past =  new List<string>();
              }
              else
              {
                i++;
              }
            }

          }

        }
      }
    }
    void AiPlayer(){
    	for(int y=0;y<past.Count;y++){
    	//		place where the blinking thing is applied
    		print(past[y]);
        if(past[y]=="Yellow"){
          yellow.transform.localScale += new Vector3(selectScale,selectScale,selectScale);
          yellow.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);
          yellow.transform.localScale -= new Vector3(selectScale,selectScale,selectScale);
          yellow.transform.rotation= Quaternion.Euler(0,0,0);
        }
    	
      else if(past[y]=="Green"){
          green.transform.localScale += new Vector3(selectScale,selectScale,selectScale);
          green.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);
          green.transform.localScale -= new Vector3(selectScale,selectScale,selectScale);
          green.transform.rotation= Quaternion.Euler(0,0,0);
        }
       else if(past[y]=="Red"){
          red.transform.localScale += new Vector3(selectScale,selectScale,selectScale);
          red.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);
          red.transform.localScale -= new Vector3(selectScale,selectScale,selectScale);
          red.transform.rotation= Quaternion.Euler(0,0,0);
        }
        else if(past[y]=="Blue"){
          blue.transform.localScale += new Vector3(selectScale,selectScale,selectScale);
          blue.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);
          blue.transform.localScale -= new Vector3(selectScale,selectScale,selectScale);
          blue.transform.rotation= Quaternion.Euler(0,0,0);
        }
    	}

    	GameObject element = myArray[Random.Range(0, myArray.Length)];
    	
    	print("----------------------------------");
    	print(element.GetComponent<Collider>().name);
      //color.()
    	print("----------------------------------");
    	past.Add(element.GetComponent<Collider>().name);

    	is_player_1 = !is_player_1;
        is_player_2 = !is_player_2;
        Player1.fontSize=20;
        Player2.fontSize=14;

    }

    /*
    yellow;
    public GameObject blue;
    public GameObject green;
    public GameObject red;*/

    // void onclick()
    // {
    //
    // }
}
