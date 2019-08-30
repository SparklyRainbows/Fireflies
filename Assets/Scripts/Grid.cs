using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance = null;

    public GameObject[] spaces;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public void UpdateFireflyLocation(string spaceName, GameObject firefly) {
        Firefly fireflyScript = firefly.GetComponent<Firefly>();

        HideGridColor(fireflyScript.location);

        fireflyScript.location = int.Parse(spaceName);

        ShowGridColor(fireflyScript.color, fireflyScript.location);
    }
    
    //
    //++++++++++++++++++++++++++++
    //FIX ME
    //++++++++++++++++++++++++++++
    //
    private void HideGridColor(int location) {
        //Horizontal
        if (location < 3) {
            HideHorizontal(0);
            HideHorizontal(1);
            HideHorizontal(2);
        } else if (location < 6) {
            HideHorizontal(3);
            HideHorizontal(4);
            HideHorizontal(5);
        } else {
            HideHorizontal(6);
            HideHorizontal(7);
            HideHorizontal(8);
        }

        //Vertical
        if (location % 3 == 0) {
            HideVertical(0);
            HideVertical(3);
            HideVertical(6);
        } else if (location % 3 == 1) {
            HideVertical(1);
            HideVertical(4);
            HideVertical(7);
        } else {
            HideVertical(2);
            HideVertical(5);
            HideVertical(8);
        }
    }

    private void ShowGridColor(Color color, int location) {
        //Horizontal
        if (location < 3) {
            ShowHorizontal(0, color);
            ShowHorizontal(1, color);
            ShowHorizontal(2, color);
        } else if (location < 6) {
            ShowHorizontal(3, color);
            ShowHorizontal(4, color);
            ShowHorizontal(5, color);
        } else {
            ShowHorizontal(6, color);
            ShowHorizontal(7, color);
            ShowHorizontal(8, color);
        }

        //Vertical
        if (location % 3 == 0) {
            ShowVertical(0, color);
            ShowVertical(3, color);
            ShowVertical(6, color);
        } else if (location % 3 == 1) {
            ShowVertical(1, color);
            ShowVertical(4, color);
            ShowVertical(7, color);
        } else {
            ShowVertical(2, color);
            ShowVertical(5, color);
            ShowVertical(8, color);
        }
    }

    private void ShowVertical(int space, Color color) {
        spaces[space].GetComponent<GridSpace>().ShowVertical(color);
    }

    private void ShowHorizontal(int space, Color color) {
        spaces[space].GetComponent<GridSpace>().ShowHorizontal(color);
    }

    private void HideVertical(int space) {
        spaces[space].GetComponent<GridSpace>().HideVertical();
    }

    private void HideHorizontal(int space) {
        spaces[space].GetComponent<GridSpace>().HideHorizontal();
    }
}
