using UnityEngine;
using System.Collections;

namespace Marie
{
    public class Earth : MonoBehaviour
    {
        [Header("Settings")]
        public float Speed = 1.0f;

        void Update()
        {

            this.transform.Rotate(transform.position.x, Speed, transform.position.z);
        }
    }

}

