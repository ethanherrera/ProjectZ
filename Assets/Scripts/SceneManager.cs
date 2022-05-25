using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
        public GameObject player;
        public static SceneManager Instance { get; private set; }

        private void Awake()
        {
                if (Instance == null)
                        Instance = this;
                else
                        Destroy(gameObject);
        }
}
