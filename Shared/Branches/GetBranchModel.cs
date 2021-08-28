namespace Project.Track.Shared.Branches
{
    public record GetBranchModel(string Id, string SolutionId, string Name, bool IsDefaultBranch, string? ParentBranch);
}