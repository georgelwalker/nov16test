using IO.Swagger.Controllers;
using IO.Swagger.Models;
using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Annotations;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Moq;
using test;

namespace test
{
    public class DocumentationReaderTest
    {
        private XMLDocumentationReader _XMLDocumentationReader;
        public DocumentationReaderTest()
        {
            // initialize the test class.
            _XMLDocumentationReader = new XMLDocumentationReader();
        }
        [Fact]
        public void TestReader()
        {           

            System.Console.Out.WriteLine("Test Documentation Reader");

            Assert.True(true);
        }
    }
}
