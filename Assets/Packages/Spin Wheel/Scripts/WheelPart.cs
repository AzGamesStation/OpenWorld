using UnityEngine;
public class WheelPart : MonoBehaviour
{
    public SpriteRenderer spRend;
    public TextMesh valueText;
    public DotForSound[] pointCollider;
    public int myIndex;
    void Start()
    {
        myIndex = transform.GetSiblingIndex();
        if (valueText)
        {
            valueText.text = FortuneWheel.Instance.prizes[myIndex].ToString();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        FortuneWheel.Instance.selectedSprite = transform.GetChild(4).GetComponent<SpriteRenderer>().sprite;
        FortuneWheel.Instance.SelectedReward = transform.GetSiblingIndex();
    }
}