using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using BusinessLayer;

namespace IhaveNoIdeaWhatImDoingButItWorks
{
    [TestClass]
    public class UserUnitTests
    {
        UserContext context;
        User ElUsero;

        [TestInitialize]
        public void Setup()
        {
            var context = new ExamDBContext();
            var _context = new UserContext(context);
            this.context = _context;

            User user = new User(0, "Pesho", "Atanasov", 55, "unbreakable", "235689", "idkman_01@gmail.com");
            ElUsero = user;
        }
        [TestCleanup]
        public void CleanUp()
        {
            //Deletion
            context.Delete(ElUsero);
            //Creation
            context.Create(ElUsero);
        }


        [TestMethod]
        public void CreateTest()
        {
            //Asserting 
            Assert.IsNotNull(context.Read(0));
        }
        [TestMethod]
        public void ReadTest()
        {
            //Doing
            var data = context.Read(0);

            //Doing 
            Assert.AreEqual(21, data.age);
        }
        [TestMethod]
        public void UpdateTest()
        {
            //Doing
            var newuser = new User(0, "Mesho", "Atanasov", 55, "unbreakable", "235689", "idkman_01@gmail.com");
            context.Update(newuser);

            //Asserting 
            Assert.AreEqual("Mesho", context.Read(0).fname);
        }
        [TestMethod]
        public void DeleteTest()
        {
            //Doing 
            context.Delete(0);

            Assert.IsNull(context.Read(0));
        }
        [TestMethod]
        public void ReadAllTest()
        {
            //Doing 
            Assert.IsNotNull(context.ReadAll());
        }
    }
}