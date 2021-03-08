using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    Transform hp;
    [SerializeField]
    Camera cam;
    [SerializeField]
    Slider slider;

    private void Awake()
    {

        InvokeRepeating("Find", 0, 1f);
        InvokeRepeating("Lost", 0, 1f);
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

    }
    private void Update()
    {
        Quaternion q_hp = Quaternion.LookRotation(hp.position - cam.transform.position);

        Vector3 hp_angle = Quaternion.RotateTowards(hp.rotation, q_hp, 200).eulerAngles;

        hp.rotation = Quaternion.Euler(0, hp_angle.y, 0);

        //Debug.Log(slider.value);
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        Debug.Log(slider.value);
    }
    void Find()
    {
        
    }
    void Lost()
    {
        //slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
}
