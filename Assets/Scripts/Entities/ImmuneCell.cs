using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ImmuneCell : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The sperm detector script object")]
    private ImmuneCellSpermDetector _detector;

    [SerializeField]
    [Tooltip("The immune fluid shot by this immune cell")]
    private GameObject _immuneFluid;

    private PhotonView _pv;

    private AudioSource _shootAudio;

    public float shootIntervalMin;

    public float shootIntervalMax;

    public float moveSpeed;

    public float shootForce;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootCoroutine());
        _shootAudio = GetComponent<AudioSource>();
        _pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (_detector.spermDetected)
            {
                Vector3 moveDir = (_detector.spermPosition - transform.position).normalized;
                transform.position += moveDir * moveSpeed * Time.deltaTime;
            }
        }
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (_detector.spermDetected && PhotonNetwork.IsMasterClient)
            {
                Vector3 shootDir = (_detector.spermPosition - transform.position).normalized;
                GameObject fl = PhotonNetwork.Instantiate(Path.Combine("Prefabs", _immuneFluid.name),
                    transform.position + 2.0f * shootDir, transform.rotation);
                fl.GetComponent<Rigidbody2D>().AddForce(shootForce * shootDir);
                GameManager.Instance.masterPVs.Add(fl.GetPhotonView());
                _shootAudio.Play();
                
                
            }
            yield return new WaitForSeconds(Random.Range(shootIntervalMin, shootIntervalMax));
        }
    }
}
