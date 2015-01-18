// Karma configuration
// Generated on Tue May 13 2014 09:09:13 GMT+0100 (GMT Summer Time)

module.exports = function(config) {
  config.set({

    // base path that will be used to resolve all patterns (eg. files, exclude)
    basePath: '',


    // frameworks to use
    // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
    frameworks: ['jasmine'],


    // list of files / patterns to load in the browser
    files: [

        'vendor_libs/jquery-1.10.2.js',

        'vendor_libs/angular.min.js',
        'vendor_libs/angular-mocks.js',
        'vendor_libs/bootstrap.min.js',

        'vendor_libs/ui-bootstrap-tpls-0.11.0.min.js',

        'node_modules/karma-jasmine/lib/jasmine.js',

        'src/js/app/FunctionLib.js',
        'src/js/app/main.js',

        'src/js/app/controllers/TaskControllers.js',
        'src/js/app/services/TaskService.js',
        'src/js/app/controllers/footerController.js',
        'src/js/app/services/MovieBannerService.js',
        'src/js/app/controllers/MovieBannerController.js',


        'test/MocksAndModels.js',

        'test/controller_tests.js'


    ],


    // list of files to exclude
    exclude: [
      
    ],


    // preprocess matching files before serving them to the browser
    // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
    preprocessors: {
    
    },


    // test results reporter to use
    // possible values: 'dots', 'progress'
    // available reporters: https://npmjs.org/browse/keyword/karma-reporter
    reporters: ['progress'],


    // web server port
    port: 9876,


    // enable / disable colors in the output (reporters and logs)
    colors: true,


    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_INFO,


    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: false,


    // start these browsers
    // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
    browsers: ['PhantomJS'],


    // Continuous Integration mode
    // if true, Karma captures browsers, runs the tests and exits
    singleRun: true
  });
};
