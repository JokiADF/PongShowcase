using _Project.CodeBase.Services.Pool;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class ExplosionBehaviour : PoolObject
{
    [SerializeField] private ParticleSystem particle;
    
    private IPoolingService _poolingService;

    [Inject]
    private void Construct(IPoolingService poolingService) =>
        _poolingService = poolingService;

    public override async void OnSpawned(Vector3 position)
    {
        transform.position = position;
        particle.Play();

        await UniTask.Delay(Mathf.RoundToInt(particle.main.duration * 1000));
        
        _poolingService.Despawn(this);
    }

    public override void OnDespawned()
    {
        particle.Stop();
        transform.position = Vector3.zero;
    }
}
