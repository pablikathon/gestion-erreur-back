namespace Domain.Features;

using Domain.Steps;

public class Feature
{
    private readonly List<Step> _steps = new();

    public Guid Id { get; private set; }
    public Guid ApplicationId { get; private set; }
    public string Name { get; private set; }

    public IReadOnlyCollection<Step> Steps => _steps;

    public Feature(string name, Guid applicationId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Feature name required");

        Id = Guid.NewGuid();
        Name = name;
        ApplicationId = applicationId;
    }

    public void AddStep(string title)
    {
        _steps.Add(new Step(title, Id));
    }

    public void RemoveStep(Guid stepId)
    {
        var step = _steps.FirstOrDefault(s => s.Id == stepId);

        if (step is null)
            throw new DomainException("Step not found");

        _steps.Remove(step);
    }

    // 🔥 LOGIQUE MÉTIER IMPORTANTE
    public FeatureComplexity GetComplexity()
    {
        var count = _steps.Count;

        return count switch
        {
            <= 3 => FeatureComplexity.Simple,
            <= 9 => FeatureComplexity.Complex,
            _ => FeatureComplexity.VeryComplex
        };
    }

    public bool IsTooComplex()
    {
        return _steps.Count >= 10;
    }
}