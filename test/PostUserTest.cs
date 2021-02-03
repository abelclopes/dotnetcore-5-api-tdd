using domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace test
{
    public class PostUserTest
    {
        #region THEORY
        #endregion
        #region FACT
        [Fact]
        public void Fact_PostUser()
        {
            // EXAMPLE
            var user = new User("Abel Loes", 41, true);

            // REPOSITORY
            ctx.User.Add(user);
            ctx.SaveChanges();

            // ASSERT
            Assert.Equal(1, user.Id);
        }
        #endregion
    }
}
