using DG.Tweening;
using GameControllers.Ecs;
using Leopotam.Ecs;
using SpellItems;
using UnityEngine;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class UIGameField : MonoBehaviour
    {
        [SerializeField] private Transform _transformGameField;

        public void StartBombAnimation(
            GameObject bombPrefab, 
            Transform spawnTransform, 
            EcsWorld world,
            AudioSource explosionSound,
            AudioSource shakeGameFieldSound)
        {
            var bomb = Instantiate(bombPrefab, spawnTransform).GetComponent<DamageBomb>();

            DOTween.Sequence()
                .Append(bomb.transform.DOMove(_transformGameField.position, 1f))
                .AppendCallback(() => bomb.OnRadiusCollision())
                .Append(bomb.transform.DOScale(Vector3.zero, 0.5f))
                .AppendCallback(() => bomb.ExplosionParticle.Play())
                .AppendCallback(() => explosionSound.Play())
                .AppendCallback(() => bomb.DestroyItems(world))
                .AppendCallback(() => ShakeGameField(shakeGameFieldSound))
                .AppendInterval(1f)
                .AppendCallback(() => Destroy(bomb.gameObject));
        }

        public void ShakeGameField(AudioSource shakeGameFieldSound)
        {
            shakeGameFieldSound.Play();
            _transformGameField.DOShakePosition(1f, new Vector3(0.3f, 0.3f, 0.3f));
        }
    }
}

