namespace Domain.Applications;

using Domain.Features;

public class Application
{
    private readonly List<Feature> _features = [];

    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public IReadOnlyCollection<Feature> Features => _features;

    public Application(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Application name is required");
        }

        Id = Guid.NewGuid();
        Name = name;
    }

    public Feature AddFeature(string name)
    {
        var feature = new Feature(name, Id);
        _features.Add(feature);
        return feature;
    }

    public void RemoveFeature(Guid featureId)
    {
        var feature = _features.FirstOrDefault(f => f.Id == featureId) ?? throw new Exception("Feature not found");
        _features.Remove(feature);
    }
}