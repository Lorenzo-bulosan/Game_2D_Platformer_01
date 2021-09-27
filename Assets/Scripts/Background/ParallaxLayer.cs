using System;
using UnityEngine;

// behaviour controll of each layer of parallax individually
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

        private float lengthOfLayer;

        [SerializeField]
        private Camera cameraObj;

        private void Awake()
        {
            cameraObj = GetComponent<Camera>();
            
        }

        public void MoveLayer(float positionChangeX, float positionChangeY)
        {
            var transform1 = transform;
            newPosition = transform1.localPosition;
            newPosition.x -= positionChangeX * (-parallaxAmount * 30) * (Time.deltaTime);
            newPosition.y -= positionChangeY * (-parallaxAmount * 20) * (Time.deltaTime);
            transform1.localPosition = newPosition;

            // IMPLEMENT INFINITE SCROLLING
            InfiniteScrollingHorizontal();
        }

        private void InfiniteScrollingHorizontal()
        {
            // get layer position of edges x0 and x1
            var camerax0 = cameraObj.transform.position.x;
            var camerax1 = cameraObj.orthographicSize*2f;

            // get camera position of edges too c0 and c1

            // when the camera edge c1 reaches x1 then move layer to start at x1, and inverse

            // test move layer
            var transform2 = transform;
            newPosition = transform2.localPosition;
            newPosition.x -= 0.02f;
            transform2.localPosition = newPosition;

            Console.WriteLine(newPosition);
        }
    }
}
