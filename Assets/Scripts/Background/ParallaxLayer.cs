using System;
using UnityEngine;

namespace Project.Scripts.Parallax
{
    // Allows ParallaxController to move each layer based on parallaxAmount
    public class ParallaxLayer : MonoBehaviour
    {
        [Range(-1f, 1f)]
        [SerializeField]
        [Tooltip("Amount of parallax. 1 simulates being close to the camera, -1 simulates being very far from the camera.")]
        private float parallaxAmount;

        [NonSerialized] private Vector3 newPosition;

        // private bool adjusted = false;

        public void MoveLayer(float positionChangeX, float positionChangeY)
        {
            var transform1 = transform;
            newPosition = transform1.localPosition;
            newPosition.x -= positionChangeX * (-parallaxAmount * 40) * (Time.deltaTime);
            newPosition.y -= positionChangeY * (-parallaxAmount * 40) * (Time.deltaTime);
            transform1.localPosition = newPosition;

            //InfiniteScrollingHorizontal();
        }

        //private void InfiniteScrollingHorizontal()
        //{
        //    // fix on some layers ending first because as per parallax the front ones will move faster
        //    deltaLength = (_camera.transform.position.x * (1 - parallaxEffect));
        //    if (deltaLength > startPos + lengthBackgroundOneSet)
        //    {
        //        startPos += lengthBackgroundOneSet; // move origin position by that much
        //    }
        //    else if (deltaLength < startPos + lengthBackgroundOneSet)
        //    {
        //        startPos -= lengthBackgroundOneSet;
        //    }
        //}
    }
}
