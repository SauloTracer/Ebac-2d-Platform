using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace utils {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T instance;

        protected void Awake() {
            if (!instance) {
                instance = GetComponent<T>();
            } else {
                Destroy(gameObject);
            }
        }
    }
}