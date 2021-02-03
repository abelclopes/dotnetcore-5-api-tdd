using domain.Model;
using infra.Repositories;
using infra.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace test
{
    public class PostUserTest : BaseTest
    {
        #region THEORY
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        //[InlineData("ABEL LOPES")]
        //public void Theory_PostUser_Name_NoValidation (string Name)
        //{
        //    var user = new User
        //    {
        //        Name = Name
        //    };

        //    var val = new PostUserValidator().Validate(user);
        //    Assert.False(val.IsValid);
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        //[InlineData("ABEL LOPES")]
        //public void Theory_PostUser_Name_Validation(string Name)
        //{
        //    var user = new User
        //    {
        //        Name = Name
        //    };

        //    var val = new PostUserValidator().Validate(user);
        //    Assert.False(val.IsValid);
        //}

        [Theory]
        [InlineData(null, 100)]
        [InlineData("", 100)]
        [InlineData("ABEL LOPES", 100)]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 101)]
        [InlineData("ABEL LOPES", 101)]
        public void Theory_PostUser_Name(string Name, int ErrorCode)
        {
            var user = new User
            {
                Name = Name
            };
            CheckError(new PostUserValidator(), ErrorCode, user);
        }

        [Theory]
        [InlineData(0, 102)]
        [InlineData(-1, 102)]
        [InlineData(33, 102)]
        public void Theory_PostUser_Age(int Age, int ErrorCode)
        {
            var user = new User
            {
                Age = Age
            };

            CheckError(new PostUserValidator(), ErrorCode, user);
        }

        #endregion
        #region FACT
        //[Fact]
        //public void Fact_PostUser_NoClassNoRepository ()
        //{
        //    // EXAMPLE
        //    var user = new User("ABEL LOPES", 33, true);

        //    // REPOSITORY
        //    ctx.User.Add(user);
        //    ctx.SaveChanges();

        //    // ASSERT 
        //    Assert.Equal(1, user.Id);
        //}

        //[Fact]
        //public void Fact_PostUser_NoRepository()
        //{
        //    // EXAMPLE
        //    var user = new User(0, "ABEL LOPES", 33, true);

        //    // REPOSITORY
        //    ctx.User.Add(user);
        //    ctx.SaveChanges();

        //    // ASSERT 
        //    Assert.Equal(1, user.Id);
        //}

        [Fact]
        public void Fact_PostUser_NoValidation()
        {
            var userId = Guid.NewGuid();
            // EXAMPLE
            var user = new User(userId, "ABEL LOPES", 33, true);
            var userId2 = Guid.NewGuid();

            // REPOSITORY
            user = new UserRepository(ctx).Post(user);

            // ASSERT 
            Assert.Equal(userId2, user.Id);
        }

        [Fact]
        public void Fact_PostUser()
        {
            // EXAMPLE            
            var userId = Guid.NewGuid();
            var user = new User(userId, "ABEL LOPES", 33, true);

            var val = new PostUserValidator().Validate(user);
            var userId2 = Guid.NewGuid();

            // ASSERT 
            Assert.True(val.IsValid);

            if (val.IsValid)
            {
                // REPOSITORY
                user = new UserRepository(ctx).Post(user);

                // ASSERT 
                Assert.Equal(userId2, user.Id);
            }
        }
        #endregion
    }

}
