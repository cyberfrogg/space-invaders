using Ecs.Managers;
using Game.Utils;
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

        public static GameEntity CreatePlayer(this GameContext context, Vector3 position, Quaternion rotation)
        {
            var entity = context.CreateEntity();
            entity.AddUid(UidGenerator.Next());
            entity.AddPosition(position);
            entity.AddRotation(rotation);
            entity.AddVelocity(Vector3.one);

            entity.IsPlayer = true;
            
            return entity;
        }
    }
}