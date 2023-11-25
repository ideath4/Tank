using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] Transform bar;
    // Start is called before the first frame update
    public void Init(Unit unit)
    {
        unit.OnChangeHP.AddListener( TargetHPChanged);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }
    void TargetHPChanged(float val)
    {
        bar.localScale = new  Vector3(val, 1, 1);
    }
}
