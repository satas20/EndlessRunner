using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SkinSelection : MonoBehaviour
{
    [Header("Navigation Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] private TMP_Text priceText;

    [Header("Skin Attributes")]
    [SerializeField] private int[] skinPrices;
    private int currentSkin;

    [Header("Sound")]
    [SerializeField] private AudioClip purchase;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        currentSkin = SaveManager.instance.currentSkin;
        SelectCar(currentSkin);
    }

    private void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);

        UpdateUI();
    }
    private void UpdateUI()
    {
        //If current car unlocked show the play button
        if (SaveManager.instance.carsUnlocked[currentSkin])
        {
            play.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
        //If not show the buy button and set the price
        else
        {
            play.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            priceText.text = skinPrices[currentSkin] + "$";
        }
    }

    private void Update()
    {
        //Check if we have enough money
        if (buy.gameObject.activeInHierarchy)
            buy.interactable = (SaveManager.instance.money >= skinPrices[currentSkin]);
    }

    public void ChangeCar(int _change)
    {
        currentSkin += _change;

        if (currentSkin > transform.childCount - 1)
            currentSkin = 0;
        else if (currentSkin < 0)
            currentSkin = transform.childCount - 1;

        SaveManager.instance.currentSkin = currentSkin;
        SaveManager.instance.Save();
        SelectCar(currentSkin);
    }
    public void BuyCar()
    {
        SaveManager.instance.money -= skinPrices[currentSkin];
        SaveManager.instance.carsUnlocked[currentSkin] = true;
        SaveManager.instance.Save();
        source.PlayOneShot(purchase);
        UpdateUI();
    }
}