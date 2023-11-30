using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner Instance;

    [SerializeField] private GameObject _smallPlatform;
    [SerializeField] private Diamond _diamond;

    [Header("System")]
    private Platform CurrentPlatform;
    private bool playerAlive = true;


    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        playerAlive = false;
    }

    public void BeginGen()
    {
        StartCoroutine(Generateor());
    }

    private void GeneratePlatform()
    {
        Vector3 coordinates = new Vector3();
        Vector3 randomOffset;

        if (CurrentPlatform)
        {
            coordinates = CurrentPlatform.transform.position;

            if (Random.value > 0.5f)
                randomOffset = new Vector3(2.5f, 0, 0);
            else
                randomOffset = new Vector3(0, 0, 2.5f);

            coordinates += randomOffset;
        }
        else
            coordinates = transform.position;


        //Diamond Generation
        bool generatesDiamond = false;
        if (Random.value > 0.85f)
            generatesDiamond = true;

        CurrentPlatform = Instantiate(_smallPlatform.gameObject, coordinates, transform.rotation, transform).GetComponent<Platform>();

        if (generatesDiamond)
            CurrentPlatform.AddDiamond(Instantiate(_diamond));
    }

    private IEnumerator Generateor()
    {
        // Generate the first 20
        for (int i = 0; i < 20; i++)
        {
            GeneratePlatform();
        }

        yield return new WaitForSeconds(0.2f);

        // While loop until death
        while (playerAlive)
        {
            yield return new WaitForSeconds(0.2f);
            GeneratePlatform();
        }
    }
    
}
