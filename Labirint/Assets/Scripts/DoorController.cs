using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Inventory>() != null && GameManager.canOpenTheDoor)
        {
            GameObject door = gameObject.transform.parent.gameObject;
            if (door.transform.rotation.eulerAngles.z != 270)
            {
                door.transform.DORotate(new Vector3(0,0,-90),1f);
            }
        }
    }
}
