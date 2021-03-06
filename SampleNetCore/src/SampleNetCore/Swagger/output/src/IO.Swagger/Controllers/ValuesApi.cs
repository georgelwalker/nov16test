/*
 * REST API Documentation
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using IO.Swagger.Models;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class ValuesApiController : Controller
    { 

        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id"></param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/api/Values/{id}")]
        [SwaggerOperation("ApiValuesByIdDelete")]
        public virtual void ApiValuesByIdDelete([FromRoute]int? id)
        { 
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id"></param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/Values/{id}")]
        [SwaggerOperation("ApiValuesByIdGet")]
        [SwaggerResponse(200, type: typeof(string))]
        public virtual IActionResult ApiValuesByIdGet([FromRoute]int? id)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<string>(exampleJson)
            : default(string);
            return new ObjectResult(example);
        }


        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <response code="204">No Content</response>
        [HttpPut]
        [Route("/api/Values/{id}")]
        [SwaggerOperation("ApiValuesByIdPut")]
        public virtual void ApiValuesByIdPut([FromRoute]int? id, [FromBody]string value)
        { 
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/Values")]
        [SwaggerOperation("ApiValuesGet")]
        [SwaggerResponse(200, type: typeof(List<string>))]
        public virtual IActionResult ApiValuesGet()
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<string>>(exampleJson)
            : default(List<string>);
            return new ObjectResult(example);
        }


        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="value"></param>
        /// <response code="204">No Content</response>
        [HttpPost]
        [Route("/api/Values")]
        [SwaggerOperation("ApiValuesPost")]
        public virtual void ApiValuesPost([FromBody]string value)
        { 
            throw new NotImplementedException();
        }
    }
}
