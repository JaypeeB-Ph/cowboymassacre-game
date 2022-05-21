using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
  
    void Start()
    {
        StartCoroutine(Vanish());
    }


    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
