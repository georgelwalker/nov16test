'use strict';

var path = require('path');
var mockApi = require('swagger-mock-api');

module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    connect: {
      server: {
        options: {
		  port: 8080,
          keepalive: true,
          middleware: [
            mockApi({
                  //swaggerFile: path.join(__dirname, 'C:\Users\georg\Source\Repos\nov16test\SampleNetCore\src\SampleNetCore\Swagger\sample.json'),
                  swaggerFile: '..\\SampleNetCore\\src\\SampleNetCore\\Swagger\\sample.json',
                  
				  watch: true // enable reloading the routes and schemas when the swagger file changes
              })
          ],
        },
      },
    }
  });

  // Load the plugin that provides the "uglify" task.
  grunt.loadNpmTasks('grunt-contrib-connect');

  // Default task(s).
  grunt.registerTask('default', ['connect']);

};