using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class ObstaclesBlock : MonoBehaviour
{
    private List<Obstacle> _children;

    public List<Obstacle> Children => _children;

    private void Awake()
    {
        _children = GetComponentsInChildren<Obstacle>().ToList();
    }
}
