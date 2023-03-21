using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class generator : MonoBehaviour
{
    public GameObject room;
    public GameObject room2;
    public int numberOfItemsToSpawn; 
    private int orientation;
    private int lastorientation;
    private Vector2 pos;
    private List<Vector2> history = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }
    
    void Generate(){
        pos = room.transform.position;
        history.Add(pos);
        for(int i = 0; i < numberOfItemsToSpawn; i++)
        {
            orientation = Random.Range(0,4);
            if(orientation == 0){
                pos.x -= 8; 
            }
            if(orientation == 1){
                pos.y -= 8; 
            }
            if(orientation == 2){
                pos.x += 8; 
            }
            if(orientation == 3){
                pos.y += 8;   
            }
            if(!history.Contains(pos)){
                GameObject pickup = (GameObject)Instantiate(room);
                pickup.transform.position = pos;
                history.Add(pos);
            }
        }
        foreach(GameObject oobject in GameObject.FindGameObjectsWithTag("positiontracker")){
            Vector2 popsition = oobject.transform.position;
            if(!(!history.Contains(new Vector2(popsition.x-8,popsition.y)) || !history.Contains(new Vector2(popsition.x+8,popsition.y)) || !history.Contains(new Vector2(popsition.x,popsition.y-8)) || !history.Contains(new Vector2(popsition.x,popsition.y+8))) ){
                GameObject pickaup = (GameObject)Instantiate(room2);
                pickaup.transform.position = popsition;
                Destroy(oobject);
                }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
