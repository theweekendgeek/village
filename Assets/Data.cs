using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private const int npcUpdateRate = 2;
    private List<GameObject> npcListDone = new List<GameObject>();
    private List<GameObject> npcListToDo = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        var npcs = GameObject.FindGameObjectsWithTag("npc");
        Debug.Log(npcs.Length);
        npcListToDo.AddRange(npcs);
        InvokeRepeating(nameof(updateNpcs), 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateNpcs()
    {
        if (npcListToDo.Count <= npcUpdateRate)
        {
            npcListToDo.AddRange(npcListDone);
            npcListDone.Clear();
        }

        var npcsToUpdate = npcListToDo.GetRange(0, npcUpdateRate);
        foreach (var npc in npcsToUpdate)
        {
            npc.GetComponent<Needs>().calculateNeeds();
        }

        npcListToDo.RemoveRange(0, npcUpdateRate);
        npcListDone.AddRange(npcsToUpdate);
        Debug.Log(npcListToDo.Count);
    }
}
