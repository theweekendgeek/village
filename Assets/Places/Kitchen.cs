using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Places
{
    public class Kitchen: MonoBehaviour, IInteract
    {
        public void interact(INpc npc)
        {
            Debug.Log("calling the kitchen interact method");
            npc.eat(60);
        }
    }
}