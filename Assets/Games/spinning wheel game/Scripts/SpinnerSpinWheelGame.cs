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
    [SerializeField] private int speedSpin;
    private float durationSpin;
    [SerializeField] private float durationSpinMin;
    [SerializeField] private float durationSpinMax;
    private bool isDone;
    private bool isStart;

    [Header("System Popup Reward")]
    [SerializeField] private GameObject panelReward;
    [SerializeField] private TMP_Text textRewardName;
    [SerializeField] private Image imageReward;
    [SerializeField] private PointerSpinWheelGame pointerScript;

    [Header("System Chance To Spin")]
    [SerializeField] private TMP_Text textSpinChance;
    [SerializeField] private int spinChance;

    private void Start()
    {
        textSpinChance.text = spinChance.ToString();
    }

    private void Update()
    {
        // * This spin requirement
        if (isDone == false && isStart == true)
        {
            textSpinChance.text = spinChance.ToString();

            StartRotation();
        }

        // * This for non active interactable spin button
        if (spinChance == 0)
        {
            buttonStartSpinning.interactable = false;
        }
    }

    // * This method for spin spinner
    private void StartRotation()
    {
        spinner.transform.Rotate(0, 0, speedSpin * durationSpin * Time.deltaTime);

        if (durationSpin > 0)
        {
            durationSpin -= Time.deltaTime;
        }
        else
        {
            isDone = true;

            panelReward.SetActive(true);
            textRewardName.text = pointerScript.pointerCollectReward.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
            imageReward.sprite = pointerScript.pointerCollectReward.transform.GetChild(1).gameObject.GetComponent<Image>().sprite;
        }
    }

    // * This method for trigger spin
    public void ButtonStartSpinning()
    {
        if (spinChance > 0)
        {
            spinChance -= 1;

            durationSpin = Random.Range(durationSpinMin, durationSpinMax);

            isStart = true;
            isDone = false;
        }
    }

    // * This method for close popup reward and reset spinner rotation.
    public void ButtonClose()
    {
        spinner.transform.rotation = new Quaternion(0, 0, 0, 0);
        panelReward.SetActive(false);
    }

    // * This method for add chance spin
    public void ButtonAddSpin()
    {
        spinChance += 1;

        textSpinChance.text = spinChance.ToString();

        buttonStartSpinning.interactable = true;
    }

}
