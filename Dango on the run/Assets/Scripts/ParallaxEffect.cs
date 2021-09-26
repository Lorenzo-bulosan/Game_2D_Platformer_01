using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // variablles
    private float lengthBackgroundOneSet, startPos, distance, deltaLength;

    // ref
    public GameObject _camera;
    public float parallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lengthBackgroundOneSet = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move layer faster or camera follow depending on external user input variable
        MoveLayerByParallaxAmount();

        // infinite scrolling, as front layers will move faster than further ones
        InfiniteScrollingHorizontal();
    }

    private void MoveLayerByParallaxAmount()
    {
        // calculates parallax and move by that much each layer depending on variable given to each
        distance = (_camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }

    private void InfiniteScrollingHorizontal()
    {
        // fix on some layers ending first because as per parallax the front ones will move faster
        deltaLength = (_camera.transform.position.x * (1 - parallaxEffect));
        if (deltaLength > startPos + lengthBackgroundOneSet)
        {
            startPos += lengthBackgroundOneSet; // move origin position by that much
        }
        else if (deltaLength < startPos + lengthBackgroundOneSet)
        {
            startPos -= lengthBackgroundOneSet;
        }
    }
}
