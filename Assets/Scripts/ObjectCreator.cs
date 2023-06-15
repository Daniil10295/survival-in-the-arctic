using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject bonfirePrefab;
    [SerializeField] private Transform ObjectsTransform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bonfire = Instantiate(bonfirePrefab, new Vector2(playerTransform.position.x, playerTransform.position.y), Quaternion.identity, ObjectsTransform);
            bonfire.AddComponent<BoxCollider2D>();
            bonfire.tag = "bonfire";
        }
    }
}
