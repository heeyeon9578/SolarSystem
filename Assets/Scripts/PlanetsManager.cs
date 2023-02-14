using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsManager : MonoBehaviour
{
    static PlanetsManager instance; 
    [SerializeField] public Sun sun;
    [SerializeField] public Mercury mercury; 
    [SerializeField] public Venus venus; 
    [SerializeField] public Earth earth; 
    [SerializeField] public Moon moon; 
    [SerializeField] public Mars mars; 
    [SerializeField] public Jupiter jupiter; 
    [SerializeField] public Saturn saturn; 
    [SerializeField] public Uranus uranus;
    [SerializeField] List<GameObject> gameObjects;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        instance = this;

    }
    public static PlanetsManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
/*
    void Start()
    {
        planetsStart();

       

    }*/
/*    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(5f);
        Debug.Log(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            gameObjects.Add(transform.GetChild(i).gameObject);

        }
    }*/
 /*   private void Update()
    {
        planetsUpdate();
    }*/
    [PunRPC]
    void planetsStart()
    {
        sun.planetStart();
        mercury.planetStart();
        venus.planetStart();
        earth.planetStart();
        moon.planetStart();
        mars.planetStart();
        jupiter.planetStart();
        saturn.planetStart();
        uranus.planetStart();
    }
    [PunRPC]
    void planetsUpdate()
    {
        sun.planetUpdate();
        mercury.planetUpdate(); 
        venus.planetUpdate();
        earth.planetUpdate();
        moon.planetUpdate();
        mars.planetUpdate();    
        jupiter.planetUpdate();
        saturn.planetUpdate();
        uranus.planetUpdate();
    }

}
