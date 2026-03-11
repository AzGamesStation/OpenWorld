using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Play.Review;

public class RateUs : MonoBehaviour
{
    public GameObject[] goldstars;
    public GameObject reviewBtn;
    public GameObject thanksPanel;
    int tempNum;
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;

    public void RateStar(int num)
    {
        tempNum = num;
        for (int i = 0; i < num; i++)
        {
            goldstars[i].SetActive(true);
        }
        reviewBtn.SetActive(true);
        firebasecall1.Instance.Event($"user_rate_{num}_stars");
    }

    public void SendReview()
    {
        PlayerPrefs.SetInt("RateUs", 1);
        if (tempNum == 5 || tempNum == 4)
        {

            StartCoroutine(RequestReviews());
            thanksPanel.SetActive(true);
        }
        else
        {
            thanksPanel.SetActive(true);
        }
    }

    IEnumerator RequestReviews()
    {
        _reviewManager = new ReviewManager();
        // Request a ReviewInfo Object
        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        //Launch the InappReview
        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        // The flow has finished. The API does not indicate whether the user
        // reviewed or not, or even whether the review dialog was shown. Thus, no
        // matter the result, we continue our app flow.
    }
}