using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DestroyInXSeconds : MonoBehaviour
{
    public float time;

    public bool fade;

    private SpriteRenderer _renderer;

    private PhotonView _pv;
    // Start is called before the first frame update
    void Start()
    {
        _pv = GetComponent<PhotonView>();
        if (fade)
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
        }
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(DestroyRoutine());
        }
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
                if (PhotonNetwork.IsMasterClient)
                {
                    _pv.RPC("RPC_SendColorAlpha", RpcTarget.AllBuffered, _renderer.color.a);
                }
            }
            yield return null;
            destroyTimer += Time.deltaTime;
        }
        PhotonNetwork.Destroy(gameObject);
    }

    [PunRPC]
    public void RPC_SendColorAlpha(float a)
    {
        Color newColor = _renderer.color;
        newColor.a = a;
        _renderer.color = newColor;
    }
}
