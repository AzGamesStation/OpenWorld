using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enemy;
using Game.Character.CharacterController;
public class PropPickUpDummy : MonoBehaviour
{
    public HumanoidBehaiviour type;

    private void Start()
    {
        InvokeRepeating("DestroyWhenOutOfRadius", 1, 1);     
    }
    private void DestroyWhenOutOfRadius()
    {
        if (Vector3.Distance (PlayerManager.Instance.Player.transform.position, this.transform.position) >= 100)
        {
            Destroy(this.gameObject);
        }
    }
}
