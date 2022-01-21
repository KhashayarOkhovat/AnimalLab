using System;
using DataLayer.MyGenericRepository;

namespace DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {


        //#region [ کاربران ]
        //private GenericRepository<User> _userRepository;
        //public GenericRepository<User> UserRepository
        //{
        //    get
        //    {
        //        if (_userRepository == null)
        //        {
        //            _userRepository = new GenericRepository<User>(db);
        //        }
        //        return _userRepository;
        //    }
        //}
        //#endregion

        LabratoryDBEntities db = new LabratoryDBEntities();

        #region [ اشخاص ]
        private GenericRepository<Person> _personRepository;
        public GenericRepository<Person> Person_Repository
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = new GenericRepository<Person>(db);
                }
                return _personRepository;
            }
        }
        #endregion

        #region [ نتیجه ]
        private GenericRepository<Result> _resultRepository;
        public GenericRepository<Result> Result_Repository
        {
            get
            {
                if (_resultRepository == null)
                {
                    _resultRepository = new GenericRepository<Result>(db);
                }
                return _resultRepository;
            }
        }
        #endregion
        #region [ مشخصات حیوان ]
        private GenericRepository<Animal> _animalRepository;
        public GenericRepository<Animal> Animal_Repository
        {
            get
            {
                if (_animalRepository == null)
                {
                    _animalRepository = new GenericRepository<Animal>(db);
                }
                return _animalRepository;
            }
        }
        #endregion

        #region [  انواع حیوان ]
        private GenericRepository<AnimalType> _animalTypeRepository;
        public GenericRepository<AnimalType> AnimalType_Repository
        {
            get
            {
                if (_animalTypeRepository == null)
                {
                    _animalTypeRepository = new GenericRepository<AnimalType>(db);
                }
                return _animalTypeRepository;
            }
        }
        #endregion
        #region [ تست ]
        private GenericRepository<TestType> _testTypeRepository;
        public GenericRepository<TestType> TestType_Repository
        {
            get
            {
                if (_testTypeRepository == null)
                {
                    _testTypeRepository = new GenericRepository<TestType>(db);
                }
                return _testTypeRepository;
            }
        }
        #endregion
        #region [ نقش ]
        private GenericRepository<Role> _roleRepository;
        public GenericRepository<Role> Role_Repository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new GenericRepository<Role>(db);
                }
                return _roleRepository;
            }
        }
        #endregion



        public void sava()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
