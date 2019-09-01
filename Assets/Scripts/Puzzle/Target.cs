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
            case ("violetTarget"):
                SetColor(ColorName.VIOLET);
                return;
            case ("orangeTarget"):
                SetColor(ColorName.ORANGE);
                return;
            case ("greenTarget"):
                SetColor(ColorName.GREEN);
                return;
            case ("brownTarget"):
                SetColor(ColorName.BROWN);
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

    public void SetLight(bool isLit, ColorName spaceColor) {
        //If space isn't lit up or if the color is a composite of the target, don't do anything
        if (!isLit || MyColor.IsComposite(myColor.GetColorName(), spaceColor)) {
            correctSprite.enabled = false;
            incorrectSprite.enabled = false;
            return;
        }

        if (MyColor.ToColor(spaceColor) == myColor.GetColor()) {
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
