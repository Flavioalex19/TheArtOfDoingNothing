using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public List<GameObject> obj_TaskInteractableList = new List<GameObject>();//List of interactable objects

    public int _taskConcludedFromRoomCount = 0;//how many task are completed from current room


    private void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            obj_TaskInteractableList.Add(obj);
        }
    }

    private void Update()
    {
        
    }

    #region Get & Set
    public int GetTaskConcludedFromRoomCount()
    {
        return _taskConcludedFromRoomCount;
    }
    public void SetTaskConcludedFromRoomCount()
    {
        _taskConcludedFromRoomCount++;
    }
    
    #endregion
}
