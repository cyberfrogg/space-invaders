using Db.Bullet;
using Db.PickupItems;
using Ecs.Managers;
using Ecs.Utils;
using UnityEngine;

namespace Ecs.Game.Extensions
{
    public static class GameExtensions
    {
        public static GameEntity CreateCamera(this GameContext context)
        {
            var entity = context.CreateEntity();
            entity.AddUid(UidGenerator.Next());
            entity.AddPrefab("Camera");
            entity.AddPosition(Vector3.zero);
            entity.AddRotation(Quaternion.identity);
            entity.IsCamera = true;
            entity.IsInstantiate = true;
            return entity;
        }
        
        public static GameEntity CreateVirtualCamera(this GameContext context)
        {
            var entity = context.CreateEntity();
            entity.AddUid(UidGenerator.Next());
            entity.AddPrefab("VirtualCamera");
            entity.AddPosition(Vector3.zero);
            entity.AddRotation(Quaternion.identity);
            entity.IsInstantiate = true;
            return entity;
        }

        public static GameEntity CreatePlayer(this GameContext context, PlayerParameters playerParameters, Vector3 position, Quaternion rotation)
        {
            var entity = context.CreateEntity();
            entity.AddUid(UidGenerator.Next());
            entity.AddPosition(position);
            entity.AddRotation(rotation);
            entity.AddVelocity(Vector3.one);
            entity.AddPlayerParameters(playerParameters);
            entity.AddActiveBulletType(playerParameters.InitialActiveBulletType);

            entity.IsPlayer = true;
            
            return entity;
        }
        
        public static GameEntity CreateBullet(this GameContext context, Uid owner, Vector2 initialVelocityDirection, BulletVo bulletVo, Vector3 position, Quaternion rotation)
        {
            var entity = context.CreateEntity();
            entity.AddUid(UidGenerator.Next());
            entity.AddPosition(position);
            entity.AddRotation(rotation);
            entity.AddVelocity(initialVelocityDirection * bulletVo.InitialSpeed);
            entity.AddOwner(owner);
            entity.AddBullet(bulletVo.Type);
            
            entity.AddPrefab(bulletVo.PrefabName);
            entity.IsInstantiate = true;
            
            return entity;
        }
        
        public static GameEntity CreateEnemy(this GameContext context, EnemyParameters enemyParameters, Vector3 position, Quaternion rotation)
        {
            var entity = context.CreateEntity();
            entity.AddUid(UidGenerator.Next());
            entity.AddPosition(position);
            entity.AddRotation(rotation);
            entity.AddEnemy(enemyParameters.EnemyType);
            entity.AddEnemyParameters(enemyParameters);
            entity.AddHealth(enemyParameters.MaxHealth);
            
            return entity;
        }
        
        public static GameEntity CreateScoreIndicator(this GameContext context, int score, Vector3 position)
        {
            var entity = context.CreateEntity();
            entity.AddUid(UidGenerator.Next());
            entity.AddPosition(position);
            entity.AddRotation(Quaternion.identity);
            entity.AddScoreIndicator(score);

            entity.AddPrefab("ScoreIndicator");
            entity.IsInstantiate = true;
            
            return entity;
        }
        
        public static GameEntity CreatePickupItem(this GameContext context, PickupItemVo pickupItemVo, Vector2 initialVelocityDirection, Vector3 position)
        {
            var entity = context.CreateEntity();
            entity.AddUid(UidGenerator.Next());
            entity.AddPosition(position);
            entity.AddRotation(Quaternion.identity);
            entity.AddPickupItem(pickupItemVo.Type);
            entity.AddVelocity(initialVelocityDirection * pickupItemVo.InitialSpeed);

            entity.AddPrefab(pickupItemVo.PrefabName);
            entity.IsInstantiate = true;
            
            return entity;
        }
    }
}