namespace Domain.Steps;

public class Step
{
    public Guid Id { get; private set; }
    public Guid FeatureId { get; private set; }

    public string Title { get; private set; }

    public Step(string title, Guid featureId)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new Exception("Step title required");
        }

        Id = Guid.NewGuid();
        Title = title;
        FeatureId = featureId;
    }
}