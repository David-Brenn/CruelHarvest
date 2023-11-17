using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhand : MonoBehaviour
{
   public GameObject tool;

   public void SetTool(GameObject newTool) {
        if(newTool != tool){
            RemoveTool(); 

            newTool = Instantiate(newTool, transform);
            tool = newTool;
            //make tool child of playerhand
            tool.transform.parent = transform;
        }  else {
            RemoveTool();
        }
            
   }

   public void RemoveTool() {
       if(tool != null){
            Destroy(tool);
       }
   }

}
