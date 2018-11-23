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

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        maxLife = (float) ParametersMgr.instance.GetParameterInt("shipHealth");
    }


    public void LooseLife(PlayerType type, int newNumberOfLife)
    {
        switch (type)
        {
            case PlayerType.P1:
                foreach (Image slider in p1Slider)
                {
                    slider.fillAmount -= 1/maxLife;
                }
                break;

            case PlayerType.P2:
                foreach (Image slider in p2Slider)
                {
                    slider.fillAmount -= 1/maxLife;
                }
                break;
        }
    }

    public void NewMissile(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.P1:
                foreach (GridControl gc in p1Grid)
                {
                    gc.AddMissile();
                }
                break;

            case PlayerType.P2:
                foreach (GridControl gc in p2Grid)
                {
                    gc.AddMissile();
                }
                break;
        }
    }

    public void LaunchMissile(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.P1:
                foreach (GridControl gc in p1Grid)
                {
                    gc.LaunchCD();
                }
                break;

            case PlayerType.P2:
                foreach (GridControl gc in p2Grid)
                {
                    gc.LaunchCD();
                }
                break;
        }
    }

    public void RestoreMissile(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.P1:
                foreach (GridControl gc in p1Grid)
                {
                    gc.StopCD();
                }
                break;

            case PlayerType.P2:
                foreach (GridControl gc in p2Grid)
                {
                    gc.StopCD();
                }
                break;
        }
    }

}

public enum PlayerType
{
    P1, P2
}
