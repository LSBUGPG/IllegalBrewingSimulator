using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coolDown : MonoBehaviour
{
    public Image ImageCooldown;
    public float cooldown = 5;
    public bool operating = false;

    // Use this for initialization
    void Update()
    {
        ImageCooldown.fillAmount += ((operating ? 1.0f : -1.0f) / cooldown) * Time.deltaTime;
    }

    public bool IsFinished()
    {
        return ImageCooldown.fillAmount == 1.0f;
    }

    public void Reset()
    {
        ImageCooldown.fillAmount = 0.0f;
        operating = false;
    }
}
