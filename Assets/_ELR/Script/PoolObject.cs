using System;
using UnityEngine;
// using UnityEngine.Pool;

public class PoolObject : MonoBehaviour{
    
    // public GameObject GroundPrefab;
    // private ObjectPool<GameObject> _pool;
    //
    // public static PoolObject Instance{ get; private set; }
    //
    // private void Awake(){
    //     if(Instance == null)
    //         Instance = this;
    //     
    // }
    // private void Start(){
    //     _pool = new ObjectPool<GameObject>(() => Instantiate(GroundPrefab),obj => {
    //         obj.gameObject.SetActive(true);
    //     }, obj => {
    //         obj.gameObject.SetActive(false);
    //     }, obj => {
    //         Destroy(obj.gameObject);
    //     },false,10,20);
    // }
    //
    // public void Spawn(){
    //     var obj = _pool.Get();
    //     obj.transform.position = new Vector3(100, 0f);
    // }
    //
    // public void DeSpawn(GameObject obj){
    //     _pool.Release(obj);
    // }
}
