# AGENTS.md

## 1. Project Goal

This project is a Unity WebGL game template targeting Yandex Games. Platform integration must use Plugin Your Games 2.0, while gameplay, UI, save, ads, analytics, and leaderboard logic must remain platform-independent.

## 2. Strict Rules

- Do not rename, move, or delete serialized fields, scenes, prefabs, ScriptableObjects, assets, tags, layers, animation parameters, input actions, or resource paths unless explicitly requested.
- Do not change GUIDs, `.meta` files, scene object hierarchy, prefab structure, or serialized asset data unless required by the task.
- Do not perform broad formatting, cleanup, namespace moves, or refactors outside the requested scope.
- Do not introduce direct platform dependencies into gameplay code.
- Preserve public APIs and serialized member names used by Unity serialization.

## 3. Unity-Specific Constraints

- Treat Unity serialization as fragile: changing field names, types, access modifiers, or `[SerializeField]` members can break existing references.
- Prefer additive changes over destructive edits when modifying MonoBehaviours or ScriptableObjects.
- Use `[FormerlySerializedAs]` when a serialized field rename is explicitly required.
- Avoid changing scene or prefab references without inspecting affected assets.
- Keep editor-only code behind `#if UNITY_EDITOR` and out of runtime assemblies when possible.

## 4. Platform Integration Rules

- Gameplay code must not call Yandex Games or Plugin Your Games 2.0 APIs directly.
- All platform-specific calls must go through interfaces or adapters in a dedicated platform integration layer.
- Core systems should depend on abstractions such as ads, saves, language, payments, analytics, and leaderboards.
- WebGL/Yandex/PYG implementation details must be replaceable without editing gameplay systems.
- Provide safe no-op or mock implementations for editor and non-Yandex environments.

## 5. Migration Steps

1. Audit existing code for direct platform calls, serialized dependencies, and scene/prefab references.
2. Introduce platform-independent interfaces and adapters without changing gameplay behavior.
3. Integrate Plugin Your Games 2.0 only inside the platform adapter layer.
4. Replace direct calls gradually with abstractions and verify behavior after each step.

## 6. Code Guidelines

- Use clear, idiomatic C# that matches the existing Unity project style.
- Avoid unnecessary `async`/`await`, reflection, dynamic invocation, global state, and hidden side effects.
- Keep runtime code deterministic and simple for WebGL compatibility.
- Prefer explicit dependencies over service lookups unless the project already uses a service pattern.
- Add tests or editor validation only when they reduce real migration risk.

## 7. Output Format

Every change report must include:

- Changed files.
- Behavioral impact.
- Serialization or asset reference risks.
- Platform integration risks.
- Tests or validation performed.
