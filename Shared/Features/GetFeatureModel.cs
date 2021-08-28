namespace Project.Track.Shared.Features
{
    public record GetFeatureModel(string Id, string Name, string SolutionId)
        : FeatureModel (Name)
    {
    }
}