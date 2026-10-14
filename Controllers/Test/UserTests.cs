using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceDayAPI.Controllers;
using RaceDayAPI.Database;
using RaceDayAPI.Models;

namespace RaceDayAPI.Tests
{//start of namespace
    [TestClass]
    public class UserTests
    {//start of class
        [TestMethod]
        public void Register_ShouldCreateUser()
        {
            var context = TestHelper.GetInMemoryContext();
            var controller = new UserController(context);

            var result = controller.Register("testuser", "password123", "Participant");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login_ShouldReturnUser_WhenCredentialsAreCorrect()
        {
            var context = TestHelper.GetInMemoryContext();
            var controller = new UserController(context);

            controller.Register("testuser", "password123", "Participant");
            var result = controller.Login("testuser", "password123");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login_ShouldReturnNull_WhenCredentialsAreWrong()
        {
            var context = TestHelper.GetInMemoryContext();
            var controller = new UserController(context);

            controller.Register("testuser", "password123", "Participant");
            var result = controller.Login("testuser", "wrongpassword");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Organiser_ShouldCreateEvent()
        {
            var context = TestHelper.GetInMemoryContext();
            var userController = new UserController(context);
            var eventController = new EventController(context);

            userController.Register("organiser", "password123", "Organiser");
            var result = eventController.CreateEvent("Race Day", "Location A", "Type A", "organiser");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Participant_ShouldFailToCreateEvent()
        {
            var context = TestHelper.GetInMemoryContext();
            var userController = new UserController(context);
            var eventController = new EventController(context);

            userController.Register("participant", "password123", "Participant");
            var result = eventController.CreateEvent("Race Day", "Location A", "Type A", "participant");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Participant_ShouldEnrolSuccessfully()
        {
            var context = TestHelper.GetInMemoryContext();
            var userController = new UserController(context);
            var eventController = new EventController(context);
            var enrolmentController = new EnrolmentController(context);

            var user = userController.Register("participant", "Password123", "Participant");
            var ev = eventController.CreateEvent("Race Day", "Location A", "Type A", "organiser");

            var result = enrolmentController.Enrol(user.Id, ev.Id, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(user.Id, result.UserId);
        }

        [TestMethod]
        public void Organiser_ShouldFailToEnrol()
        {
            var context = TestHelper.GetInMemoryContext();
            var userController = new UserController(context);
            var eventController = new EventController(context);
            var enrolmentController = new EnrolmentController(context);

            var user = userController.Register("organiser", "password123", "Organiser");
            var ev = eventController.CreateEvent("Race Day", "Location A", "Type A", "organiser");

            var result = enrolmentController.Enrol(user.Id, ev.Id, 1);

            Assert.IsNull(result);

        }
    }//end of class
}//end of namespace 



