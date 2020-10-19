using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Places
{
    public class Sleep: MonoBehaviour, IInteract
    {
        public void interact(INpc npc)
        {
            Debug.Log("calling the sleep interact method");
            npc.sleep(60);
        }
    }
}