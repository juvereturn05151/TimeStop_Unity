using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private PlayerAction playerAction;

    public Slider exciteSlider;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAction = GetComponent<PlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void increaseExcitement(float excite)
    {
        Debug.Log("exciteSlider.value" + exciteSlider.value);

        exciteSlider.value += excite;
    }

    public void decreaseExcitement(float decreaseRate)
    {
        exciteSlider.value -= decreaseRate * Time.deltaTime;
    }

    public PlayerMovement GetPlayerMovement()
    {
        return playerMovement;
    }

    public PlayerAction GetPlayerAction()
    {
        return playerAction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
