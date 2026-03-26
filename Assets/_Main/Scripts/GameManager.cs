using UnityEngine;

public class GameManager : MonoBehaviour
{
    //declarar variables
    [SerializeField] private float _vidajugador = 100;
    [SerializeField] private float _coinAmount = 0;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private UIManager uiManager;

    public void SumarVida(int cura)
    {
        if (_vidajugador <= 100)
        {
            _vidajugador += cura;
            ActualizarBarraDeVida();
        }

        else
        {
            _vidajugador = 100;

        }
    }
    public void RestarVida(int daño)
    {
        if (_vidajugador > 0)
        {
            _vidajugador -= daño;
            ActualizarBarraDeVida();
        }
        if (_vidajugador <= 0)
        {
            Destroy(playerController.gameObject);
        }
    }

    public void ActualizarBarraDeVida()
    {
        uiManager.FillAmountBarraDeVida(_vidajugador / 100);
        if (_vidajugador > 80)
        {
            uiManager.ColorBarraDeVida(Color.green);
        }
        else if (_vidajugador <= 80 && _vidajugador > 20)
        {
            uiManager.ColorBarraDeVida(Color.yellow);
        }
        else
        {
            uiManager.ColorBarraDeVida(Color.red);
        }
    }
    public void AddCoin(int coin)
    {
        _coinAmount += coin;
        uiManager.UpdateCoinText(coin);
    }
}
