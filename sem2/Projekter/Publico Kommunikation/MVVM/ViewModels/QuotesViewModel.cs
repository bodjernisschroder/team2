//using Publico_Kommunikation_Project.Core;
//using Publico_Kommunikation_Project.DataAccess;
//using Publico_Kommunikation_Project.Models;
//using System.Collections.ObjectModel;

//namespace Publico_Kommunikation_Project.ViewModels
//{
//    public class QuotesViewModel : ViewModel
//    {
//        SelectedQuote - Giver mening, hvis vi har en knap til "start redigering" - hvis redigering skal ske p� klik p� Quote, giver den ikke mening
//        Vi skal ogs� have filtrering ind her
//         N�r man klikker ind p� en Quote bruges NavigateTo til at g� til QuotePage og den relevante QuoteViewModel
//         Derefter kaldes QuoteViewModel.Initialize, som gives den Quote, vi har klikket p�.

//         viewModel.Initialize(quote)

//         public void GetByIdQuote(int quoteId)
//        {
//            if (quoteId > 0)
//            {
//                // GetById Quote and store in temporary Quote variable
//                Quote quote = _classTemplateRepository.GetById(classTemplateViewModelId);

//                // Adds the found classTemplate to ClassTemplateViewModel collection
//                if (classTemplate != null)
//                {
//                    var classTemplateViewModel = new ClassTemplateViewModel(classTemplate);

//                    // Ensure ClassTemplateViewModel does not already exist in the collection
//                    if (!ClassTemplateViewModels.Any(vm => vm.Model.ClassTemplateId == classTemplateViewModel.Model.ClassTemplateId))
//                        ClassTemplateViewModels.Add(classTemplateViewModel);
//                }
//            }
//        }

//    }
//}