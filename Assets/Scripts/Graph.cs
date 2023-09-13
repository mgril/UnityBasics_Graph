using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField]
    Transform pointPrefab;
    [SerializeField, Range(10, 100)]
	int resolution = 10; // search the bug later but resolution still at 10 if we change it i dont know why
    
    Transform[] points;
    void Awake () {
        float step = 2f / 50;   // resolution instead of 50 but it doesn't work 
        //Debug.log("step:" + step)
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[50] ; // resolution instead of 50 but it doesn't work 
        for (int i = 0; i < points.Length; i++) { 
                Transform point = points[i] = Instantiate(pointPrefab);
                position.x = (i + 0.5f) * step - 1f;
                point.localPosition =  position;
                point.localScale = scale;
                point.SetParent(transform, false);
        }
    }

    void Update () {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++){
            Transform point = points[i];
            Vector3 position = point.localPosition;
            //position.y = position.x * position.x * position.x; // f(x) = x^3
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
    }
}