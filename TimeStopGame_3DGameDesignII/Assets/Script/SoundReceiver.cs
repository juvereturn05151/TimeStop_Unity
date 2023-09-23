using UnityEngine;
using System.Collections;

//Contain Agent Awareness Technique

public class SoundReceiver : MonoBehaviour
{
    public float soundThreshold;

    public EnemyAgent agent;

    void Start()
    {

    }

    public virtual void Receive()
    {
        // TODO

        agent.currentState = new StateAttack(agent);


        //if (s.isCheating) {
        //    if (s.whispering)
        //    {
        //        agent.GetComponent<EnemyBT>().isPlayerDetected = true;
        //        agent.GetComponent<NPC>().caughtCheatingStudent = s.gameObject.GetComponent<Student>();
        //        agent.GetComponent<NPC>().setTarget(s.gameObject);
        //    }

        //    if(s.canBeWhispered)
        //    {
        //        agent.GetComponent<EnemyBT>().isPlayerDetected = true;
        //        agent.GetComponent<NPC>().caughtCheatingStudent = s.gameObject.GetComponent<Student>();
        //        agent.GetComponent<NPC>().setTarget(s.gameObject);
        //    }
        //}
        // code your own behaviour here
    }
}
