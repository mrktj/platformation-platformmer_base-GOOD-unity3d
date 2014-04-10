using UnityEngine;
using System.Collections;

public class CardBoardWall : MonoBehaviour
{
    void Start()
    {
        renderer.material.SetTextureScale("cardboard", transform.localScale);
    }
}

