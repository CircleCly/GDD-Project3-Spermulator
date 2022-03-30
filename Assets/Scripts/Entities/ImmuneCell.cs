using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneCell : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The sperm detector script object")]
    private ImmuneCellSpermDetector _detector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShootCoroutine(float shootInterval)
    {
        while (true)
        {
            if (_detector.spermDetected)
            {

            }
            yield return new WaitForSeconds(shootInterval);
        }
    }
}
