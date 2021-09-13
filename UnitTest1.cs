using System;
using Xunit;
using NatureFresh;


namespace NatureFreshTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            validation vTest = new validation();
            string phoneNumber= "1234567890";
            string check = vTest.checkPhonenumber(phoneNumber);
            Assert.Equal("1234567890", check);
        }

        [Fact]
        public void Test2()
        {
            validation vTest = new validation();
            string phoneNumber = "2235567890";
            string check = vTest.checkPhonenumber(phoneNumber);
            Assert.Equal("2235567890", check);
        }

        [Fact]
        public void Test3()
        {
            validation vTest = new validation();
            int itemQuantity = 5;
            string check = vTest.checkQuantity(itemQuantity);
            Assert.Equal("5", check);
        }

        [Fact]
        public void Test4()
        {
            validation vTest = new validation();
            string pinCode = "416700";
            string check = vTest.checkPincode(pinCode);
            Assert.Equal("416700", check);
        }

        [Fact]
        public void Test5()
        {
            validation vTest = new validation();
            string pinCode = "416712";
            string check = vTest.checkPincode(pinCode);
            Assert.Equal("416712", check);
        }

        [Fact]
        public void Test6()
        {
            validation vTest = new validation();
            string itemweight = "250";
            string check = vTest.checkWeight(itemweight);
            Assert.Equal("250", check);
        }
        [Fact]
        public void Test7()
        {
            validation vTest = new validation();
            string itemweight = "1000";
            string check = vTest.checkWeight(itemweight);
            Assert.Equal("1000", check);
        }

        [Fact]
        public void Test8()
        {
            validation vTest = new validation();
            string itemweight = "1000";
            string check = vTest.checkWeight(itemweight);
            Assert.Equal("1000", check);
        }

        [Fact]
        public void Test9()
        {
            validation vTest = new validation();
            string location = "Panvel";
            string check = vTest.checkLocation(location);
            Assert.Equal("Panvel", check);
        }

        [Fact]
        public void Test10()
        {
            validation vTest = new validation();
            string location = "Thane";
            string check = vTest.checkLocation(location);
            Assert.Equal("Thane", check);
        }
    }
}
