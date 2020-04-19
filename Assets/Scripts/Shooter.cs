using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private ParticleSystem _shootingEffect;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private GameObject _bulletContainer;

    private bool _canPlayerFire = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_canPlayerFire)
            {
                StartCoroutine(TryShoot());
            }
        }
    }

    private IEnumerator TryShoot()
    {
        var waitForSeconds = new WaitForSeconds(_shootingDelay);
   
        Instantiate(_shootingEffect, _shootPoint);
        //Instantiate(_bulletTemplate, _shootPoint); // пуля дочерняя и виляет за пистолетом
        Instantiate(_bulletTemplate, _shootPoint.position, _shootPoint.rotation);
        _canPlayerFire = false;
        yield return waitForSeconds;
        _canPlayerFire = true;
    }

    

    // реализация через другой Input
    //private void Update()
    //{
    //    if (Input.touchCount > 0)                               // количество пальцев на экране больше 0
    //    {
    //        if (Input.GetTouch(0).phase == TouchPhase.Began)      // фаза касания - начало
    //        {
    //            Instantiate(_bulletTemplate, _shootPoint);
    //        }
    //    }
    //}
}
