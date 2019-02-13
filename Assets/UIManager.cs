using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] p1Slider;
    public Image[] p2Slider;

    public GridControl[] p1Grid;
    public GridControl[] p2Grid;

    private float maxLife;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        maxLife = (float)ParametersMgr.instance.GetParameterInt("shipHealth");
        InitialMissileSetup();
    }

    public void LooseLife(PlayerType type, float newlife)
    {
        float value = newlife / maxLife;
        switch (type)
        {
            case PlayerType.P1:
                foreach (Image s in p2Slider)
                {
                    s.fillAmount = value;
                }
                break;

            case PlayerType.P2:
                foreach (Image s in p1Slider)
                {
                    s.fillAmount = value;
                }
                break;
        }
    }

    public void InitialMissileSetup()
    {
        int cartridge = ParametersMgr.instance.GetParameterInt("cartridge");
        for (int i = 0; i < cartridge; ++i)
        {
            foreach (GridControl gc in p2Grid)
            {
                gc.AddIcon();
            }
            foreach (GridControl gc in p1Grid)
            {
                gc.AddIcon();
            }
        }
    }

    public void LaunchAMissileCooldown(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.P1:
                foreach (GridControl gc in p2Grid)
                {
                    gc.AnimateAnIcon();
                }
                break;

            case PlayerType.P2:
                foreach (GridControl gc in p1Grid)
                {
                    gc.AnimateAnIcon();
                }
                break;
        }
    }

    public void GetNewMissile(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.P1:
                foreach (GridControl gc in p2Grid)
                {
                    gc.AddIcon();
                }
                break;

            case PlayerType.P2:
                foreach (GridControl gc in p1Grid)
                {
                    gc.AddIcon();
                }
                break;
        }
    }

}

public enum PlayerType
{
    P1, P2
}
