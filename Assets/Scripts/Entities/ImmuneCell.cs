using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneCell : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The sperm detector script object")]
    private ImmuneCellSpermDetector _detector;

    [SerializeField]
    [Tooltip("The immune fluid shot by this immune cell")]
    private GameObject _immuneFluid;

    public float shootIntervalMin;

    public float shootIntervalMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (_detector.spermDetected)
            {
                Vector3 shootDir = (_detector.spermPosition - transform.position).normalized;
                GameObject fl = Instantiate(_immuneFluid, transform.position + 2.2f * shootDir, transform.rotation);
                fl.GetComponent<Rigidbody2D>().AddForce(500 * shootDir);
            }
            yield return new WaitForSeconds(Random.Range(shootIntervalMin, shootIntervalMax));
        }
    }
}
