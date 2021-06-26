using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour{
    // Start is called before the first frame update
    public Color activate;
    public Color deactivate;

    public GameObject can;
    public GameObject ths,that;

    public GameObject yellow;
    public GameObject blue;
    public GameObject green;
    public GameObject red;
    public Text Player1;
    public Text Player2;
    public Text count;
    Transform ob;
    	float selectScale = .3f;

    public AudioSource C,D,E,F,Er;
    List<string> past= new List<string>();
    int cnt =1;
    int i=0;
    int p1_score=0;
    int p2_score=0;
    bool game_is_over=false;
    bool is_player_1=true;
    bool is_player_2=false;
    bool paused=false;
    void reset(){
      cnt=1;
      count.text=""+cnt;
    }
    void update(){
      count.text=""+cnt;
    }
    void Start()
    {
      can.SetActive(false);
      paused=false;
      Player1.fontSize=(30);
      reset();

    }

    // Update is called once per frame
    void Update(){
      update();
      if (Input.GetKeyDown ("escape")) {
            if(paused){
              paused=false;
              can.SetActive(paused);
            }
            else{
              paused=true;
              can.SetActive(paused);
            }

    }
      if(!game_is_over){
        if(Input.GetMouseButtonUp(0)){
          RaycastHit hit;
          if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit)){
            if(hit.collider.name!="Plane"){
              paused=false;
            }
            if(hit.collider.name=="Red"){
              C.Play();
            }
            else if(hit.collider.name=="Green"){
              D.Play();
            }
            else if(hit.collider.name=="Blue"){
              F.Play();
            }
            else if(hit.collider.name=="Yellow"){
              E.Play();
            }
            else if(hit.collider.name=="Plane"){
              return;
            }
            


            if(i == past.Count){
              cnt=past.Count+2;
              past.Add(hit.collider.name);
              is_player_1 = !is_player_1;
              is_player_2 = !is_player_2;
              if(is_player_1){
                Player1.fontSize=(30);                
                Player1.color=activate;
                Player2.color=deactivate;
                Player2.fontSize=(15);
              }
              else{
                Player1.fontSize=(15);
                Player2.fontSize=(30);
                Player1.color=deactivate;
                Player2.color=activate;
              }
              i=0;
            }
            else{

              Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"+i);

              if(hit.collider.name != past[i]&& hit.collider.name!="Plane"){
                 Debug.Log("Got Here");
                 Er.Play();
                 reset();
                if(is_player_1)
                  p2_score++;
                else
                  p1_score++;
                Player1.text = "Player1 : "+p1_score;
                Player2.text = "Player2 : "+p2_score;
                is_player_1 = true;
                is_player_2 = false;
                Player1.fontSize=(30);
                Player1.color=activate;
                Player2.color=deactivate;
                Player2.fontSize=(15);
                i=0;
                past =  new List<string>();
                

                
                ths.SetActive(true);
                that.SetActive(true);
              }
              else{
                Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                i++;
                cnt--;
              }
            }

          }

        }
      }
    }
}