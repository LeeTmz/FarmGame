using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum PeriodOfDay
{
    Manhã,
    Tarde,
    Noite,
    Madrugada
}


public class ClockScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI clockText;
    [SerializeField] private TextMeshProUGUI timeOfDayText;
    [Space]
    [SerializeField] private Image spriteRenderer;
    [SerializeField] private Sprite[] spriteSeason;
    [Space]
    public PeriodOfDay startTimeOfDay = PeriodOfDay.Manhã;

     
   
    private int currentHour = 0;
    private int currentMinute = 0;
    private int currentSecond = 0;

    private int startHour = 0;

    private float elapsedTime = 0f;
    private float updateInterval = 1f;

    void Start()
    {       
     
        switch (startTimeOfDay)
        {
            case PeriodOfDay.Manhã:
                startHour = 6;
                break;
            case PeriodOfDay.Tarde:
                startHour = 13;
                break;
            case PeriodOfDay.Noite:
                startHour = 18;
                break;
            case PeriodOfDay.Madrugada:
                startHour = 00;
                break;
        }

        currentHour = startHour;
        currentMinute = 0;
        currentSecond = 0;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= updateInterval)
        {
            elapsedTime = 0f;

            currentSecond++;
            if (currentSecond >= 60)
            {
                currentSecond = 0;
                currentMinute++;
                if (currentMinute >= 60)
                {
                    currentMinute = 0;
                    currentHour++;
                    if (currentHour >= 24)
                    {
                        currentHour = 0;
                    }
                }
            }
            
            string timeString = currentHour.ToString("D2") + ":" + currentMinute.ToString("D2") + ":" + currentSecond.ToString("D2");
            clockText.text = timeString;
                        
            if (currentHour >= 6 && currentHour < 12.59f)
            {
                timeOfDayText.text = "Manhã";
                spriteRenderer.sprite = spriteSeason[0];
            }
            else if (currentHour >= 13 && currentHour < 17.59f)
            {
                timeOfDayText.text = "Tarde";
                spriteRenderer.sprite = spriteSeason[1];
            }
            else if (currentHour >= 18 && currentHour < 23.59f)
            {
                timeOfDayText.text = "Noite";
                spriteRenderer.sprite = spriteSeason[2];
            }
            else
            {
                timeOfDayText.text = "Madrugada";
                spriteRenderer.sprite = spriteSeason[3];
            }
        }
    }
}
