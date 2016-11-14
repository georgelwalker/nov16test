using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test
{
    public static class MockDbSet
    {
        public static Mock<DbSet<T>> Create<T>(params T[] elements) where T : class
        {
            return new List<T>(elements).AsDbSetMock();
        }
        
    }


    public static class ListExtensions
    {
        public static Mock<DbSet<T>> AsDbSetMock<T>(this List<T> list) where T : class
        {
            IQueryable<T> queryableList = list.AsQueryable();
            Mock<DbSet<T>> MockDbSet = new Mock<DbSet<T>>();
            MockDbSet.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            MockDbSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            MockDbSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            MockDbSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryableList.GetEnumerator());
            return MockDbSet;
        }
    }
}
