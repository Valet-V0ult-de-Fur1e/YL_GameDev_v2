using UnityEngine;

public class ShipPresenter : Presenter
{
    private Root _init;
    private int _lives;

    public void Init(Root init)
    {
        _init = init;
        _lives = 3;
    }

    public int GetLives()
    {
        return _lives;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_lives == 0)
            {
                _init.DisableShip();
            }
            else
            {
                _lives--;
            }
        }
    }
}
