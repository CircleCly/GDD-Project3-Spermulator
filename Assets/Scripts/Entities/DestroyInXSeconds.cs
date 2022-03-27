using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInXSeconds : MonoBehaviour
{
    public float time;

    public bool fade;

    private SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        if (fade)
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
        }
        StartCoroutine(DestroyRoutine());
    }

    IEnumerator DestroyRoutine()
    {
        float destroyTimer = 0f;
        while (destroyTimer < time)
        {
            if (fade)
            {
                Color c = _renderer.color;
                _renderer.color = new Color(c.r, c.g, c.b, (time - destroyTimer) / time);
            }
            yield return null;
            destroyTimer += Time.deltaTime;
        }
        Destroy(gameObject);
    }
}
