using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit
{
    [SerializeField] List<Cannon> cannons;
    int currentCannon = 0;
    [SerializeField] MoveController moveController;
    [SerializeField] Transform cameraPosition;
    public Transform CameraPosition
    {
        get { return cameraPosition; }
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
        InitCannons();
    }

    void InitCannons()
    {
        for (int i = 0; i < cannons.Count; i++)
        {
            cannons[i].gameObject.SetActive(currentCannon == i);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            cannons[currentCannon].Shoot();
        }
        MoveControls();
        SwitchWeaponsControls();
    }
    void SwitchWeaponsControls()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PrevCannon();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextCannon();
        }
    }
    void MoveControls()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveController.Rotate(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveController.Rotate(1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveController.Accelerate();
            return;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveController.Break();
            return;
        }
        moveController.DecreaseSpeed();
            }
    void PrevCannon()
    {
        cannons[currentCannon].gameObject.SetActive(false);
        currentCannon--;
        if (currentCannon < 0) currentCannon = cannons.Count - 1;
        cannons[currentCannon].gameObject.SetActive(true);
    }
    void NextCannon()
    {
        cannons[currentCannon].gameObject.SetActive(false);
        currentCannon++;
        if (currentCannon >= cannons.Count) currentCannon = 0;
        cannons[currentCannon].gameObject.SetActive(true);
    }
}
