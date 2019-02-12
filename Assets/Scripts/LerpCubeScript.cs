using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCubeScript : MonoBehaviour {

    public GameObject _cube;
    public Vector3 _leftPosition;
    public Vector3 _rightPosition;
    Vector3 _startLerp;
    Vector3 _stopLerp;

    public void StartLerp()
    {
        _cube.transform.position = _leftPosition;
        StartCoroutine(LerpCube());
    }

    IEnumerator LerpCube()
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime;
            Debug.Log(t);
            _startLerp = Lerp(_leftPosition, _rightPosition, t*t);
            _stopLerp = Lerp(_leftPosition, _rightPosition, 1 - (1 - t) * (1 - t));
            _cube.transform.position = Lerp(_startLerp, _stopLerp, t);
            if (t >=1)
            {
                _cube.transform.position = _rightPosition;
            }
            yield return null;
        }
    }

    Vector3 Lerp(Vector3 _start, Vector3 _stop, float t)
    {
        return _start + (_stop - _start) * t;
    }

    public void PrintDebugString()
    {
        Debug.Log(this.ToString());
    }

    public override string ToString()
    {
        string s;

        s = (_cube ? "cube position =" + _cube.transform.position : "cube not instantiated ") + "\n" + "left position = " + _leftPosition + "\n" + "right position = " + _rightPosition;

        return s;
    }
}
