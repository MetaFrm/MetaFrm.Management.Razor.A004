using MetaFrm.Management.Razor.Models;
using MetaFrm.MVVM;

namespace MetaFrm.Management.Razor.ViewModels
{
    /// <summary>
    /// A004ViewModel
    /// </summary>
    public partial class A004ViewModel : BaseViewModel
    {
        /// <summary>
        /// SearchModel
        /// </summary>
        public SearchModel SearchModel { get; set; } = new();

        /// <summary>
        /// SelectResultModel
        /// </summary>
        public List<CommonClassModel> SelectResultModel { get; set; } = new List<CommonClassModel>();

        /// <summary>
        /// C001ViewModel
        /// </summary>
        public A004ViewModel()
        {

        }
    }
}