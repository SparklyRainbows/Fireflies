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
        SetColor();

        correctSprite = transform.Find("Correct").GetComponent<SpriteRenderer>();
        incorrectSprite = transform.Find("Incorrect").GetComponent<SpriteRenderer>();
    }

    private void SetColor() {
        switch(gameObject.name) {
            case ("RedTarget"):
                myColor = new MyColor(ColorName.RED);
                return;
            case ("BlueTarget"):
                myColor = new MyColor(ColorName.BLUE);
                return;
            case ("YellowTarget"):
                myColor = new MyColor(ColorName.YELLOW);
                return;
            default:
                Debug.LogWarning($"Target name not found: {gameObject.name}");
                return;
        }
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
