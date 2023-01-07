using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _collisionRadius = 5f;

   // [SerializeField] public GameObject _bullet;
    //[SerializeField] public SpawnSphere _point;
    //private Material _currentMaterialBullet;

    private Material _target;
    //private Material _materialFromList;
    //private List<GameObject> _spheres;


    private void Start()
    {
        //_spheres = _point.GetComponent<SpawnSphere>()._littleSpheres;
        // _materialFromList = _point.GetComponent<ChangeColorSphere>().ReturnRandomMaterial();
       // _currentMaterialBullet = GetComponent<Renderer>().material;
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            return;
        }
        //_target = other.GetComponent<Renderer>().material;//??
        
        var material = GetComponent<Renderer>().material;
        var paintableObjects = Physics.OverlapSphere(gameObject.transform.position, _collisionRadius)
            .Select(c => c.gameObject).Where(paintableObject => paintableObject.gameObject.GetComponent<Renderer>().material == _target);//??
        StartCoroutine(ChangeColors(paintableObjects, material));
        _target = other.GetComponent<Renderer>().material;//??
        
    }

    private IEnumerator ChangeColors(IEnumerable<GameObject> paintableObjects, Material newMaterial)
    {
        yield return new WaitForSeconds(0.1f);
        foreach (var paintObject in paintableObjects)
        {
            StartCoroutine(ChangeColor(paintObject, newMaterial, 0.5f));
        }
    }

    private IEnumerator ChangeColor(GameObject paintObject, Material newMaterialaterial, float duration)
    {
        var endScale = Vector3.one * 1.5f;
        var startScale = paintObject.transform.localScale;
        float currentTime = 0;
        while (currentTime < duration)
        {
            var progress = currentTime / duration;
            var currentScale = Vector3.Lerp(startScale, endScale, progress);
            paintObject.transform.localScale = currentScale;
            currentTime += Time.deltaTime;
            yield return null;
        }

        paintObject.GetComponent<Renderer>().material = newMaterialaterial;
        currentTime = 0;
        while (currentTime < duration)
        {
            var progress = currentTime / duration;
            var currentScale = Vector3.Lerp(endScale, startScale, progress);
            paintObject.transform.localScale = currentScale;
            currentTime += Time.deltaTime;
            yield return null;
        }

        paintObject.transform.localScale = startScale;
    }
}