using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IsoCamera : MonoBehaviour
{
    public static int AlphaClipping = Shader.PropertyToID("_Cutoff");
    public Material WallMaterial;
    public Camera Camera;
    public LayerMask LayerMask;

    float amount = 0;
    float increaseAmount = .9f;
    //player transform
    [SerializeField]Transform _playerTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        //_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        var dir = Camera.transform.position - transform.position;
        Ray ray = new Ray(transform.position, dir.normalized);
        RaycastHit hit;
        if (Physics.Raycast(ray, 3000f, LayerMask))
        {
            if (amount < 1)
            {
                WallMaterial.SetFloat(AlphaClipping, amount += increaseAmount * Time.deltaTime);
            }
            else WallMaterial.SetFloat(AlphaClipping, 1f);

        }
        else 
        {
            if(amount >= 0)
            {
                WallMaterial.SetFloat(AlphaClipping, amount -= increaseAmount * Time.deltaTime);
            }
            else
            {
                WallMaterial.SetFloat(AlphaClipping, 0);
                amount = 0;
            }
            
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //update the positon
        transform.position = _playerTransform.position;
    }
}
