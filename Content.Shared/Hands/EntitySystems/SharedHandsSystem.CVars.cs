using Content.Shared.CCVar;
using Robust.Shared.Configuration;

namespace Content.Shared.Hands.EntitySystems;

public abstract partial class SharedHandsSystem : EntitySystem
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    public bool UseFullHandsSystem { get; private set; }

    private void InitializeCVars()
    {
        _cfg.OnValueChanged(CCVars.UseHandsSystem, OnUseFullHandsSystemChanged, true);
    }

    private void ShutdownCVars()
    {
        _cfg.UnsubValueChanged(CCVars.UseHandsSystem, OnUseFullHandsSystemChanged);
    }

    private void OnUseFullHandsSystemChanged(bool obj)
    {
        UseFullHandsSystem = obj;
    }
}
