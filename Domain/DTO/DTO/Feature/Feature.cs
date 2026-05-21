
using Domain.Steps;
namespace Domain.Features
{
    public class Feature
    {
        private readonly List<Step> _steps = [];
        public Guid Id { get; private set; }
        public Guid ApplicationId { get; private set; }
        public string Name { get; private set; }

        public IReadOnlyCollection<Step> Steps => _steps;

        public Feature(string name, Guid applicationId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Feature name required");
            }

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
            {
                throw new Exception("Step not found");
            }

            _steps.Remove(step);
        }
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
}

