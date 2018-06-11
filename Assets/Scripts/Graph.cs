﻿using UnityEngine;

public class Graph : MonoBehaviour {

    public Transform pointPrefab;

    [Range(10, 100)]
    public int resolution = 10;

    Transform[] points;

    private void Awake() {        
        float step = 2f / resolution;
        Transform point;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;

        points = new Transform[resolution];

        for (int i = 0; i < resolution; i++) {
            point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    private void Update() {
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            //position.y = Mathf.Round(Mathf.Sin(Mathf.PI * (position.x + Time.time)));
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;
        }
    }
}
