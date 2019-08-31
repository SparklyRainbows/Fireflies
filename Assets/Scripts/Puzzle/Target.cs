using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int location = -1;
    MyColor myColor;
    
    SpriteRenderer correctSprite;
    SpriteRenderer incorrectSprite;

    private void Start() {
        correctSprite = transform.Find("Correct").GetComponent<SpriteRenderer>();
        incorrectSprite = transform.Find("Incorrect").GetComponent<SpriteRenderer>();
    }

    public void SetColor() {
        switch(gameObject.name) {
            case ("redTarget"):
                SetColor(ColorName.RED);
                return;
            case ("blueTarget"):
                SetColor(ColorName.BLUE);
                return;
            case ("yellowTarget"):
                SetColor(ColorName.YELLOW);
                return;
            default:
                Debug.LogWarning($"Target name not found: {gameObject.name}");
                return;
        }
    }

    private void SetColor(ColorName color) {
        myColor = new MyColor(color);
        GetComponent<SpriteRenderer>().color = myColor.GetColor();
    }

    public void SetLight(bool isLit, Color spaceColor) {
        if (!isLit) {
            correctSprite.enabled = false;
            incorrectSprite.enabled = false;
            return;
        }

        if (spaceColor == myColor.GetColor()) {
            correctSprite.enabled = true;
            incorrectSprite.enabled = false;
        } else {
            incorrectSprite.enabled = true;
            correctSprite.enabled = false;
        }
    }

    public bool IsLitCorrectly() {
        return correctSprite.enabled;
    }
}
