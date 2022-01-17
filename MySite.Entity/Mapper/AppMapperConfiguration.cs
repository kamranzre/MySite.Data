using AutoMapper;
using MySite.Entity.Entities.Persons;
using MySite.Entity.Models.PersonModel;

namespace MySite.Entity.Mapper
{
    public class AppMapperConfiguration : Profile, IOrderedMapperProfile
    {
        #region Ctor

        public AppMapperConfiguration()
        {
            //create specific maps
            CreatePersonMaps();
        }

        #endregion




        /// <summary>
        /// Create file storage maps 
        /// </summary>
        #region CreateMapper
        protected virtual void CreatePersonMaps()
        {
            CreateMap<PersonCreateOrEditModel, Person>();

            CreateMap<Person, PersonCreateOrEditModel>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        public int Order => 0;

        #endregion
    }
}
