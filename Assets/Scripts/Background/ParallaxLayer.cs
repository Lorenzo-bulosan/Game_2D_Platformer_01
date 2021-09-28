using System;
using UnityEngine;

// behaviour controll of each layer of parallax individually
namespace Project.Scripts.Parallax
{
    // Allows ParallaxController to move each layer based on parallaxAmount
    public class ParallaxLayer : MonoBehaviour
    {
        //    [Range(-1f, 1f)]
        //    [SerializeField]
        //    [Tooltip("Amount of parallax. 1 simulates being close to the camera, -1 simulates being very far from the camera.")]
        //    private float parallaxAmount;

        //    [NonSerialized] private Vector3 newPosition;

        // variablles
        private float lengthBackgroundOneSet, startPos, distance, deltaLength;

        // ref
        public GameObject _camera;
        public float parallaxEffect;

        private void Awake()
        {
            startPos = transform.position.x;
            lengthBackgroundOneSet = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void Update()
        {
            // move layer faster or camera follow depending on external user input variable
            //MoveLayerByParallaxAmount();

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

        // jimmy's  parallax implementation but needs controller in parent objects
        //public void MoveLayer(float positionChangeX, float positionChangeY)
        //{
        //    var transform1 = transform;
        //    newPosition = transform1.localPosition;
        //    newPosition.x -= positionChangeX * (Time.deltaTime);
        //    newPosition.y -= positionChangeY * (Time.deltaTime);
        //    transform1.localPosition = newPosition;
        //}
    }
}
