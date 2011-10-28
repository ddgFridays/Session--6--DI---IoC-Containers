using NUnit.Framework;
using Rhino.Mocks;
using TodoList.WithIoC;
using TodoList.WithIoC.Models;
using StructureMap.AutoMocking;

namespace _11_UnitTesting_With_Mocks
{
    [TestFixture]
    public class When_I_Add_A_TodoListItem
    {
        private ITodoListRepository _repository;
        private IDataStore _dataStore;

        [SetUp]
        public void Establish_Context()
        {
            _dataStore = MockRepository.GenerateMock<IDataStore>();
            _repository = new TodoListRepository(_dataStore);

            _repository.Add(new TodoListItem());
        }

        [Test]
        public void It_Should_Save_The_Item_To_The_DataStore()
        {
            _dataStore.AssertWasCalled(store => store.Save(Arg<TodoListItem>.Is.NotNull));
        }
    }



    [TestFixture]
    public class When_I_Add_A_TodoListItem_2
    {
        private RhinoAutoMocker<TodoListRepository> _mocks; 
        private ITodoListRepository _repository;

        [SetUp]
        public void Establish_Context()
        {
            _mocks = new RhinoAutoMocker<TodoListRepository>();
            _repository = _mocks.ClassUnderTest;

            _repository.Add(new TodoListItem());
        }

        [Test]
        public void It_Should_Save_The_Item_To_The_DataStore()
        {
            _mocks
                .Get<IDataStore>()
                .AssertWasCalled(store => store.Save(Arg<TodoListItem>.Is.NotNull));
        }
    }
}