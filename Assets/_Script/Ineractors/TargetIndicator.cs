using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float rotationSpeed;
    [SerializeField] float hidingDistace; // when you are near the target object the arrow will disappears


    // Update is called once per frame
    void Update()
    {
        var direction = target.position - transform.position;
        if (direction.magnitude < hidingDistace)
        {
            setChildrenActive(false);
        }
        else
        {
            setChildrenActive(true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }
    }

    void setChildrenActive(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
}
    


