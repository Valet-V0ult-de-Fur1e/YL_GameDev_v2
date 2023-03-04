using UnityEngine;
using Asteroids.Model;

public class SpawnExample : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;
    [SerializeField] private Root _init;

    private int _index;
    private float _secondsPerIndex = 1f;
    private Asteroid _lastGenerateAsteroid;

    private void Update()
    {
        int newIndex = (int)(Time.time / _secondsPerIndex);

        if(newIndex > _index)
        {
            _index = newIndex;
            OnTick();
        }
    }

    private void OnTick()
    {
        float chance = Random.Range(0, 100);

        if (chance < 20)
        {
            if (_lastGenerateAsteroid != null)
            {
                _factory.CreateNlo(new Nlo(_lastGenerateAsteroid, GetRandomPositionOutsideScreen(), Config.NloSpeed));
            }
        }
        else
        {
            Vector2 position = GetRandomPositionOutsideScreen();
            Vector2 direction = GetDirectionThroughtScreen(position);
            _lastGenerateAsteroid = new Asteroid(position, direction, Config.AsteroidSpeed);
            _factory.CreateAsteroid(_lastGenerateAsteroid);
        }
    }

    private Vector2 GetRandomPositionOutsideScreen()
    {
        return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
    }

    private static Vector2 GetDirectionThroughtScreen(Vector2 postion)
    {
        return (new Vector2(Random.value, Random.value) - postion).normalized;
    }
}
