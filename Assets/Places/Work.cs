using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Places
{
    public class Work: MonoBehaviour, IInteract
    {
        public void interact(INpc npc)
        {
            Debug.Log("calling the work interact method");
        }
    }
}