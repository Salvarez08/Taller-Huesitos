using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
   public Image _barraDeVida;
   public TMP_Text _coinText;

    private void Start()
    {
        _barraDeVida.fillAmount = 1; 
    }
    public void ColorBarraDeVida(Color color)
    {
       _barraDeVida.color = color;

    }
    public void FillAmountBarraDeVida(float fillAmount)
    {
     _barraDeVida.fillAmount = fillAmount;
    }
    public void UpdateCoinText(int coincounter)
    {
        _coinText.text = "Coins: " + coincounter;
    }
}
