using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash : MonoBehaviour {

    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel("loading");
#pragma warning restore CS0618 // Type or member is obsolete
    }

}
