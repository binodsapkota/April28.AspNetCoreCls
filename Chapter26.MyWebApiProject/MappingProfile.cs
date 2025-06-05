using AutoMapper;

namespace Chapter26.MyWebApiProject
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.BookModel, Model.BookDto>();
            CreateMap<Model.BookDto, Model.BookModel>();
        }
    }
   
}
