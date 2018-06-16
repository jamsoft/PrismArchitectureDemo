using Prism.Regions;

namespace JamSoft.Prism.Core.ViewModels
{
    /// <summary>
    /// Defines a viewable page
    /// </summary>
    /// <seealso cref="IRegionMemberLifetime" />
    /// <seealso cref="INavigationAware" />
    public interface IPage : INavigationAware, IRegionMemberLifetime
    {
        string Name { get; set; }
    }
}