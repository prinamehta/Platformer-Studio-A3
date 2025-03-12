using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score)
    {
    toUpdate.SetText($"{score}");
    coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
    coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration);

    // This is how you start a coroutine
    StartCoroutine(ResetCoinContainer(score));
    }

    private IEnumerator ResetCoinContainer(int score)
    {
    // This tells the editor to wait for a given period of time
    yield return new WaitForSeconds(duration);
    
    // We use duration since that's the same time as the animation
    current.SetText($"{score}"); // Update the original score

    // Then reset the y-localPosition of the coinTextContainer
    Vector3 localPosition = coinTextContainer.localPosition;
    coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
    }

}
