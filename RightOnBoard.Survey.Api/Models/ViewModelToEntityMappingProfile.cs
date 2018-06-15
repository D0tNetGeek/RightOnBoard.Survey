using AutoMapper;
using RightOnBoard.Survey.Api.ViewModels;

namespace RightOnBoard.Survey.Api.Models
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<SurveyViewModel, SurveyViewModel>().ForMember(au => au.SurveyId, map => map.MapFrom(vm => vm.SurveyId));
        }
    }
}
