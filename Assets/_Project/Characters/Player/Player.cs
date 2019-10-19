using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool wannaRespawn = false;
    [SerializeField] private GameObject landingAreaPrefab;

    private bool areaIsClear;
    private bool helicopterHasBeenCalled;
    private GameObject[] playerSpawnPoints;

    #region EventManager subscriptions
    private void OnEnable()
    {
        EventManager.ClearAreaDetected += SetAreaIsClear;
        EventManager.BlockedAreaDetected += SetAreaIsBlocked;
    }

    private void OnDisable()
    {
        EventManager.ClearAreaDetected -= SetAreaIsClear;
        EventManager.BlockedAreaDetected -= SetAreaIsBlocked;
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        playerSpawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (wannaRespawn)
        {
            ReSpawn();
            wannaRespawn = false;
        }

        if (Input.GetButtonDown("CallHeli"))
        {
            StartCoroutine(CallHeliAndDeployFlare());
        }
    }

    // Called by Event ClearAreaDetected.
    void SetAreaIsClear(object sender, System.EventArgs e = null)
    {
        areaIsClear = true;
        Debug.Log("areaIsClear set to: " + areaIsClear);
    }

    // Called by Event BlockedAreaDetected.
    void SetAreaIsBlocked(object sender, System.EventArgs e = null)
    {
        areaIsClear = false;
        Debug.Log("areaIsClear set to: " + areaIsClear);
    }

    private IEnumerator CallHeliAndDeployFlare()
    {
        if (areaIsClear && !helicopterHasBeenCalled)
        {
            // Raise event.
            EventManager.OnHelicopterCalled();
            helicopterHasBeenCalled = true;

            yield return new WaitForSeconds(3f);

            Vector3 landingAreaPosition = transform.position + new Vector3(0f, -0.9f, 0f);
            Instantiate(landingAreaPrefab, landingAreaPosition, Quaternion.identity);
            // TODO: Child to _Dynamic GameObject in Hierarchy.
        }
    }

    private void ReSpawn()
    {
        int index = Random.Range(0, playerSpawnPoints.Length);
        transform.position = playerSpawnPoints[index].transform.position;
    }
}
