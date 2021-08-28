using Microsoft.AspNetCore.Components;

namespace Project.Track.Client.Shared
{
    public partial class SolutionLayout : LayoutComponentBase
    {
        public string SolutionId { get; private set; }
        
        protected override void OnParametersSet()
        {
            SolutionId = "BPERfTbXJKGyxqjKuCGq";
        }
    }
}