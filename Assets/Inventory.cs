using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Inventory : MonoBehaviour
{
    public Text kiwiHUDcounter;
    private int m_kiwis = 0;

    void Start()
    {
        kiwiHUDcounter.text = m_kiwis.ToString();
    }

    public void AddKiwis(int i)
    {
        m_kiwis += i;
        kiwiHUDcounter.text = m_kiwis.ToString();
    }

    public int GetKiwis()
    {
        return m_kiwis;
    }
}