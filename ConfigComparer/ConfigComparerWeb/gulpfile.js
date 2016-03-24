var gulp = require('gulp');
var source = require('vinyl-source-stream');
var browserify = require('browserify');

gulp.task('default', function () {
  var bundle = browserify({
    entries: ['./main.jsx'],
    extensions: ['.jsx', '.js', '.json']
  });
  bundle.bundle()
    .on('error', function (err) { console.log(err.message); })
    .pipe(source('bundle.js'))
    .pipe(gulp.dest('./'));
});