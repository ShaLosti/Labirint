using System;
using System.Collections;
using UnityEngine;

public class LampController : MonoBehaviour, ITakeble
{
    private Inventory characterInvert;

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.TryGetComponent<Inventory>(out characterInvert);
        if (characterInvert != null)
            OnTake();
    }
    public void OnTake()
    {
        StartCoroutine(OnTakeCoroutine(characterInvert));
    }

    IEnumerator OnTakeCoroutine(Inventory characterInvert)
    {
        while (true)
        {
            if (characterInvert.objects.Contains(gameObject.tag))
            {
                Destroy(gameObject);
                yield break;
            }
            yield return null;
        }
    }
}
