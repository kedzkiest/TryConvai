using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class OpeningAnimation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI connectionRequestText_EN;
    [SerializeField] private Text connectionRequestText_JA;

    [SerializeField] private TextMeshProUGUI connectionEstablishedText_EN;
    [SerializeField] private Text connectionEstablishedText_JA;

    [SerializeField] private GameObject connectionEstablishedTrailA;
    [SerializeField] private GameObject connectionEstablishedTrailB;

    [SerializeField] private float periodAddFreqInSec = 0.5f;
    private int addedPeriodNum;

    private void Start()
    {
        addedPeriodNum = 0;
    }


    /// <summary>
    /// Given the input "Hi", this function gradually adds periods like
    /// "Hi."
    /// "Hi.."
    /// "Hi..."
    /// ...
    /// </summary>
    /// <param name="periodNum">The number of periods to be added to the text</param>
    public void AddPeriodsToText(int periodNum)
    {
        StartCoroutine(AddPeriod(periodNum));
    }

    private IEnumerator AddPeriod(int periodNum)
    {
        while (true)
        {
            yield return new WaitForSeconds(periodAddFreqInSec);
            connectionRequestText_EN.text += ".";
            connectionRequestText_JA.text += "・";
            addedPeriodNum += 1;

            if (addedPeriodNum != periodNum) continue;

            yield return new WaitForSeconds(periodAddFreqInSec);
            break;
        }

        HidePrev();
        ShowNext();
    }

    private void HidePrev()
    {
        connectionRequestText_EN.gameObject.SetActive(false);
        connectionRequestText_JA.gameObject.SetActive(false);
    }

    private void ShowNext()
    {
        connectionEstablishedText_EN.gameObject.SetActive(true);
        connectionEstablishedText_JA.gameObject.SetActive(true);

        connectionEstablishedTrailA.SetActive(true);
        connectionEstablishedTrailB.SetActive(true);
    }
}
