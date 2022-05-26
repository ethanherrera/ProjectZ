using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ContainerSO", order = 2)]
public class ContainerSO : ScriptableObject
{
        public List<ScriptableObject> objects;
}
