using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    protected Player _player;

    public virtual void InitAction(Player player) 
    {
        _player = player;
    }
}
