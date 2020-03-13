using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Object", menuName = "Museum/Item", order = 1)]
public class ObjectHandler : ScriptableObject {
    public string ObjectName {
        get => objectName;
        set => objectName = value;
    }

    public string ObjectDescription {
        get => objectDescription;
        set => objectDescription = value;
    }

    public int ObjectAge {
        get => objectAge;
        set => objectAge = value;
    }

    public Material ObjectMaterial {
        get => objectMaterial;
        set => objectMaterial = value;
    }

    [SerializeField] private string objectName;
    [SerializeField] private string objectDescription;
    [SerializeField] private int objectAge;
    [SerializeField] private Material objectMaterial;

}
