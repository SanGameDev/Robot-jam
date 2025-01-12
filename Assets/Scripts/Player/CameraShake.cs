using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float time, float magnitude){
        Vector3 originalPos = new Vector3(0,2.84f,-1.163f);
        float elapsed = 0.0f;
        while(elapsed<time){
            float x = Random.Range(-1.0f,1.0f) * magnitude;
            float y = Random.Range(-1.0f,1.0f) * magnitude;

            transform.localPosition = new Vector3(x,y, 0.0f) + originalPos;

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;

    }
}
