using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public void Dispear()
    {
        gameObject.SetActive(false);
    }

    public void Appear()
    {
        gameObject.SetActive(true);
    }
}
