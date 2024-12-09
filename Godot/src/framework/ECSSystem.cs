using Godot;
using System;
using System.Collections.Generic;

// ECS System for managing entities
public class ECSSystem
{
    private List<Entity> entities = new List<Entity>();
    private int nextId = 1;

    public Entity CreateEntity()
    {
        var entity = new Entity(nextId++);
        entities.Add(entity);
        return entity;
    }

    public void RemoveEntity(Entity entity)
    {
        entities.Remove(entity);
    }

    public List<Entity> GetEntitiesWithComponent<T>() where T : IComponent
    {
        return entities.FindAll(e => e.GetComponent<T>() != null);
    }

    public int UpdateMonsterAI(Node mount,Entity monsterEntity, List<Entity> playerEntities)
    {
        var monsterComponent = monsterEntity.GetComponent<MonsterComponent>();
        if (monsterComponent == null) return 0;

        var monsterPosition = monsterComponent.MonsterBody.Position;

        foreach (var playerEntity in playerEntities)
        {
            var playerComponent = playerEntity.GetComponent<PlayerComponent<CharacterBody2D>>();
            if (playerComponent != null)
            {
                var playerPosition = playerComponent.PlayerBody.Position;
                var distance = monsterPosition.DistanceTo(playerPosition);

                if (distance < monsterComponent.AttackRange)
                {
                
                    // Add attack logic here
                    RemoveEntity(playerEntity);
                    mount.RemoveChild(playerComponent.PlayerBody);
                    playerComponent.PlayerBody.QueueFree();
                    GD.Print("Monster attacks player!");
                    return 1;
                }
                else
                {
                    GD.Print("Monster stops attacking.");
                    // Add retreat or idle logic here
                }
            }
        }
        return 0;
    }
   
}
