using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Contain Agent Awareness Technique

public class SoundEmitter : MonoBehaviour
{
    public string tagWall = "Wall";
    float WallThickNess = 0.0f;

    public float soundIntensity;
    public float soundAttenuation;
    public GameObject emitterObject;
    private Dictionary<int, SoundReceiver> receiverDic;

    // optional
    public Dictionary<string, float> wallTypes;

    void Start()
    {
        receiverDic = new Dictionary<int, SoundReceiver>();
        if (emitterObject == null)
            emitterObject = gameObject;
    }

    void Update() {
        Emit();
    }

    public void OnTriggerEnter(Collider coll)
    {
        SoundReceiver receiver;
        receiver = coll.gameObject.GetComponent<SoundReceiver>();
        if (receiver == null)
            return;
        int objId = coll.gameObject.GetInstanceID();
        receiverDic.Add(objId, receiver);
    }



    public void OnTriggerExit(Collider coll)
    {
        SoundReceiver receiver;
        receiver = coll.gameObject.GetComponent<SoundReceiver>();
        if (receiver == null)
            return;
        int objId = coll.gameObject.GetInstanceID();
        receiverDic.Remove(objId);
    }

    public void Emit()
    {
        GameObject srObj;
        Vector3 srPos;
        float intensity;
        float distance;
        Vector3 emitterPos = emitterObject.transform.position;
        foreach (SoundReceiver sr in receiverDic.Values)
        {
            srObj = sr.gameObject;
            srPos = srObj.transform.position;
            distance = Vector3.Distance(srPos, emitterPos);
            intensity = 0;
            if (GetComponent<Player>().GetPlayerMovement())
            {
                intensity += GetComponent<Player>().GetPlayerMovement().GetNoise();
            }

            intensity -= soundAttenuation * distance;
            // optional
            intensity -= GetWallAttenuation(emitterPos, srPos);

            Debug.Log("intensity" + intensity);

            if (this.GetComponent<Player>() != null)
            {
                this.GetComponent<Player>().increaseExcitement(this.GetComponent<Player>().GetPlayerMovement().GetNoise());
            }
            
            // --------
            if (intensity < sr.soundThreshold)
                continue;
            sr.Receive();

        }
    }


    public float GetWallAttenuation(Vector3 emitterPos, Vector3 receiverPos)
    {
        float attenuation = 0f;
        Vector3 direction = receiverPos - emitterPos;
        float distance = direction.magnitude;
        direction.Normalize();
        Ray ray = new Ray(emitterPos, direction);
        RaycastHit[] hits = Physics.RaycastAll(ray, distance);
        int i;
        for (i = 0; i < hits.Length; i++)
        {
            GameObject obj;
            string tag;
            obj = hits[i].collider.gameObject;
            tag = obj.tag;
            if (tag.Equals(tagWall))
                attenuation += WallThickNess;
        }
        return attenuation;
    }

}
