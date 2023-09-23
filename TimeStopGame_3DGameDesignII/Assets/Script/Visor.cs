using UnityEngine;
using System.Collections;

//Contain Agent Awareness Technique

public class Visor : MonoBehaviour
{
    public string tagWall = "Wall";
    public string tagTarget = "Player";

    public EnemyAgent agent;

    // Use this for initialization
    void Start()
    {

    }

    void Update() {

    }

    public void OnTriggerStay(Collider coll)
    {
        string tag = coll.gameObject.tag;
        if (!tag.Equals(tagTarget))
            return;
        GameObject target = coll.gameObject;
        Vector3 agentPos = agent.transform.position;
        Vector3 targetPos = target.transform.position;
        Vector3 direction = targetPos - agentPos;
        float length = direction.magnitude;
        direction.Normalize();
        Ray ray = new Ray(agentPos, direction);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, length);
        int i;
        for (i = 0; i < hits.Length; i++)
        {
            GameObject hitObj;
            hitObj = hits[i].collider.gameObject;
            tag = hitObj.tag;
            if (tag.Equals(tagWall))
                return;
        }

        // TODO
        // target is visible
        if (coll.gameObject.tag == tagTarget)
        {
            agent.currentState = new StateAttack(agent);
            //if (coll.gameObject.GetComponent<Player>().GetPlayerMovement())
            //{
            //    coll.gameObject.GetComponent<Player>().GetPlayerMovement().GetNoise();
            //}
        }



        // code your behaviour below
    }

}
