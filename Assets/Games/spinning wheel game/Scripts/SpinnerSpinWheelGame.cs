using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpinnerSpinWheelGame : MonoBehaviour
{
    [SerializeField] private Button buttonStartSpinning;

    [Header("System Spinner")]
    [SerializeField] private GameObject spinner;
    [SerializeField] private int speed;
    private float multiple;
    [SerializeField] private float multipleMin;
    [SerializeField] private float multipleMax;
    private bool isDone;
    private bool isStart;

    [Header("System Popup Reward")]
    [SerializeField] private GameObject panelReward;
    [SerializeField] private TMP_Text rewardName;
    [SerializeField] private Image rewardImage;
    [SerializeField] private PointerSpinWheelGame pointerScript;


    private void Update()
    {
        if (isDone == false && isStart == true)
        {
            StartRotation();
        }
    }

    private void StartRotation()
    {
        spinner.transform.Rotate(0, 0, speed * multiple * Time.deltaTime);

        if (multiple > 0)
        {
            multiple -= Time.deltaTime;
        }
        else
        {
            isDone = true;

            panelReward.SetActive(true);
            rewardName.text = pointerScript.pointerCollect.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
            rewardImage.sprite = pointerScript.pointerCollect.transform.GetChild(1).gameObject.GetComponent<Image>().sprite;
        }
    }

    public void ButtonStartSpinning()
    {
        multiple = Random.Range(multipleMin, multipleMax);

        isStart = true;

        buttonStartSpinning.interactable = false;
    }
}
