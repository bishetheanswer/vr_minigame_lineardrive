using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperBin : MonoBehaviour
{
    public Text score;
    private int aux;
    public GameObject[] objects;
    private int index;
    public GameObject endMessage;
    public GlassBin glassBin;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Glass") || other.gameObject.CompareTag("Paper"))
        {
            glassBin.usedObjects.Add(other.gameObject.name);
            glassBin.nObjects++;
            Debug.Log(glassBin.nObjects);

            //Update the score
            if (other.gameObject.CompareTag("Paper")){
                aux = int.Parse(score.text);
                aux++;
                score.text = aux.ToString();
            } else {
                aux = int.Parse(score.text);
                aux--;
                score.text = aux.ToString();
            }

            if(glassBin.nObjects != objects.Length){
                //Choose the next item to spawn
                index = Random.Range(0, objects.Length);

                //Always spawn a new object
                while(glassBin.usedObjects.Contains(objects[index].gameObject.transform.GetChild(0).gameObject.name)){
                    index = Random.Range(0, objects.Length);
                }
                //Debug.Log(objects[index].gameObject.name);
                
                //Enable the new object and set the spawn position
                objects[index].gameObject.SetActive(true);
                objects[index].gameObject.transform.position = new Vector3(objects[index].gameObject.transform.position.x ,2.3f, objects[index].gameObject.transform.position.z);
            } else{
                endMessage.SetActive(true);
            }
            
        }
    }
}
