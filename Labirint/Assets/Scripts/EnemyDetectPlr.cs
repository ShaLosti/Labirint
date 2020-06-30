using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyDetectPlr : MonoBehaviour
{
    private bool tryDetectPlr = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == CharacterInput.ControllByPlr.gameObject)
        {
            tryDetectPlr = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!tryDetectPlr) 
            return;

        Vector2 direction = new Vector2(CharacterInput.ControllByPlr.gameObject.transform.position.x - transform.position.x,
            CharacterInput.ControllByPlr.gameObject.transform.position.y - transform.position.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, LayerMask.GetMask("Player", "Obstacle"));
        if (hit.collider != null && hit.collider.gameObject.layer == CharacterInput.ControllByPlr.gameObject.layer)
        {
            tryDetectPlr = false;
            Enemy.CurrentEnemy.State = Enemy.EnemyStates.followPlr;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == CharacterInput.ControllByPlr.gameObject)
        {
            tryDetectPlr = false;
            Enemy.CurrentEnemy.State = Enemy.EnemyStates.searchPlr;
        }
    }
}
