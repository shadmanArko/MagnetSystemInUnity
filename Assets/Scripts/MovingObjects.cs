using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{

    public GameObject targetPosition;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        transform.DOMove(targetPosition.transform.position, speed).SetLoops(-1, LoopType.Yoyo);
    }
}
