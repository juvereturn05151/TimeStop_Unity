using UnityEngine;
using System.Collections.Generic;

public class SoundEmitter : MonoBehaviour
{
    [SerializeField]
    private string tagWall = "Wall";
    [SerializeField]
    private float soundIntensity;
    [SerializeField]
    private float soundAttenuation;
    [SerializeField]
    private float WallThickNess = 0.0f;
    [SerializeField]
    private Player _player;

    private Dictionary<int, SoundReceiver> receiverDic;

    private void Awake()
    {
        receiverDic = new Dictionary<int, SoundReceiver>();

        if (_player == null) 
        {
            _player = GetComponent<Player>();
        } 
    }

    private void Update() {
        Emit();
    }

    public void OnTriggerEnter(Collider coll)
    {
        SoundReceiver receiver = coll.gameObject.GetComponent<SoundReceiver>();

        if (receiver == null) 
        {
            return;
        }
            
        int objId = coll.gameObject.GetInstanceID();
        receiverDic.Add(objId, receiver);
    }



    public void OnTriggerExit(Collider coll)
    {
        SoundReceiver receiver = coll.gameObject.GetComponent<SoundReceiver>();

        if (receiver == null) 
        {
            return;
        }
            
        int objId = coll.gameObject.GetInstanceID();
        receiverDic.Remove(objId);
    }

    public void Emit()
    {
        GameObject srObj;
        Vector3 soundReceiverPos;
        float intensity;
        float distance;
        Vector3 emitterPos = _player.transform.position;

        foreach (SoundReceiver sr in receiverDic.Values)
        {
            srObj = sr.gameObject;
            soundReceiverPos = srObj.transform.position;
            distance = Vector3.Distance(soundReceiverPos, emitterPos);
            intensity = 0;

            if (_player.PlayerMovement)
            {
                intensity += _player.PlayerMovement.Noise;
            }

            intensity -= soundAttenuation * distance;

            intensity -= GetWallAttenuation(emitterPos, soundReceiverPos);

            if (_player != null)
            {
                _player.IncreaseExcitement(_player.PlayerMovement.Noise);
            }
            
            if (intensity < sr.soundThreshold) 
            {
                continue;
            }
                
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

        for (int i = 0; i < hits.Length; i++)
        {
            GameObject obj;
            string tag;
            obj = hits[i].collider.gameObject;
            tag = obj.tag;

            if (tag.Equals(tagWall)) 
            {
                attenuation += WallThickNess;
            }
        }

        return attenuation;
    }

}
